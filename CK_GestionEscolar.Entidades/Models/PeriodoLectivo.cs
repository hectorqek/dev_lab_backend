using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class PeriodoLectivo
    {
        public PeriodoLectivo()
        {
            AtributoPeriodoLectivo = new HashSet<AtributoPeriodoLectivo>();
        }

        public int IdPeriodoLectivo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? PeriodoActivo { get; set; }
        public bool? PeriodoAdmisiones { get; set; }

        public virtual ICollection<AtributoPeriodoLectivo> AtributoPeriodoLectivo { get; set; }
    }
}
