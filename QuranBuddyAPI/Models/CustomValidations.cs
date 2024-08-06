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

}
