using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebStoryFroEveryting.Models.Auth;

namespace WebStoryFroEveryting.Models.CustomValidationAttributeForUnderwaterHunter
{
    /// <summary>
    /// return true if value is zero
    /// </summary>    
    public class isDepthNotZeroAttribute : ValidationAttribute
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
