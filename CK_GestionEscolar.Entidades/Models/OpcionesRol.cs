using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class OpcionesRol
    {
        public int IdRol { get; set; }
        public int IdFuncionalidad { get; set; }
        public string Permiso { get; set; }

        public virtual Funcionalidad IdFuncionalidadNavigation { get; set; }
    }
}
