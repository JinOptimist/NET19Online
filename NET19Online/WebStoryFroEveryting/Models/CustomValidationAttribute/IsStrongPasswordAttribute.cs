using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebStoryFroEveryting.Models.Auth;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    public class IsStrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var viewModel = (AuthViewModel)validationContext.ObjectInstance;
            var pattern = @"(?x)^(?=.*(\d|\p{P}|\p{S})).{6,}"; 

            if (!Regex.IsMatch(viewModel.Password, pattern))
            {
                return new ValidationResult("Pass must be at least 6 symbols include digit, character or punctuation mark!");
            }

            return ValidationResult.Success;
        }
    }
}
