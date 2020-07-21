using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusKey.Datos
{
    public class CursoRepositorio
    {
        public readonly DB_CampusKey_DevContext _context;
        public CursoRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }

        public List<Seccion> consultarSeccion() 
        {
            List<Seccion> resultadoSeccion;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoSeccion = (from dp in context.Seccion
                                  select dp).ToList();
            }
            return resultadoSeccion;
        }
        public List<Grado> consultarGrados(Int32? idSeccion)
        {
            List<Grado> resultadoGrado;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoGrado = (from dp in context.Grado
                                  select dp).ToList();

            }
            return resultadoGrado;
        }

        public List<Curso> consultarCursos(Int32? idGrado)
        {
            List<Curso> resultadoCurso;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoCurso = (from dp in context.Curso
                                  select dp).ToList();

            }
            return resultadoCurso;
        }

        public List<Curso> generarCurso()
        {
            List<Curso> resultadoCurso;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoCurso = (from dp in context.Curso
                                  select dp).ToList();

            }
            return resultadoCurso;
        }

        public List<Curso> editarCurso(Curso[] curso, string usuario)
        {
            List<Curso> resultadoCurso;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoCurso = (from dp in context.Curso
                                  select dp).ToList();

            }
            return resultadoCurso;
        }

        public List<Curso> agregarCurso(Curso[] curso, string usuario)
        {
            List<Curso> resultadoCurso;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoCurso = (from dp in context.Curso
                                  select dp).ToList();

            }
            return resultadoCurso;
        }

        public List<Curso> modificarCurso(Curso[] curso, string usuario)
        {
            List<Curso> resultadoCurso;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoCurso = (from dp in context.Curso
                                  select dp).ToList();

            }
            return resultadoCurso;
        }

        public List<Curso> eliminarCurso(Int32 idCurso, Int32 idPeriodoLectivo, string usuario)
        {
            List<Curso> resultadoCurso;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoCurso = (from dp in context.Curso
                                  select dp).ToList();

            }
            return resultadoCurso;
        }
    }
}
