using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Vidly.DTOs;

namespace Vidly.Models.CustomValidations
{
    public class ValidateMovieStock : ValidationAttribute
    {
        private const int MAX_MOVIE_STOCK_LIMIT = 30;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = new Movie();
            if (validationContext.ObjectType == typeof(MoviesDTO)) {
                movie = Mapper.Map((MoviesDTO)validationContext.ObjectInstance, movie);
            }
            else {
                movie = (Movie)validationContext.ObjectInstance;
            }

            if (movie.NumberInStock == 0 || movie.NumberInStock > MAX_MOVIE_STOCK_LIMIT)
            {
                return new ValidationResult("Field number in stock must be 1 and 30");
            }
            else {
                return ValidationResult.Success;
            }
        }
    }
}