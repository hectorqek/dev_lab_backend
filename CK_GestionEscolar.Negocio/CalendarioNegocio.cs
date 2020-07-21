using CampusKey.Datos;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;

namespace CampusKey.Negocio
{
    public class CalendarioNegocio
    {
        private static readonly Lazy<CalendarioRepositorio> _calendarioRepositorio = new Lazy<CalendarioRepositorio>(() => new CalendarioRepositorio());

        public List<Calendario> generarMesCalendario(string MesSeleccionado, string Usuario)
        {
            List<Calendario> nuevoCalendario = new List<Calendario>();
            nuevoCalendario = _calendarioRepositorio.Value.generarMesCalendario(MesSeleccionado, Usuario);

            return nuevoCalendario;
        }

        public List<PlantillaHorario> consultarPlantillas()
        {
            List<PlantillaHorario> listaPlantillasHorario = new List<PlantillaHorario>();
            listaPlantillasHorario = _calendarioRepositorio.Value.consultarPlantillas();

            return listaPlantillasHorario;
        }

        public bool guardarCalendario(Calendario CalendarioEditado, string Usuario, string OperacionRealizada)
        {
            bool respuesta = false;
            respuesta = _calendarioRepositorio.Value.guardarCalendario(CalendarioEditado, Usuario, OperacionRealizada);

            return respuesta;
        }
    }
}
