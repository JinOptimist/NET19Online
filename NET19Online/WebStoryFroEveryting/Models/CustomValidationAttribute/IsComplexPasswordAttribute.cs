using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using WebStoryFroEveryting.Models.Auth;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    public class IsComplexPasswordAttribute: ValidationAttribute
    {
        private int _minLength;
        private int _maxLength;
        public IsComplexPasswordAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var viewModel = (AuthViewModel)validationContext.ObjectInstance;
            var errorMessage = new StringBuilder();
            var isValid = true;
            var requiredCharacters = new string[] { "!", "?", "(", ")", "[", "]" };
            if (viewModel.Password.Length < _minLength || viewModel.Password.Length > _maxLength)
            {
                isValid = false;
                errorMessage.Append($"Пароль должен иметь не менее {_minLength} символов и не более {_maxLength} символов. ");
            }
            if (!requiredCharacters.Any(c => viewModel.Password.Contains(c)))
            {
                isValid = false;
                errorMessage.Append($"Пароль должен содержать хотя бы один из этих символов: {String.Join(' ', requiredCharacters)}. ");
            }
            if (!viewModel.Password.Any(c => char.IsDigit(c)))  
            {
                isValid = false;
                errorMessage.Append($"Пароль должен содержать хотя бы одну цифру. ");
            }

            if (!isValid) return new ValidationResult(errorMessage.ToString());

            return ValidationResult.Success;
        }
    }
}
