using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusKey.Entidades.Models;
using CampusKey.Entidades.Partial.Resultado;
using CampusKey.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CampusKey.Web.WebApi
{
    [Route("api/seguridad")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        public readonly Lazy<SeguridadNegocio> _rolNegocio;
        List<Usuario> listaUsuario;
        
     
        List<resultadoAsignacionRolUsuario> consultaAsignacionRolUsuario;
        public SeguridadController()
        {
            _rolNegocio = new Lazy<SeguridadNegocio>();
        }

        [HttpGet]
        [Route("consultarRoles")]
        public IActionResult consultarRoles()
        {
            List<Rol> listaRol;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            listaRol = _rolNegocio.Value.consultarRoles();
            if (listaRol == null)
            {
                Response.StatusCode = 200;
                return Content(JsonConvert.SerializeObject(listaRol, settings));
            }
            return Ok(JsonConvert.SerializeObject(listaRol, settings));
        }



        [HttpGet]
        [Route("consultarUsuarios")]
        public IActionResult consultarUsuarios(string busqueda)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            listaUsuario = _rolNegocio.Value.consultarUsuarios(busqueda);
            if (listaUsuario == null)
            {
                Response.StatusCode = 200;
                return Content(JsonConvert.SerializeObject(listaUsuario, settings));
            }
            Response.StatusCode = 200;
            return Ok(JsonConvert.SerializeObject(listaUsuario, settings));
        }

        [HttpGet]
        [Route("consultarMenu")]
        public IActionResult consultarMenu(string usuario, int idRol)
        {
            List<Funcionalidad> listaFuncionalidad;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            listaFuncionalidad = _rolNegocio.Value.consultarMenu(usuario, idRol);
            if (listaFuncionalidad == null)
            {
                Response.StatusCode = 200;
                return Content(JsonConvert.SerializeObject(listaFuncionalidad, settings));
            }
            return Ok(JsonConvert.SerializeObject(listaFuncionalidad, settings));
        }


        [HttpPost]
        [Route("guardarAsignacionRolUsuario")]
        public IActionResult guardarAsignacionRolUsuario(string idUsuario, int idRol)
        {
            bool resultadoAsignacionRolUsuario;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            resultadoAsignacionRolUsuario = _rolNegocio.Value.guardarAsignacionRolUsuario(idUsuario, idRol);
            if (resultadoAsignacionRolUsuario == null)
            {
                Response.StatusCode = 200;
                return Content(JsonConvert.SerializeObject(resultadoAsignacionRolUsuario, settings));
            }
            return Ok(JsonConvert.SerializeObject(resultadoAsignacionRolUsuario, settings));
        }

        [HttpDelete]
        [Route("eliminarAsignacionRolUsuario")]
        public IActionResult eliminarAsignacionRolUsuario(string idUsuario, int idRol)
        {
            bool resultadoAsignacionRolUsuario;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            resultadoAsignacionRolUsuario = _rolNegocio.Value.eliminarAsignacionRolUsuario(idUsuario, idRol);
            if (resultadoAsignacionRolUsuario == null)
            {
                Response.StatusCode = 200;
                return Content(JsonConvert.SerializeObject(resultadoAsignacionRolUsuario, settings));
            }
            return Ok(JsonConvert.SerializeObject(resultadoAsignacionRolUsuario, settings));
        }

        [HttpGet]
        [Route("consultarAsignacionRolUsuario")]
        public IActionResult consultarAsignacionRolUsuario(string idUsuario, int? idRol)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            consultaAsignacionRolUsuario = _rolNegocio.Value.consultarAsignacionRolUsuario(idUsuario, idRol);
            if (consultaAsignacionRolUsuario == null)
            {
                Response.StatusCode = 200;
                return Content(JsonConvert.SerializeObject(consultaAsignacionRolUsuario, settings));
            }
            return Ok(JsonConvert.SerializeObject(consultaAsignacionRolUsuario, settings));
        }



        [HttpPut]
        [Route("actualizarOpcionRol")]
        public IActionResult actualizarOpcionRol(string usuario, int idRol, int idFuncionalidad, int permiso)
        {
            bool resultadoAsignacionRolUsuario;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            resultadoAsignacionRolUsuario = _rolNegocio.Value.actualizarOpcionRol(usuario, idRol, idFuncionalidad, permiso);
            if (resultadoAsignacionRolUsuario == null)
            {
                Response.StatusCode = 200;
                return Content(JsonConvert.SerializeObject(resultadoAsignacionRolUsuario, settings));
            }
            return Ok(JsonConvert.SerializeObject(resultadoAsignacionRolUsuario, settings));
        }


    }
}