using CampusKey.Datos;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusKey.Negocio
{
    public class CursoNegocio
    {
        private static readonly Lazy<CursoRepositorio> _cursoRepositorio = new Lazy<CursoRepositorio>(() => new CursoRepositorio());

        public List<Seccion> consultarSeccion()
        {
            List<Seccion> resultadoSeccion;
            resultadoSeccion = _cursoRepositorio.Value.consultarSeccion();
            return resultadoSeccion;
        }

        public List<Grado> consultarGrados(Int32? idSeccion)
        {
            List<Grado> resultadoGrado;
            resultadoGrado = _cursoRepositorio.Value.consultarGrados(idSeccion);
            return resultadoGrado;
        }

        public List<Curso> consultarCursos(Int32? idGrado)
        {
            List<Curso> resultadoCurso;
            resultadoCurso = _cursoRepositorio.Value.consultarCursos(idGrado);
            return resultadoCurso;
        }

        public List<Curso> generarCurso()
        {
            List<Curso> resultadoCurso;
            resultadoCurso = _cursoRepositorio.Value.generarCurso();
            return resultadoCurso;
        }

        public List<Curso> agregarCurso(Curso[] curso, string usuario)
        {
            List<Curso> resultadoCurso;
            resultadoCurso = _cursoRepositorio.Value.agregarCurso(curso, usuario);
            return resultadoCurso;
        }

        public List<Curso> modificarCurso(Curso[] curso, string usuario)
        {
            List<Curso> resultadoCurso;
            resultadoCurso = _cursoRepositorio.Value.modificarCurso(curso, usuario);
            return resultadoCurso;
        }

        public List<Curso> eliminarCurso(Int32 idCurso, Int32 idPeriodoLectivo, string usuario)
        {
            List<Curso> resultadoCurso;
            resultadoCurso = _cursoRepositorio.Value.eliminarCurso(idCurso, idPeriodoLectivo, usuario);
            return resultadoCurso;
        }
    }
}
