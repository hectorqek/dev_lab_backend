using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusKey.Datos
{
    public class CalendarioRepositorio
    {
        public readonly DB_CampusKey_DevContext _context;

        public CalendarioRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }

        public List<Calendario> generarMesCalendario(string MesSeleccionado, string Usuario)
        {
            List<Calendario> nuevoCalendario = new List<Calendario>();
            using (var context = new DB_CampusKey_DevContext())
            {
                //se debe hacer con procedimiento almacenado y no con linq, revisar SeguridadRepositorio, el metodo consultarMenu para ver un ejemplo del uso de un procedimiento almacenado
                nuevoCalendario = (from dp in context.Calendario
                                   select dp).ToList();

                //nuevoCalendario = (from dp in context.Calendario
                //                   select dp).Where(cl => cl.Fecha.ToString().StartsWith(MesSeleccionado)).ToList();
            }

            return nuevoCalendario;
        }

        public List<PlantillaHorario> consultarPlantillas()
        {
            List<PlantillaHorario> listaPlantillasHorario = new List<PlantillaHorario>();
            using (var context = new DB_CampusKey_DevContext())
            {
                //se debe hacer con procedimiento almacenado y no con linq, revisar SeguridadRepositorio, el metodo consultarMenu para ver un ejemplo del uso de un procedimiento almacenado
                listaPlantillasHorario = (from dp in context.PlantillaHorario
                                          select dp).ToList();
            }

            return listaPlantillasHorario;
        }

        public bool guardarCalendario(Calendario CalendarioEditado, string Usuario, string OperacionRealizada)
        {
            bool respuesta = false;

            return respuesta;
        }
    }
}
