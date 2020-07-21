

using System;

namespace Vainilla.Web.Models
{
    public class EstudianteViewModel
    {
        public long id { get; set; }
        public string imagen { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string curso { get; set; }
        public string activo { get; set; }
        public DateTime? nacimiento { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }

    }

}
