using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class PlantillaHorario
    {
        public PlantillaHorario()
        {
            CalendarioPlantillaHorario = new HashSet<CalendarioPlantillaHorario>();
        }

        public int IdPlantillaHorario { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public string TipoHora { get; set; }
        public int? NumeroHora { get; set; }

        public virtual ICollection<CalendarioPlantillaHorario> CalendarioPlantillaHorario { get; set; }
    }
}
