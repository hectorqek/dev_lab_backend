using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class EmpleadoSeccion
    {
        public long IdPersona { get; set; }
        public int? IdAsignacion { get; set; }
        public int? IdSeccion { get; set; }
    }
}
