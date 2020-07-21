using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CampusKey.Datos
{
    public class MateriaRepositorio
    {
        public readonly DB_CampusKey_DevContext _context;
        public MateriaRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }
        public List<Horario> consultarMaterias(string usuario)
        {
            List<Horario> resultadoConsultarHorario;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoConsultarHorario = (from dp in context.Horario
                                             select dp).ToList();
            }

            return resultadoConsultarHorario;
        }
    }
}
