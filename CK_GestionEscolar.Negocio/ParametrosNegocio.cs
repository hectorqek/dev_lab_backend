using CampusKey.Datos;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusKey.Negocio
{
    public class ParametrosNegocio
    {
        private static readonly Lazy<ParametrosRepositorio> _parametroRepositorio = new Lazy<ParametrosRepositorio>(() => new ParametrosRepositorio());
        public List<Parametro> consultarParametro(string GrupoDeParametros, string usuario)
        {
            List<Parametro> resultadoParametro;
            resultadoParametro = _parametroRepositorio.Value.consultarParametro(GrupoDeParametros, usuario);
            return resultadoParametro;
        }

        public bool guardarParametro(int idParametro, string valorParametro, string Descripcion, string Grupo, string TipoDato, string usuario)
        {
            bool resultadoGenerarHorario;
            resultadoGenerarHorario = _parametroRepositorio.Value.guardarParametro(idParametro, valorParametro, Descripcion, Grupo, TipoDato, usuario);
            return resultadoGenerarHorario;
        }
    }
}
