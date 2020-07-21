using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Curso
    {
        public Curso()
        {
            CalendarioPlantillaHorario = new HashSet<CalendarioPlantillaHorario>();
        }

        public long IdCurso { get; set; }
        public long? IdGrado { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<CalendarioPlantillaHorario> CalendarioPlantillaHorario { get; set; }
    }
}
