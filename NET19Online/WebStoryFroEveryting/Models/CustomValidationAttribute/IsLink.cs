using System;
using System.ComponentModel.DataAnnotations;

namespace WebStoryFroEveryting.Models.CustomValidationAttribute
{
    public class IsLinkAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;
            if (string.IsNullOrEmpty(url))
            {
                return ValidationResult.Success;
            }

            try
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return ValidationResult.Success;
                }
            }
            catch
            {
                throw new Exception("Connection failed");
            }

            return new ValidationResult("Invalid URL");
        }
    }
}
