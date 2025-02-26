using System.ComponentModel.DataAnnotations;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    /// <summary>
    /// Set min and max length for string
    /// </summary>
    public class RangeLengthAttribute : ValidationAttribute
    {
        private int _minLength;
        private int _maxLength;

        public RangeLengthAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Ваша поле {name} должно быть иметь хотя бы {_minLength} символов и быть не длинее чем {_maxLength}";
        }

        public RangeLengthAttribute(int minLength)
        {
            _minLength = minLength;
            _maxLength = int.MaxValue;
        }

        public override bool IsValid(object? value)
        {
            var str = value as string;
            if (str == null)
            {
                return false;
            }

            if (str.Length > _maxLength)
            {
                return false;
            }

            if (str.Length <  _minLength)
            {
                return false;
            }

            return true;
        }
    }
}
