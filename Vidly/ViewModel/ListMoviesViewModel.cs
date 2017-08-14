using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class ListMoviesViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}