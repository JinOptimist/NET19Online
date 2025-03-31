using StoreData.Repostiroties;
using System.ComponentModel.DataAnnotations;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    public class IsUniqName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var str = value as string;
            if (str == null)
            {
                return new ValidationResult("Can't be empty");
            }

            var userRepository = validationContext.GetRequiredService<IUserRepository>();
            if (userRepository.Any(str))
            {
                return new ValidationResult($"There is user with the same name. '{str}'");
            }

            return ValidationResult.Success;
        }
    }
}
