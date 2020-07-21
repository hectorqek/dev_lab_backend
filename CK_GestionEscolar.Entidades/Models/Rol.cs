using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string TipoRol { get; set; }
        public int? IdFuncionalidad { get; set; }
    }
}
