using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Genre Type")]
        public MovieGenre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}