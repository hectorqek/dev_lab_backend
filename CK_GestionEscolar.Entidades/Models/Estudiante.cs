using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Estudiante
    {
        public string IdPersona { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Casa { get; set; }
        public int? NivelIngreso { get; set; }
        public bool? Matricula { get; set; }
        public bool? Reintegro { get; set; }
        public bool? Cartera { get; set; }
        public string ResponsablePago { get; set; }
        public string NombreResponsablePago { get; set; }
        public string TipoIdentificacionAcudiente { get; set; }
        public string NumeroIdentificacionAcudiente { get; set; }
        public long? CodigoEstudiante { get; set; }
    }
}
