using CampusKey.Datos;
using CampusKey.Entidades.Models;
using CampusKey.Entidades.Partial.Resultado;
using System;
using System.Collections.Generic;

namespace CampusKey.Negocio
{
    public class SeguridadNegocio
    {
        private static readonly Lazy<SeguridadRepositorio> _estudianteRepositorio = new Lazy<SeguridadRepositorio>(() => new SeguridadRepositorio());

        public List<Rol> consultarRoles(){
            List<Rol> listaRol = null;
            listaRol = _estudianteRepositorio.Value.consultarRoles();
            return listaRol;
        }

        public List<Usuario> consultarUsuarios(string busqueda)
        {
            List<Usuario> listaUsuarios = null;
            listaUsuarios = _estudianteRepositorio.Value.consultarUsuarios(busqueda);
            return listaUsuarios;
        }

        public List<Funcionalidad> consultarMenu(string usuario, int idRol)
        {
            List<Funcionalidad> listaUsuarios = null;
            listaUsuarios = _estudianteRepositorio.Value.consultarMenu(usuario,idRol);
            return listaUsuarios;
        }

        public bool guardarAsignacionRolUsuario(string idUsuario, int idRol)
        {
            bool resultado;
            resultado = _estudianteRepositorio.Value.guardarAsignacionRolUsuario(idUsuario, idRol);
            return resultado;
        }

        public bool eliminarAsignacionRolUsuario(string idUsuario, int idRol)
        {
            bool resultado;
            resultado = _estudianteRepositorio.Value.eliminarAsignacionRolUsuario(idUsuario, idRol);
            return resultado;
        }

        public List<resultadoAsignacionRolUsuario> consultarAsignacionRolUsuario(string idUsuario, int? idRol)
        {
            List<resultadoAsignacionRolUsuario> resultado;
            resultado = _estudianteRepositorio.Value.consultarAsignacionRolUsuario(idUsuario, idRol);
            return resultado;
        }

        public bool actualizarOpcionRol(string idUsuario, int idRol)
        {
            bool resultado;
            resultado = _estudianteRepositorio.Value.guardarAsignacionRolUsuario(idUsuario, idRol);
            return resultado;
        }

        public bool actualizarOpcionRol(string usuario, int idRol, int idFuncionalidad, int permiso)
        {
            bool resultado;
            resultado = _estudianteRepositorio.Value.actualizarOpcionRol(idRol, idFuncionalidad, permiso);
            return resultado;
        }
    }
}
