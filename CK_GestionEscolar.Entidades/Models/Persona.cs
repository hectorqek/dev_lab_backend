using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Persona
    {
        public long IdPersona { get; set; }
        public int? LugarExpedicion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string PaisNacimiento { get; set; }
        public string Genero { get; set; }
        public string Username { get; set; }
        public string CorreoAlternativo { get; set; }
        public string Celular { get; set; }
        public string UrlFoto { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public int? IdDepartamento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
