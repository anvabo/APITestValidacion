using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APITestValidacion.Models.Atributos
{
    public class CorreoUAAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string correo)
            {
                if (!string.IsNullOrEmpty(correo)) {
                    string pattern = @"@.*ua\.es$";
                    bool isMatch = Regex.IsMatch(correo, pattern);

                    if (isMatch) {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult($"El campo {validationContext.DisplayName} no es un correo de la UA.");
        }
    }
}
