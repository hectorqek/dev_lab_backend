using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Grado
    {
        public long IdGrado { get; set; }
        public string Nombre { get; set; }
        public long? IdSeccion { get; set; }
    }
}
