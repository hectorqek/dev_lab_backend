using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Horario
    {
        public int Idmateria { get; set; }
        public int Idcurso { get; set; }
        public int? Dia { get; set; }
        public int? Hora { get; set; }
    }
}
