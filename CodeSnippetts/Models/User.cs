using System.ComponentModel.DataAnnotations;

namespace CodeSnippetts.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [ISDrivingLicenseRequiredAttribute()]
        public string? DrivingLicense { get; set; }
    }
    

    public class ISDrivingLicenseRequiredAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
                  $"Driving License is Required For Age 17+.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var user = validationContext.ObjectInstance as User;

            if (user?.Age >= 18 && string.IsNullOrWhiteSpace((string)value))
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
