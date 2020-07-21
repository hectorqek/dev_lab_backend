using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using Vainilla.Datos;

namespace Vainilla.Negocio
{
    public class EstudianteNegocio
    {


        //Persona estudiante;
        string parametros;
        private static readonly Lazy<EstudianteRepositorio> _estudianteRepositorio = new Lazy<EstudianteRepositorio>(() => new EstudianteRepositorio());

        public List<Estudiante> consultarEstudiantes(Int32 IdPeriodoLectivo, Int32 IdGrado)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            listaEstudiantes = _estudianteRepositorio.Value.consultarEstudiantes(IdPeriodoLectivo, IdGrado);
            return listaEstudiantes;
        }

        public bool asignarEstudianteCurso(Estudiante estudianteAsignar)
        {
            bool respuesta;
            respuesta = _estudianteRepositorio.Value.asignarEstudianteCurso(estudianteAsignar);
            return respuesta;
        }

        public bool desasignarEstudianteCurso(Estudiante estudianteDesasignar)
        {
            bool respuesta;
            respuesta = _estudianteRepositorio.Value.desasignarEstudianteCurso(estudianteDesasignar);
            return respuesta;
        }

        public bool cambiarEstadoEstudiante(Int32 IdEstudiante, string NuevoEstado)
        {
            bool respuesta;
            respuesta = _estudianteRepositorio.Value.cambiarEstadoEstudiante(IdEstudiante, NuevoEstado);
            return respuesta;
        }

        //public List<Estudiante> buscarEstudiantes(List<busquedaRequest> parametros)
        //{
        //    List<Estudiante> listaEstudiante = null;
        //    List<Estudiante> listaEstudianteResultado = new List<Estudiante>();
        //    foreach (var item in parametros)
        //    {
        //        if (item.label == "Ruta")
        //            foreach (var item1 in item.valorCampo)
        //            {
        //                listaEstudiante = _estudianteRepositorio.Value.buscarEstudiantes();
        //                foreach (var itemBruta in listaEstudiante)
        //                {
        //                    if (itemBruta.Ruta == item1)
        //                    {
        //                        var estudianteNew = new Estudiante
        //                        {
        //                            CodigoEstudiante = itemBruta.CodigoEstudiante,
        //                            TipoIdentificacion = itemBruta.TipoIdentificacion,
        //                            NumeroIdentificacion = itemBruta.NumeroIdentificacion,
        //                            FechaIngreso = itemBruta.FechaIngreso,
        //                            Casa = itemBruta.Casa,
        //                            NivelIngreso = itemBruta.NivelIngreso,
        //                            Matricula = itemBruta.Matricula,
        //                            Reintegro = itemBruta.Reintegro,
        //                            Cartera = itemBruta.Cartera,
        //                            ResponsablePago = itemBruta.ResponsablePago,
        //                            NombreResponsablePago = itemBruta.NombreResponsablePago,
        //                            UsuarioLog = itemBruta.UsuarioLog,
        //                            TipoIdentificacionAcudiente = itemBruta.TipoIdentificacionAcudiente,
        //                            NumeroIdentificacionAcudiente = itemBruta.NumeroIdentificacionAcudiente,
        //                            Ruta = itemBruta.Ruta,
        //                            Persona = itemBruta.Persona
        //                        };

        //                        listaEstudianteResultado.Add(estudianteNew);
        //                    };

        //                }
        //            }

        //        if (item.label == "Nombre Estudiante")
        //            foreach (var item1 in item.valorCampo)
        //            {
        //                listaEstudiante = _estudianteRepositorio.Value.buscarEstudiantes();
        //                foreach (var itemBruta in listaEstudiante)
        //                {
        //                    if (itemBruta.Persona.PrimerNombre == item1 || itemBruta.Persona.SegundoNombre == item1)
        //                    {
        //                        var estudianteNew = new Estudiante
        //                        {
        //                            CodigoEstudiante = itemBruta.CodigoEstudiante,
        //                            TipoIdentificacion = itemBruta.TipoIdentificacion,
        //                            NumeroIdentificacion = itemBruta.NumeroIdentificacion,
        //                            FechaIngreso = itemBruta.FechaIngreso,
        //                            Casa = itemBruta.Casa,
        //                            NivelIngreso = itemBruta.NivelIngreso,
        //                            Matricula = itemBruta.Matricula,
        //                            Reintegro = itemBruta.Reintegro,
        //                            Cartera = itemBruta.Cartera,
        //                            ResponsablePago = itemBruta.ResponsablePago,
        //                            NombreResponsablePago = itemBruta.NombreResponsablePago,
        //                            UsuarioLog = itemBruta.UsuarioLog,
        //                            TipoIdentificacionAcudiente = itemBruta.TipoIdentificacionAcudiente,
        //                            NumeroIdentificacionAcudiente = itemBruta.NumeroIdentificacionAcudiente,
        //                            Ruta = itemBruta.Ruta,
        //                            Persona = itemBruta.Persona
        //                        };

        //                        listaEstudianteResultado.Add(estudianteNew);
        //                    };

        //                }
        //            }

