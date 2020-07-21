using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class AtributoPeriodoLectivo
    {
        public int IdAtributoPeriodoLectivo { get; set; }
        public int IdPeriodoLectivo { get; set; }
        public int? IdTipoAtributo { get; set; }
        public string Valor { get; set; }

        public virtual PeriodoLectivo IdPeriodoLectivoNavigation { get; set; }
    }
}
