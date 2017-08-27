using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MoviesFormViewModel
    {
        public IEnumerable<MovieGenre> GenreType { get; set; }
        public Movie Movie { get; set; }

        public string GetMovieTitle() {
            return Movie != null ? "Edit Movie" : "New Movie";
        }
    }
}