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
    [Route("api/dominio")]
    public class DominioController : ControllerBase
    {
        public readonly Lazy<DominioNegocio> _dominioNegocio;

        public DominioController()
        {
            _dominioNegocio = new Lazy<DominioNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarDominio")]
        public IActionResult consultarDominio(string NombreDominio, string Usuario)
        {
            List<Dominio> dominioConsultado = new List<Dominio>();
            dominioConsultado = _dominioNegocio.Value.consultarDominio(NombreDominio, Usuario);
            return Ok(JsonConvert.SerializeObject(dominioConsultado, settings));
        }

        [HttpPost]
        [Route("editarDominio")]
        public IActionResult editarDominio([FromBody] Dominio dominioEditar)
        {
            bool respuesta;
            respuesta = _dominioNegocio.Value.editarDominio(dominioEditar);
            return Ok(JsonConvert.SerializeObject(respuesta, settings));
        }

        [HttpPost]
        [Route("crearDominio")]
        public IActionResult crearDominio(Dominio nuevoDominio)
        {
            bool respuesta;
            respuesta = _dominioNegocio.Value.crearDominio(nuevoDominio);
            return Ok(JsonConvert.SerializeObject(respuesta, settings));
        }
    }
}
