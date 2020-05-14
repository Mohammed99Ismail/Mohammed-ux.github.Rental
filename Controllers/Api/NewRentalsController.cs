using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VenMovie.Dtos;
using VenMovie.Models;

namespace VenMovie.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //if (newRental.MoviesId.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");
            
            var cutomer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
           // if (cutomer == null)
           //     return BadRequest("CustomerId is Not Valid.");

            var movies = _context.Movies.Where(m => newRental.MoviesId.Contains(m.Id)).ToList();
            //if (movies.Count != newRental.MoviesId.Count)
            //    return BadRequest("one or more movie are not valid.");

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = cutomer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
