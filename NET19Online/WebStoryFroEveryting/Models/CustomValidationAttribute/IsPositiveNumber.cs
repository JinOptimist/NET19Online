using System.ComponentModel.DataAnnotations;
using System.Numerics;
namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    public class IsPositiveNumber<T> : ValidationAttribute where T : ISignedNumber<T>
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var number = (T)value!;
            if (!T.IsPositive(number)) return new ValidationResult("Значение меньше нуля!");
            return ValidationResult.Success;
        }
    }
}
