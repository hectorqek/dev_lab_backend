using CampusKey.Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vainilla.Negocio;

namespace Vainilla.Web.WebApi
{

    //[Authorize]
    [ApiController]
    [Route("api/estudiante")]
    public class EstudianteController : ControllerBase
    {
        public readonly Lazy<EstudianteNegocio> _estudianteNegocio;
        //List<Estudiante> listaEstudiantes;
        //Persona estudiante;
        string parametro;
        public EstudianteController()
        {
            _estudianteNegocio = new Lazy<EstudianteNegocio>();
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet]
        [Route("consultarEstudiantes")]
        public IActionResult consultarEstudiantes(Int32 IdPeriodoLectivo, Int32 IdGrado)
        {
            List<Estudiante> resultadoConsultarEstudiantes;
            resultadoConsultarEstudiantes = _estudianteNegocio.Value.consultarEstudiantes(IdPeriodoLectivo, IdGrado);
            return Ok(JsonConvert.SerializeObject(resultadoConsultarEstudiantes, settings));
        }

        [HttpPost]
        [Route("asignarEstudianteCurso")]
        public IActionResult asignarEstudianteCurso(Estudiante estudianteAsignar)
        {
            bool respuesta;
            respuesta = _estudianteNegocio.Value.asignarEstudianteCurso(estudianteAsignar);
            return Ok(JsonConvert.SerializeObject(respuesta, settings));
        }

        [HttpPost]
        [Route("desasignarEstudianteCurso")]
        public IActionResult desasignarEstudianteCurso(Estudiante estudianteDesasignar)
        {
            bool respuesta;
            respuesta = _estudianteNegocio.Value.desasignarEstudianteCurso(estudianteDesasignar);
            return Ok(JsonConvert.SerializeObject(respuesta, settings));
        }

        [HttpPost]
        [Route("cambiarEstadoEstudiante")]
        public IActionResult cambiarEstadoEstudiante(Int32 IdEstudiante, string NuevoEstado)
        {
            bool respuesta;
            respuesta = _estudianteNegocio.Value.cambiarEstadoEstudiante(IdEstudiante, NuevoEstado);
            return Ok(JsonConvert.SerializeObject(respuesta, settings));
        }

        //[HttpGet]
        //[Route("values")]
        //public IActionResult GetAsync() => Ok("Hello, World!");

        //[HttpPost("{id}")]
        //[Route("consultarEstudiantes")]
        //public IActionResult buscarEstudiantes(List<busquedaRequest> parametros)
        //{
        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //        Formatting = Formatting.Indented
        //    };

        //    listaEstudiantes = _estudianteNegocio.Value.buscarEstudiantes(parametros);
        //    List<EstudianteViewModel> listaEst = new List<EstudianteViewModel>();
        //    foreach (var item in listaEstudiantes)
        //    {
        //       var est = new EstudianteViewModel
        //        {
        //            id = item.CodigoEstudiante,
        //            imagen = "https://amarillo.blob.core.windows.net/foto/" + item.CodigoEstudiante + ".jpg",
        //            nombre1 = item.Persona.PrimerNombre,
        //            nombre2 = item.Persona.SegundoNombre,
        //            apellido1 = item.Persona.PrimerApellido,
        //            apellido2 = item.Persona.SegundoApellido,
        //            nacimiento = item.Persona.FechaNacimiento,
        //            descripcion = item.NombreResponsablePago,
        //            tipo = null,
        //            curso = null,
        //            activo = null
        //        };

        //        listaEst.Add(est);
        //    }

        //    if (listaEst == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(JsonConvert.SerializeObject(listaEst, settings));
        //}

        //[HttpGet]
        //[Route("buscarEstudiantexCodigo")]
        //public async Task<IActionResult> buscarEstudiantexCodigo(int codigoEstudiante)
        //{
        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //        Formatting = Formatting.Indented
        //    };
        //    estudiante = await _estudianteNegocio.Value.buscarEstudiantexCodigo(codigoEstudiante);

        //    if (estudiante == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(JsonConvert.SerializeObject(estudiante, settings));
        //}

        //[HttpGet]
        //[Route("consultarParametros")]
        //public async Task<IActionResult> consultarParametros()
        //{
        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //        Formatting = Formatting.Indented
        //    };
        //    parametro = await _estudianteNegocio.Value.consultarParametros();
        //    string pp = parametro.Replace(@"\", "");
        //    var serialized = JsonConvert.DeserializeObject(pp);
        //    if (pp == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(JsonConvert.SerializeObject(serialized, settings));
        //}
    }
}