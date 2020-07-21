using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusKey.Datos
{
    public class HorarioRepositorio
    {
        public readonly DB_CampusKey_DevContext _context;
        public HorarioRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }
        public List<Horario> generarHorario(Int32 idPeriodoLectivo, Int32 idGrado, string usuario)
        {
            List<Horario> resultadoGenerarHorario;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoGenerarHorario = (from dp in context.Horario
                                  select dp).ToList();

            }
            return resultadoGenerarHorario;
        }

        public List<Horario> consultarHorario(Int32 idPeriodoLectivo, Int32 idGrado, string usuario)
        {
            List<Horario> resultadoConsultarHorario;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoConsultarHorario = (from dp in context.Horario
                                           select dp).ToList();

            }
            return resultadoConsultarHorario;
        }

        public List<Horario> guardarHorario(Horario[] horario, string usuario)
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

    public class PlantillaHorarioRepositorio
    {
        public readonly DB_CampusKey_DevContext _context;
        public PlantillaHorarioRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }
        public List<PlantillaHorario> consultarPlantillas(string usuario)
        {
            List<PlantillaHorario> resultadoConsultarPlantillas;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoConsultarPlantillas = (from dp in context.PlantillaHorario
                                           select dp).ToList();

            }
            return resultadoConsultarPlantillas;
        }

        public List<PlantillaHorario> consultarTipoHorario(string usuario)
        {
            List<PlantillaHorario> resultadoConsultarTipoHorario;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoConsultarTipoHorario = (from dp in context.PlantillaHorario
                                                select dp).ToList();

            }
            return resultadoConsultarTipoHorario;
        }


        public List<PlantillaHorario> eliminarActividad(int idPlantilla, int idActividad, string usuario)
        {
            List<PlantillaHorario> resultadoEliminarActividad;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoEliminarActividad = (from dp in context.PlantillaHorario
                                                 select dp).ToList();

            }
            return resultadoEliminarActividad;
        }

        public List<PlantillaHorario> eliminarPlantilla(int idPlantilla, int idActividad, string usuario)
        {
            List<PlantillaHorario> resultadoEliminarPlantilla;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoEliminarPlantilla = (from dp in context.PlantillaHorario
                                              select dp).ToList();

            }
            return resultadoEliminarPlantilla;
        }

        public List<PlantillaHorario> guardarPlantilla(int idPlantilla, Object[] actividades, string usuario)
        {
            List<PlantillaHorario> resultadoGuardarPlantilla;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoGuardarPlantilla = (from dp in context.PlantillaHorario
                                              select dp).ToList();

            }
            return resultadoGuardarPlantilla;
        }
    }

    }
