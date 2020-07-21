using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Parametro
    {
        public int IdParametro { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public string TipoDato { get; set; }
        public string Grupo { get; set; }
    }
}
