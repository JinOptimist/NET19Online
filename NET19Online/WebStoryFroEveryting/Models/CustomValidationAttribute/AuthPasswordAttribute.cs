using System.ComponentModel.DataAnnotations;
using WebStoryFroEveryting.Models.Auth;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    public class AuthPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var viewModel = (AuthViewModel)validationContext.ObjectInstance;

            if (viewModel.Password == viewModel.UserName)
            {
                return new ValidationResult("Be more creative. Pass can't be the same as name");
            }

            return ValidationResult.Success;
        }
    }
}
