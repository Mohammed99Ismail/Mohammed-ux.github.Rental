using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenMovie.Models;
using VenMovie.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace VenMovie.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
                return View("Index");
            return View("ReadOnlyList");
        }

        // GET: Movies/Random
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieGenre(movie)
                {
                    Genre = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var UpdateDB = _context.Movies.Single(c => c.Id == movie.Id);
                UpdateDB.Name = movie.Name;
                UpdateDB.ReleazeDate = movie.ReleazeDate;
                UpdateDB.NumberInStock = movie.NumberInStock;
                UpdateDB.GenreId = movie.GenreId;
            }
                _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();
            var viewmodel = new MovieGenre(movie)
            {
                Genre = _context.Genres.ToList()
            };

            return View("New", viewmodel);
        }
        [Authorize(Roles ="CanManageMovies")]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var MovGen = new MovieGenre
            {
                Genre = genre
            };
            return View(MovGen);
        }

    }
}