using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using VenMovie.Models;
using VenMovie.Dtos;

namespace VenMovie.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _contect;
        public MoviesController()
        {
            _contect = new ApplicationDbContext();
        }
        //get/api/customers
        public IEnumerable<MovieDto> GetMovies(string query=null)
        {
            var moviesQuery = _contect.Movies
                 .Include(m => m.Genre)
                 .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }
        //get/api/customers/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _contect.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound()
;
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //post/api/cutomers
        [HttpPost]
        [Authorize(Roles = "CanManageMovies")]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _contect.Movies.Add(movie);
            _contect.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //put/api/cutomers/1
        [HttpPut]
        [Authorize(Roles = "CanManageMovies")]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieUpdate = _contect.Movies.SingleOrDefault(c => c.Id == id);
            if (movieUpdate == null)
            {
                return NotFound();
            }
            Mapper.Map<MovieDto, Movie>(movieDto, movieUpdate);
            _contect.SaveChanges();
            return Ok();
        }
        //delete/api/customers/1
        [HttpDelete]
        [Authorize(Roles = "CanManageMovies")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var movieDelete = _contect.Movies.SingleOrDefault(c => c.Id == id);
            if (movieDelete == null)
            {
                return NotFound();
            }
            _contect.Movies.Remove(movieDelete);
            _contect.SaveChanges();
            return Ok();
        }
    }
}
