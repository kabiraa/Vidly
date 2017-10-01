using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidations;

namespace Vidly.DTOs
{
    public class MoviesDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        //[Range(1,20)]
        [ValidateMovieStock]
        public int? NumberInStock { get; set; }

        [Required]
        public int? GenreId { get; set; }
    }
}