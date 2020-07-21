using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusKey.Negocio
{
    public class PeriodoLectivoNegocio
    {

        private static readonly Lazy<PeriodoLectivoRepositorio> _periodoLectivoRepositorio = new Lazy<PeriodoLectivoRepositorio>(() => new PeriodoLectivoRepositorio());
        public List<TipoAtributo> consultarTipoAtributo()
        {
            List<TipoAtributo> resultadoTipoAtributo;
            resultadoTipoAtributo = _periodoLectivoRepositorio.Value.consultarTipoAtributo();
            return resultadoTipoAtributo;
        }
        public List<PeriodoLectivo> consultarPeriodoLectivo()
        {
            List<PeriodoLectivo> resultadoPeriodoLectivo;
            resultadoPeriodoLectivo = _periodoLectivoRepositorio.Value.consultarPeriodoLectivo();
            return resultadoPeriodoLectivo;
        }

        public bool agregarPeriodoLectivo(PeriodoLectivo periodoLectivo)
        {
            bool resultadoAgregarPeriodoLectivo;
            resultadoAgregarPeriodoLectivo = _periodoLectivoRepositorio.Value.agregarPeriodoLectivo(periodoLectivo);
            return resultadoAgregarPeriodoLectivo;
        }

        public List<PeriodoLectivo> modificarPeriodoLectivo(PeriodoLectivo[] periodoLectivo, string usuario)
        {
            List<PeriodoLectivo> resultadoModificarPeriodoLectivo;
            resultadoModificarPeriodoLectivo = _periodoLectivoRepositorio.Value.modificarPeriodoLectivo(periodoLectivo, usuario);
            return resultadoModificarPeriodoLectivo;
        }

    }
}
