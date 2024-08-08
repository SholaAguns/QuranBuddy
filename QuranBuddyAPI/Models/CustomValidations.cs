using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QuranBuddyAPI.Models
{
  

    public class AllowedValuesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedValues;

        public AllowedValuesAttribute(params string[] allowedValues)
        {
            _allowedValues = allowedValues;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !_allowedValues.Contains(value.ToString()))
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be one of the following values: {string.Join(", ", _allowedValues)}.");
            }

            return ValidationResult.Success;
        }
    }

    public class AllowedRangeEndAttribute : ValidationAttribute
    {

        private readonly string _rangeStartProperty;

        public AllowedRangeEndAttribute(string rangeStartProperty)
        {
            _rangeStartProperty = rangeStartProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rangeEnd = (int)value;
            var property = validationContext.ObjectType.GetProperty(_rangeStartProperty);

            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_rangeStartProperty}");
            }

            var rangeStart = (int)property.GetValue(validationContext.ObjectInstance);

            if (rangeEnd < rangeStart)
            {
                return new ValidationResult($"Range end must be greater or equal to range start");
            }

            return ValidationResult.Success;
        }
    }



    public class AllowedIdsEndAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public AllowedIdsEndAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IEnumerable<int> list)
            {
                foreach (var item in list)
                {
                    if (item < _min || item > _max)
                    {
                        return new ValidationResult($"Each element in the list must be between {_min} and {_max}.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }

    public class AllowedNamesLengthEndAttribute : ValidationAttribute
    {
        private readonly int _maxLength;

        public AllowedNamesLengthEndAttribute(int max)
        {

            _maxLength = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IEnumerable<string> list)
            {
                foreach (var item in list)
                {
                    if (item.Length > _maxLength)
                    {
                        return new ValidationResult($"Element length limit is " + _maxLength);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }


}
