﻿namespace APITestValidacion.Models
{
    public class ClasePersona
    {
        // DNI / Pasaporte / NIE / ...
        public string Identificador { get; set; } = "";

        public string Nombre { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string EmailUA { get; set; } = "";
        public string EmailPersonal { get; set; } = "";
        public string UrlPersonal { get; set; } = "";
        public DateOnly FechaNacimiento { get; set; }

    }
}