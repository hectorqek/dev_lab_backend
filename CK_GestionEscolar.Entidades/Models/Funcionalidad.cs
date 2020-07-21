using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Funcionalidad
    {
        public Funcionalidad()
        {
            OpcionesRol = new HashSet<OpcionesRol>();
        }

        public int IdFuncionalidad { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public int? Padre { get; set; }
        public int? Orden { get; set; }
        public string Imagen { get; set; }
        public string EtiquetaHtml { get; set; }

        public virtual ICollection<OpcionesRol> OpcionesRol { get; set; }
    }
}
