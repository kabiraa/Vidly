using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models.CustomValidations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        //[Range(1,20)]
        [ValidateMovieStock]
        [Display(Name = "Number in stock")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre Type")]
        public MovieGenre Genre { get; set; }

        [Required]
        public int? GenreId { get; set; }
    }
}