        //        if (item.label == "Edad estudiante")
        //            foreach (var item1 in item.valorCampo)
        //            {
        //                listaEstudiante = _estudianteRepositorio.Value.buscarEstudiantes();
        //                foreach (var itemBruta in listaEstudiante)
        //                {
        //                    int edadActual = this.CalcularEdad(itemBruta.Persona.FechaNacimiento);
        //                    if (edadActual == Convert.ToInt32(item1))
        //                    {
        //                        var estudianteNew = new Estudiante
        //                        {
        //                            CodigoEstudiante = itemBruta.CodigoEstudiante,
        //                            TipoIdentificacion = itemBruta.TipoIdentificacion,
        //                            NumeroIdentificacion = itemBruta.NumeroIdentificacion,
        //                            FechaIngreso = itemBruta.FechaIngreso,
        //                            Casa = itemBruta.Casa,
        //                            NivelIngreso = itemBruta.NivelIngreso,
        //                            Matricula = itemBruta.Matricula,
        //                            Reintegro = itemBruta.Reintegro,
        //                            Cartera = itemBruta.Cartera,
        //                            ResponsablePago = itemBruta.ResponsablePago,
        //                            NombreResponsablePago = itemBruta.NombreResponsablePago,
        //                            UsuarioLog = itemBruta.UsuarioLog,
        //                            TipoIdentificacionAcudiente = itemBruta.TipoIdentificacionAcudiente,
        //                            NumeroIdentificacionAcudiente = itemBruta.NumeroIdentificacionAcudiente,
        //                            Ruta = itemBruta.Ruta,
        //                            Persona = itemBruta.Persona
        //                        };

        //                        listaEstudianteResultado.Add(estudianteNew);
        //                    };

        //                }
        //            }

        //        if (item.label == "Grado")
        //            foreach (var item1 in item.valorCampo)
        //            {
        //                listaEstudiante = _estudianteRepositorio.Value.buscarEstudiantes();
        //                foreach (var itemBruta in listaEstudiante)
        //                {
        //                    foreach (var itemCurso in itemBruta.Persona.EstudianteCurso)
        //                    {
        //                        if (itemCurso.IdCurso == Convert.ToInt32(item1))
        //                        {
        //                            var estudianteNew = new Estudiante
        //                            {
        //                                CodigoEstudiante = itemBruta.CodigoEstudiante,
        //                                TipoIdentificacion = itemBruta.TipoIdentificacion,
        //                                NumeroIdentificacion = itemBruta.NumeroIdentificacion,
        //                                FechaIngreso = itemBruta.FechaIngreso,
        //                                Casa = itemBruta.Casa,
        //                                NivelIngreso = itemBruta.NivelIngreso,
        //                                Matricula = itemBruta.Matricula,
        //                                Reintegro = itemBruta.Reintegro,
        //                                Cartera = itemBruta.Cartera,
        //                                ResponsablePago = itemBruta.ResponsablePago,
        //                                NombreResponsablePago = itemBruta.NombreResponsablePago,
        //                                UsuarioLog = itemBruta.UsuarioLog,
        //                                TipoIdentificacionAcudiente = itemBruta.TipoIdentificacionAcudiente,
        //                                NumeroIdentificacionAcudiente = itemBruta.NumeroIdentificacionAcudiente,
        //                                Ruta = itemBruta.Ruta,
        //                                Persona = itemBruta.Persona
        //                            };

        //                            listaEstudianteResultado.Add(estudianteNew);
        //                        };
        //                    }

        //                }
        //            }

        //        if (item.label == "Curso")
        //            foreach (var item1 in item.valorCampo)
        //            {
        //                listaEstudiante = _estudianteRepositorio.Value.buscarEstudiantes();
        //                foreach (var itemBruta in listaEstudiante)
        //                {
        //                    foreach (var itemCurso in itemBruta.Persona.EstudianteCurso)
        //                    {
        //                        if (itemCurso.IdCurso == Convert.ToInt32(item1))
        //                        {
        //                            var estudianteNew = new Estudiante
        //                            {
        //                                CodigoEstudiante = itemBruta.CodigoEstudiante,
        //                                TipoIdentificacion = itemBruta.TipoIdentificacion,
        //                                NumeroIdentificacion = itemBruta.NumeroIdentificacion,
        //                                FechaIngreso = itemBruta.FechaIngreso,
        //                                Casa = itemBruta.Casa,
        //                                NivelIngreso = itemBruta.NivelIngreso,
        //                                Matricula = itemBruta.Matricula,
        //                                Reintegro = itemBruta.Reintegro,
        //                                Cartera = itemBruta.Cartera,
        //                                ResponsablePago = itemBruta.ResponsablePago,
        //                                NombreResponsablePago = itemBruta.NombreResponsablePago,
        //                                UsuarioLog = itemBruta.UsuarioLog,
        //                                TipoIdentificacionAcudiente = itemBruta.TipoIdentificacionAcudiente,
        //                                NumeroIdentificacionAcudiente = itemBruta.NumeroIdentificacionAcudiente,
        //                                Ruta = itemBruta.Ruta,
        //                                Persona = itemBruta.Persona
        //                            };

        //                            listaEstudianteResultado.Add(estudianteNew);
        //                        };
        //                    }

        //                }
        //            }
        //    }
        //    return listaEstudianteResultado;
        //}


        //public async Task<Persona> buscarEstudiantexCodigo(int codigoEstudiante)
        //{
        //    estudiante = await _estudianteRepositorio.Value.buscarEstudiantexCodigo(codigoEstudiante);
        //    return estudiante;
        //    //return new Estudiante   
        //    //{
        //    //    CodigoEstudiante = estudiante.CodigoEstudiante
        //    //    ,Persona =  estudiante.Persona
        //    //};

        //}

        //public async Task<string> consultarParametros()
        //{
        //    parametros = await _estudianteRepositorio.Value.consultarParametros();
        //    return parametros.Replace(@"\", "");
        //}

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {
                Console.WriteLine("La fecha de nacimiento es mayor que la actual.");
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }
    }
}
