using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class TipoHorario
    {
        public int IdTipoHorario { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public string TipoHora { get; set; }
        public int? NumeroHora { get; set; }
    }
}
