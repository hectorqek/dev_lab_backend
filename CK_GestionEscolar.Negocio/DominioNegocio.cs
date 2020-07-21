using CampusKey.Datos;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusKey.Negocio
{
    public class DominioNegocio
    {
        private static readonly Lazy<DominioRepositorio> _dominioRespositorio = new Lazy<DominioRepositorio>(() => new DominioRepositorio());

        public List<Dominio> consultarDominio(string NombreDominio, string Usuario)
        {
            List<Dominio> dominioConsultado = new List<Dominio>();
            dominioConsultado = _dominioRespositorio.Value.consultarDominio(NombreDominio, Usuario);

            return dominioConsultado;
        }

        public bool editarDominio(Dominio dominioEditar)
        {
            bool respuesta;
            respuesta = _dominioRespositorio.Value.editarDominio(dominioEditar);

            return respuesta;
        }

        public bool crearDominio(Dominio nuevoDominio)
        {
            bool respuesta;
            respuesta = _dominioRespositorio.Value.crearDominio(nuevoDominio);

            return respuesta;
        }
    }
}
