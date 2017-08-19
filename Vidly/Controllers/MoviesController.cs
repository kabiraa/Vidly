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