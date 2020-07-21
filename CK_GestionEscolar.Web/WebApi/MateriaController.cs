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
    [Route("api/materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        public readonly Lazy<MateriaNegocio> _materiaNegocio;
        public MateriaController()
        {
            _materiaNegocio = new Lazy<MateriaNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarMateria")]
        public IActionResult consultarMaterias(string usuario)
        {
            List<Horario> resultadoConsultarMaterias;
            resultadoConsultarMaterias = _materiaNegocio.Value.consultarMaterias(usuario);
            return Ok(JsonConvert.SerializeObject(resultadoConsultarMaterias, settings));
        }
    }
}
