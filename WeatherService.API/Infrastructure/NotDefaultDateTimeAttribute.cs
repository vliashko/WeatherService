using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherService.API.Infrastructure
{
    public class NotDefaultDateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is DateTime))
            {
                return new ValidationResult($"The field {validationContext.MemberName} must be DateTime.");
            }

            if ((DateTime)value == DateTime.MinValue)
            {
                return new ValidationResult($"The field {validationContext.MemberName} cannot be default value.");
            }

            return ValidationResult.Success;
        }
    }
}
