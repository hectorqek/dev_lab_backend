using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Dominio
    {
        public long IdValorDominioGrado { get; set; }
        public string Dominio1 { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public string Criterio { get; set; }
        public bool? Activo { get; set; }
    }
}
