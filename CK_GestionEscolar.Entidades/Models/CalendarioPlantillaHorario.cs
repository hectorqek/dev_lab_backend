using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class CalendarioPlantillaHorario
    {
        public int IdCalendario { get; set; }
        public long IdCurso { get; set; }
        public int IdPlantillaHorario { get; set; }

        public virtual Calendario IdCalendarioNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual PlantillaHorario IdPlantillaHorarioNavigation { get; set; }
    }
}
