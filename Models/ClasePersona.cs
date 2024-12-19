using System.ComponentModel.DataAnnotations;

namespace APITestValidacion.Models
{
    public class ClasePersona
    {
        // DNI / Pasaporte / NIE / ...
        [Required]
        public string Identificador { get; set; } = "";

        public string Nombre { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string EmailUA { get; set; } = "";

        [EmailAddress]
        public string EmailPersonal { get; set; } = "";
        public string UrlPersonal { get; set; } = "";
        public DateOnly FechaNacimiento { get; set; }

    }
}
