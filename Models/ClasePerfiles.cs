using System.ComponentModel.DataAnnotations;

namespace APITestValidacion.Models
{
    public class ClasePerfiles
    {
        [Required]
        [Key]
        public int Id { get; set; } = 0;

        [Required]
        public string Nombre { get; set; } = "";
    }
}
