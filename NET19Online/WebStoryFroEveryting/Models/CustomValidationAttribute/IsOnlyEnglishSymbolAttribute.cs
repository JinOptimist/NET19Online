using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebStoryFroEveryting.Models.Auth;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    /// <summary>
    /// return true if value has only English letters and value isn't null,
    /// otherwise false  
    /// </summary>    
    public class IsOnlyEnglishSymbolAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var str = value as string;
            if (str == null)
            {
                return new ValidationResult("The line must be filled!");
            }

            var pattern = new Regex("^[a-zA-Z0-9. -_?]*$", RegexOptions.Compiled);
            if (!pattern.IsMatch(str))
            {
                return new ValidationResult("The line must contain only English letters");
            }

            return ValidationResult.Success;
        }
    }
}
