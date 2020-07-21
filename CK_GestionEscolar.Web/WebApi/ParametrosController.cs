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
    [Route("api/parametro")]
    public class ParametrosController : ControllerBase
    {
        public readonly Lazy<ParametrosNegocio> _parametrosNegocio;

        public ParametrosController()
        {
            _parametrosNegocio = new Lazy<ParametrosNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarParametro")]
        public IActionResult consultarParametro(string GrupoDeParametros, string Usuario)
        {
            List<Parametro> resultadoParametro;
            resultadoParametro = _parametrosNegocio.Value.consultarParametro(GrupoDeParametros, Usuario);
            return Ok(JsonConvert.SerializeObject(resultadoParametro, settings));
        }

        [HttpPost]
        [Route("guardarParametro")]
        public IActionResult guardarParametro(int idParametro, string valorParametro, string Descripcion, string Grupo, string TipoDato, string Usuario)
        {
            bool resultadoGuardarParametro;
            resultadoGuardarParametro = _parametrosNegocio.Value.guardarParametro(idParametro, valorParametro, Descripcion, Grupo, TipoDato, Usuario);
            return Ok(JsonConvert.SerializeObject(resultadoGuardarParametro, settings));
        }
    }
}
