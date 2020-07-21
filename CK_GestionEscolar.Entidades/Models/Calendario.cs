using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Calendario
    {
        public Calendario()
        {
            CalendarioPlantillaHorario = new HashSet<CalendarioPlantillaHorario>();
        }

        public int IdCalendario { get; set; }
        public DateTime? Fecha { get; set; }
        public string NombreDia { get; set; }
        public int? NumeroDia { get; set; }
        public int? NumeroCiclo { get; set; }
        public string TipoDia { get; set; }

        public virtual ICollection<CalendarioPlantillaHorario> CalendarioPlantillaHorario { get; set; }
    }
}
