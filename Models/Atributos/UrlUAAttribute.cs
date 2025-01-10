using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APITestValidacion.Models.Atributos
{
    public class UrlUAAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string url)
            {
                if (!string.IsNullOrEmpty(url)) {
                    string pattern = @"^(https?:\/\/)?([\w\-]+\.)*ua\.es(\/.*)?$";
                    bool isMatch = Regex.IsMatch(url, pattern);

                    if (isMatch) {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult($"El campo {validationContext.DisplayName} no es un correo de la UA.");
        }
    }
}
