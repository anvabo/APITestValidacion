namespace APITestValidacion.Models
{
    public class ClasePersonas
    {
        public List<ClasePersona> Obtener()
        {
            return new List<ClasePersona>()
            {
                new ClasePersona
                {
                    Identificador = "1",
                    Nombre = "Pedro",
                    Apellidos = "Martínez",
                    FechaNacimiento = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                    EmailPersonal = "pm@gmail.com",
                    EmailUA = "pm@ua.es",
                    UrlPersonal = "https://www.ua.es"
                }
            };
        }
    }
}
