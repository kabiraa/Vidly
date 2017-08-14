using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        /*public ActionResult Random()
        {
            var movie = new Movie() { Name = "DDLJ" };
            var customers = new List<Customer>
            {
                new Customer() { Name = "Kabir" },
                new Customer() { Name = "Lallu" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Kabir's Id " + id);
        }

        [Route("movies/released/{year}/{month:range(1,12):regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("Year::  " + year + " and Month:  " + month);
        }*/

        [Route("Movie/MovieList")]
        public ActionResult MovieList()
        {
            var movies = GetMovies();
            var viewModel = new ListMoviesViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }

        private IEnumerable<Movie> GetMovies() {
            return new List<Movie>()
            {
                new Movie() { Name = "Jatt and Juliet", Id = 1 },
                new Movie() { Name = "Godzilla", Id = 2 }
            };
        }
    }
}