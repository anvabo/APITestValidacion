using APITestValidacion.Models.Atributos;
using System.ComponentModel.DataAnnotations;

namespace APITestValidacion.Models
{
    public class ClasePersona
    {
        // DNI / Pasaporte / NIE / ...
        [Required]
        [Key]
        public string Identificador { get; set; } = "";

        [StringLength(100)]       
        public string Nombre { get; set; } = "";

        [StringLength(200)]
        public string Apellidos { get; set; } = "";

        [EmailAddress]
        [CorreoUA]
        public string EmailUA { get; set; } = "";

        [EmailAddress]
        public string EmailPersonal { get; set; } = "";
        public string UrlPersonal { get; set; } = "";

        public DateOnly FechaNacimiento { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe ser entre 0 y 100")]
        public double PorcentajePerfil { get; set; } = 0;

        public List<ClasePerfiles> Perfiles { get; set; } = new List<ClasePerfiles>();

        [FileExtensions(Extensions = "jpg,png,pdf", ErrorMessage = "La foto debe tener el formato .jpg, .png o .pdf.")]
        public IFormFile? Foto { get; set; }

    }
}
