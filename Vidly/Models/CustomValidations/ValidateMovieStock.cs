using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.CustomValidations
{
    public class ValidateMovieStock : ValidationAttribute
    {
        private const int MAX_MOVIE_STOCK_LIMIT = 30;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
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