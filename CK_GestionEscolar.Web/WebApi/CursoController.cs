using CampusKey.Entidades.Models;
using CampusKey.Negocio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CampusKey.Web.WebApi
{
    [Route("api/curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        public readonly Lazy<CursoNegocio> _cursoNegocio;
        public CursoController()
        {
            _cursoNegocio = new Lazy<CursoNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarSeccion")]
        public IActionResult consultarSeccion()
        {
            List<Seccion> resultadoSeccion;
            resultadoSeccion = _cursoNegocio.Value.consultarSeccion();
            return Ok(JsonConvert.SerializeObject(resultadoSeccion, settings));
        }

        [HttpGet]
        [Route("consultarGrados")]
        public IActionResult consultarGrados(int? periodoLectivo)
        {
            List<Grado> resultadoGrados;
            resultadoGrados = _cursoNegocio.Value.consultarGrados(periodoLectivo);
            return Ok(JsonConvert.SerializeObject(resultadoGrados, settings));
        }

        [HttpGet]
        [Route("consultarCursos")]
        public IActionResult consultarCursos(int? periodoLectivo)
        {
            List<Curso> resultadoCursos;
            resultadoCursos = _cursoNegocio.Value.consultarCursos(periodoLectivo);
            return Ok(JsonConvert.SerializeObject(resultadoCursos, settings));
        }

        [HttpGet]
        [Route("generarCursos")]
        public IActionResult generarCursos()
        {
            List<Curso> resultadoCursos;
            resultadoCursos = _cursoNegocio.Value.generarCurso();
            return Ok(JsonConvert.SerializeObject(resultadoCursos, settings));
        }

        [HttpPut]
        [Route("agregarCurso")]
        public IActionResult agregarCurso(Curso[] curso, string usuario)
        {
            List<Curso> resultadoCursos;
            resultadoCursos = _cursoNegocio.Value.agregarCurso(curso, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoCursos, settings));
        }

        [HttpPut]
        [Route("modificarCurso")]
        public IActionResult modificarCurso(Curso[] curso, string usuario)
        {
            List<Curso> resultadoCursos;
            resultadoCursos = _cursoNegocio.Value.modificarCurso(curso, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoCursos, settings));
        }

        [HttpPut]
        [Route("eliminarCurso")]
        public IActionResult eliminarCurso(Int32 idCurso, Int32 idPeriodoLectivo, string usuario)
        {
            List<Curso> resultadoCursos;
            resultadoCursos = _cursoNegocio.Value.eliminarCurso(idCurso, idPeriodoLectivo, usuario);
            return Ok(JsonConvert.SerializeObject(resultadoCursos, settings));
        }
    }
}