using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class TipoAtributo
    {
        public long IdTipoAtributo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Entidad { get; set; }
        public string Dominio { get; set; }
    }
}
