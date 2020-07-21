using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Padre
    {
        public long IdPersona { get; set; }
        public string Escolaridad { get; set; }
        public string Titulo { get; set; }
        public string Ocupacion { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public string TelefonoOficina { get; set; }
        public bool? Exalumno { get; set; }
        public int? UltimoAnio { get; set; }
        public string UltimoGrado { get; set; }
        public string TipoPadre { get; set; }
        public string UsuarioLog { get; set; }
        public string SectorEconomico { get; set; }
    }
}
