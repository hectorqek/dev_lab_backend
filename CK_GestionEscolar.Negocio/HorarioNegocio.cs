using CampusKey.Datos;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusKey.Negocio
{
    public class HorarioNegocio
    {
        private static readonly Lazy<HorarioRepositorio> _horarioRepositorio = new Lazy<HorarioRepositorio>(() => new HorarioRepositorio());

        public List<Horario> generarHorario(Int32 idPeriodoLectivo, Int32 idGrado, string usuario)
        {
            List<Horario> resultadoGenerarHorario;
            resultadoGenerarHorario = _horarioRepositorio.Value.generarHorario(idPeriodoLectivo, idGrado, usuario);
            return resultadoGenerarHorario;
        }

        public List<Horario> consultarHorario(Int32 idPeriodoLectivo, Int32 idGrado, string usuario)
        {
            List<Horario> resultadoConsultarHorario;
            resultadoConsultarHorario = _horarioRepositorio.Value.consultarHorario(idPeriodoLectivo, idGrado, usuario);
            return resultadoConsultarHorario;
        }

        public List<Horario> guardarHorario(Horario[] horario, string usuario)
        {
            List<Horario> resultadoGuardarHorario;
            resultadoGuardarHorario = _horarioRepositorio.Value.guardarHorario(horario, usuario);
            return resultadoGuardarHorario;
        }
    }

    public class PlantillaHorarioNegocio
    {
        private static readonly Lazy<PlantillaHorarioRepositorio> _plantillaHorarioRepositorio = new Lazy<PlantillaHorarioRepositorio>(() => new PlantillaHorarioRepositorio());

        public List<PlantillaHorario> consultarPlantillas(string usuario)
        {
            List<PlantillaHorario> resultadoConsultarPlantillas;
            resultadoConsultarPlantillas = _plantillaHorarioRepositorio.Value.consultarPlantillas(usuario);
            return resultadoConsultarPlantillas;
        }

        public List<PlantillaHorario> consultarTipoHorario(string usuario)
        {
            List<PlantillaHorario> resultadoConsultarHorario;
            resultadoConsultarHorario = _plantillaHorarioRepositorio.Value.consultarTipoHorario(usuario);
            return resultadoConsultarHorario;
        }

        public List<PlantillaHorario> eliminarActividad(int idPlantilla, int idActividad, string usuario)
        {
            List<PlantillaHorario> resultadoEliminarActividad;
            resultadoEliminarActividad = _plantillaHorarioRepositorio.Value.eliminarActividad(idPlantilla, idActividad, usuario);
            return resultadoEliminarActividad;
        }

        public List<PlantillaHorario> eliminarPlantilla(int idPlantilla, int idActividad, string usuario)
        {
            List<PlantillaHorario> resultadoEliminarPlantilla;
            resultadoEliminarPlantilla = _plantillaHorarioRepositorio.Value.eliminarPlantilla(idPlantilla, idActividad, usuario);
            return resultadoEliminarPlantilla;
        }

        public List<PlantillaHorario> guardarPlantilla(int idPlantilla, Object[] actividades, string usuario)
        {
            List<PlantillaHorario> resultadoGuardarPlantilla;
            resultadoGuardarPlantilla = _plantillaHorarioRepositorio.Value.guardarPlantilla(idPlantilla, actividades, usuario);
            return resultadoGuardarPlantilla;
        }
    }
    }
