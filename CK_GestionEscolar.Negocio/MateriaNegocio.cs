using CampusKey.Datos;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusKey.Negocio
{
    public class MateriaNegocio
    {
        private static readonly Lazy<MateriaRepositorio> _materiaRepositorio = new Lazy<MateriaRepositorio>(() => new MateriaRepositorio());

        public List<Horario> consultarMaterias(string usuario)
        {
            List<Horario> resultadoGuardarHorario;
            resultadoGuardarHorario = _materiaRepositorio.Value.consultarMaterias(usuario);
            return resultadoGuardarHorario;
        }
    }
}
