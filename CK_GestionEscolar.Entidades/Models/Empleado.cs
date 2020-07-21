using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Empleado
    {
        public long IdPersona { get; set; }
        public int? Cargo { get; set; }
        public string AreaDependencia { get; set; }
        public string Escolaridad { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public string UsuarioLog { get; set; }
    }
}
