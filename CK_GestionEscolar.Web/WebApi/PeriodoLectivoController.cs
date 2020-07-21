using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CampusKey.Negocio;
using CampusKey.Entidades.Models;
using Newtonsoft.Json;

namespace CampusKey.Web.WebApi
{
    [ApiController]
    [Route("api/periodoLectivo")]
    public class PeriodoLectivoController : ControllerBase
    {
        public readonly Lazy<PeriodoLectivoNegocio> _periodoLectivoNegocio;

        public PeriodoLectivoController()
        {
            _periodoLectivoNegocio = new Lazy<PeriodoLectivoNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarTipoAtributo")]
        public IActionResult consultarTipoAtributo()
        {
            List<TipoAtributo> resultadoConsultarTipoAtributo;
            resultadoConsultarTipoAtributo = _periodoLectivoNegocio.Value.consultarTipoAtributo();
            return Ok(JsonConvert.SerializeObject(resultadoConsultarTipoAtributo, settings));

        }

        [HttpGet]
        [Route("consultarPeriodoLectivo")]
        public IActionResult consultarPeriodoLectivo()
        {
            List<PeriodoLectivo> resultadoPeriodoLectivo;
            resultadoPeriodoLectivo = _periodoLectivoNegocio.Value.consultarPeriodoLectivo();
            return Ok(JsonConvert.SerializeObject(resultadoPeriodoLectivo, settings));

        }

        [HttpPost]
        [Route("agregarPeriodoLectivo")]
        public IActionResult agregarPeriodoLectivo([FromBody] PeriodoLectivo periodoLectivo)
        {
            bool resultadoAgregarPeriodoLectivo;
            resultadoAgregarPeriodoLectivo = _periodoLectivoNegocio.Value.agregarPeriodoLectivo(periodoLectivo);
            return Ok(JsonConvert.SerializeObject(resultadoAgregarPeriodoLectivo, settings));
        }


        [HttpGet]
        [Route("modificarPeriodoLectivo")]
        public IActionResult modificarPeriodoLectivo(PeriodoLectivo[] periodoLectivo, string usuario)
        {
            List<PeriodoLectivo> resultadoModificarPeriodoLectivo;
            resultadoModificarPeriodoLectivo = _periodoLectivoNegocio.Value.modificarPeriodoLectivo(periodoLectivo, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoModificarPeriodoLectivo, settings));
        }
    }
}