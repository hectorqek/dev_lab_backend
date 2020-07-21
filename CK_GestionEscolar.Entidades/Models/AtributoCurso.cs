using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class AtributoCurso
    {
        public long IdAtributoCurso { get; set; }
        public long IdTipoAtributo { get; set; }
        public long? IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
