using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebStoryFroEveryting.Models.Auth;

namespace WebStoryFroEveryting.Models.CustomValidationAttributeForUnderwaterHunter
{
    /// <summary>
    /// return true if value has only English letters and value isn't null,
    /// otherwise false  
    /// </summary>    
    public class isDepthNotZero : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var depth = (int)value!;
            if (depth == 0)
            {
                return new ValidationResult("The depth mustn't be zero!");
            }

            return ValidationResult.Success;
        }
    }
}
