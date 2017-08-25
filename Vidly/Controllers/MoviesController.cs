using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
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
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult MoviesForm()
        {
            var genreTypes = _context.GenreType.ToList();
            var viewModel = new MoviesFormViewModel()
            {
                GenreType = genreTypes
                
            };
            return View("MoviesForm",viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else {
                //Todo: Update existing movie.
                var existingMovie = _context.Movies.Single(m => m.Id == movie.Id);
                existingMovie.Name = movie.Name;
                existingMovie.Genre = movie.Genre;
                existingMovie.GenreId = movie.GenreId;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("MovieList","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movieDetails = _context.Movies.Single(m=> m.Id == id);
            var viewModel = new MoviesFormViewModel()
            {
                GenreType = _context.GenreType.ToList(),
                Movie = movieDetails
            };
            return View("MoviesForm",viewModel);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movieDetail = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=> m.Id == id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }
            else {
                return View(movieDetail);
            }
        }

        [Route("Movie/MovieList")]
        public ActionResult MovieList()
        {
            var movies = _context.Movies.Include(m => m.Genre);
            var viewModel = new ListMoviesViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }
    }
}