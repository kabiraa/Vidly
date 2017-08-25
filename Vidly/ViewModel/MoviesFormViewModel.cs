using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MoviesFormViewModel
    {
        public IEnumerable<MovieGenre> GenreType { get; set; }
        public Movie Movie { get; set; }

        public string GetMovieTitle() {
            string movieTitle = "New Movie";
            if (Movie != null) {
                movieTitle = "Edit Movie";
            }
            return movieTitle;
        }
    }
}