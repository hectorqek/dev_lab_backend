using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class EstudianteCurso
    {
        public int IdAsignacion { get; set; }
        public int? IdCurso { get; set; }
        public long? IdPersona { get; set; }
        public string Estado { get; set; }
        public string UsuarioLog { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public string Observaciones { get; set; }
        public string EstudiantePendienteCurso { get; set; }
    }
}
