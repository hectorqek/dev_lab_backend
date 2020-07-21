using CampusKey.Entidades.Models;
using CampusKey.Negocio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusKey.Web.WebApi
{
    [ApiController]
    [Route("api/calendario")]
    public class CalendarioController : ControllerBase
    {
        public readonly Lazy<CalendarioNegocio> _calendarioNegocio;

        public CalendarioController()
        {
            _calendarioNegocio = new Lazy<CalendarioNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpPost]
        [Route("generarMesCalendario")]
        public IActionResult generarMesCalendario(string MesSeleccionado, string Usuario)
        {
            List<Calendario> nuevoCalendario = new List<Calendario>();
            nuevoCalendario = _calendarioNegocio.Value.generarMesCalendario(MesSeleccionado, Usuario);
            return Ok(JsonConvert.SerializeObject(nuevoCalendario, settings));
        }

        [HttpGet]
        [Route("consultarPlantillas")]
        public IActionResult consultarPlantillas()
        {
            List<PlantillaHorario> listaPlantillasHorario = new List<PlantillaHorario>();
            listaPlantillasHorario = _calendarioNegocio.Value.consultarPlantillas();
            return Ok(JsonConvert.SerializeObject(listaPlantillasHorario, settings));
        }

        [HttpPost]
        [Route("guardarCalendario")]
        public IActionResult guardarCalendario(Calendario CalendarioEditado, string Usuario, string OperacionRealizada)
        {
            bool respuesta = false;
            respuesta = _calendarioNegocio.Value.guardarCalendario(CalendarioEditado, Usuario, OperacionRealizada);
            return Ok(JsonConvert.SerializeObject(respuesta, settings));
        }
    }
}
