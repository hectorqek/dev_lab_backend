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
    [Route("api/horario")]
    [ApiController]
    public class HorarioController : ControllerBase
    {

        public readonly Lazy<HorarioNegocio> _horarioNegocio;
        public HorarioController()
        {
            _horarioNegocio = new Lazy<HorarioNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarHorario")]
        public IActionResult consultarHorario(Int32 idPeriodoLectivo, Int32 idGrado, string usuario)
        {
            List<Horario> resultadoConsultarHorario;
            resultadoConsultarHorario = _horarioNegocio.Value.consultarHorario(idPeriodoLectivo, idGrado, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoConsultarHorario, settings));
        }

        [HttpGet]
        [Route("generarHorario")]
        public IActionResult generarHorario(Int32 idPeriodoLectivo, Int32 idGrado, string usuario)
        {
            List<Horario> resultadoGenerarHorario;
            resultadoGenerarHorario = _horarioNegocio.Value.generarHorario(idPeriodoLectivo, idGrado, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoGenerarHorario, settings));
        }

        [HttpGet]
        [Route("guardarHorario")]
        public IActionResult guardarHorario(Horario[] horario, string usuario)
        {
            List<Horario> resultadoGenerarHorario;
            resultadoGenerarHorario = _horarioNegocio.Value.guardarHorario(horario, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoGenerarHorario, settings));
        }
    }

    [Route("api/plantillaHorario")]
    [ApiController]
    public class PlantillaHorarioController : ControllerBase
    {

        public readonly Lazy<PlantillaHorarioNegocio> _plantillaHorarioNegocio;
        public PlantillaHorarioController()
        {
            _plantillaHorarioNegocio = new Lazy<PlantillaHorarioNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarPlantillas")]
        public IActionResult consultarPlantillas(string usuario)
        {
            List<PlantillaHorario> resultadoConsultarPlantillas;
            resultadoConsultarPlantillas = _plantillaHorarioNegocio.Value.consultarPlantillas(usuario);
            return Ok(JsonConvert.SerializeObject(resultadoConsultarPlantillas, settings));
        }


        [HttpGet]
        [Route("consultarTipoHorario")]
        public IActionResult consultarTipoHorario(string usuario)
        {
            List<PlantillaHorario> resultadoConsultarHorario;
            resultadoConsultarHorario = _plantillaHorarioNegocio.Value.consultarTipoHorario(usuario);
            return Ok(JsonConvert.SerializeObject(resultadoConsultarHorario, settings));
        }


        [HttpDelete]
        [Route("eliminarActividad")]
        public IActionResult eliminarActividad(int idPlantilla, int idActividad, string usuario)
        {
            List<PlantillaHorario> resultadoEliminarActividad;
            resultadoEliminarActividad = _plantillaHorarioNegocio.Value.eliminarActividad(idPlantilla, idActividad, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoEliminarActividad, settings));
        }


        [HttpDelete]
        [Route("eliminarPlantilla")]
        public IActionResult eliminarPlantilla(int idPlantilla, int idActividad, string usuario)
        {
            List<PlantillaHorario> resultadoEliminarPlantilla;
            resultadoEliminarPlantilla = _plantillaHorarioNegocio.Value.eliminarPlantilla(idPlantilla, idActividad, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoEliminarPlantilla, settings));
        }

        [HttpGet]
        [Route("guardarPlantilla")]
        public IActionResult guardarPlantilla(int idPlantilla, Object[] actividades, string usuario)
        {
            List<PlantillaHorario> resultadoGuardarPlantilla;
            resultadoGuardarPlantilla = _plantillaHorarioNegocio.Value.guardarPlantilla(idPlantilla, actividades, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoGuardarPlantilla, settings));
        }
    }
        }
