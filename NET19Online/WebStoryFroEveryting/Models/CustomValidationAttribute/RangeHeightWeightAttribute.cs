using System.ComponentModel.DataAnnotations;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    public class RangeHeightWeightAttribute : ValidationAttribute
    {
        private int _minValue;
        private int _maxValue;

        public RangeHeightWeightAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override string FormatErrorMessage(string name)
        {
            return !string.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"Поле {name} должно иметь значение не менее {_minValue} и не более {_maxValue}";
        }

        public override bool IsValid(object? value)
        {
            var heightWeight = (int?)value;

            if (heightWeight == null || heightWeight < _minValue || heightWeight > _maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
