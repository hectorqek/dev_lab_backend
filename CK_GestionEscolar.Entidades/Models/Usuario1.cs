using System;
using System.Collections.Generic;

namespace CampusKey.Entidades.Models
{
    public partial class Usuario
    {
        public string IdUsuario { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int? IdPersona { get; set; }
    }
}
