using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using CampusKey.Entidades.Partial.Resultado;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CampusKey.Datos
{
    public class SeguridadRepositorio
    {
        public readonly DB_CampusKey_DevContext _context;
        public SeguridadRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }
        public List<Rol> consultarRoles()
        {
            List<string> fields = new List<string>();
            // my 'columns'
            fields.Add("this_thing");
            fields.Add("that_thing");
            fields.Add("the_other");

            dynamic exo = new System.Dynamic.ExpandoObject();

            foreach (string field in fields)
            {
                ((IDictionary<String, Object>)exo).Add(field, field + "_data");
            }

            // output - from Json.Net NuGet package
            textBox1.Text = Newtonsoft.Json.JsonConvert.SerializeObject(exo);
        }

        public List<Usuario> consultarUsuarios(string busqueda)
        {
            List<Usuario> listaUsuario;
            using (var context = new DB_CampusKey_DevContext())
            {
                listaUsuario = (from p in context.Usuario
                                select p).ToList();
            }
            return listaUsuario;

        }

        public List<Funcionalidad> consultarMenu(string usuario, int idRol)
        {

            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        var idRolParam = new SqlParameter("@iP_IdRol", idRol);
                        var usuarioParam = new SqlParameter("@sP_Usuario", usuario);
                        command.CommandText = "dbo.SP_Seguridad_ConsultarMenu";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(idRolParam);
                        command.Parameters.Add(usuarioParam);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        List<Funcionalidad> listaFuncionalidad = new List<Funcionalidad>();
                        while (dataReader.Read())
                        {
                            listaFuncionalidad.Add(new Funcionalidad()
                            {
                                IdFuncionalidad = (int)dataReader["idFuncionalidad"],
                                Nombre = (string)dataReader["nombre"],
                                Url = (string)(dataReader["url"] == DBNull.Value ? string.Empty : dataReader["url"]),
                                Padre = (int?)(dataReader["padre"] == DBNull.Value ? null : (int?)dataReader["padre"]),
                                Nivel = (int?)(dataReader["nivel"] == DBNull.Value ? null : (int?)dataReader["nivel"]),
                                SiguienteNivel = (int?)(dataReader["siguienteNivel"] == DBNull.Value ? null : (int?)dataReader["siguienteNivel"]),
                                Tipo = (string)(dataReader["tipo"] == DBNull.Value ? string.Empty : dataReader["tipo"]),
                                Orden = (int?)(dataReader["orden"] == DBNull.Value ? null : (int?)dataReader["orden"]),
                                EtiquetaHtml = (string)(dataReader["etiquetaHtml"] == DBNull.Value ? string.Empty : dataReader["etiquetaHtml"]),
                                PermisoRol = (int?)(dataReader["permisoRol"] == DBNull.Value ? null : dataReader["permisoRol"]),
                                Imagen = (string)(dataReader["Imagen"] == DBNull.Value ? string.Empty : dataReader["Imagen"]),
                            });
                        }

                        return listaFuncionalidad;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool guardarAsignacionRolUsuario(string idUsuario, int idRol)
        {
            bool resultado = true;
            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    context.Add(new AsignacionRolUsuario()
                    {
                        IdUsuario = idUsuario,
                        IdRol = idRol
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;

        }

        public bool eliminarAsignacionRolUsuario(string idUsuario, int idRol)
        {
            bool resultado = true;
            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    context.Remove(new AsignacionRolUsuario()
                    {
                        IdUsuario = idUsuario,
                        IdRol = idRol
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;

        }

        public List<resultadoAsignacionRolUsuario> consultarAsignacionRolUsuario(string idUsuario, int? idRol)
        {
            List<resultadoAsignacionRolUsuario> resultado = new List<resultadoAsignacionRolUsuario>();
            
            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    List<resultadoAsignacionRolUsuario> result = new List<resultadoAsignacionRolUsuario>();
                    if (idUsuario != null && idRol == null)
                    {
                        //var x = from t in context.AsignacionRolUsuario.Where(rol => rol.IdUsuario == idUsuario);

                        //result = from t in context.AsignacionRolUsuario.Where(rol => rol.IdUsuario == idUsuario);

                        result = (from t in context.AsignacionRolUsuario
                                  join r in context.Rol
                                  on t.IdRol equals r.IdRol
                                  join us in context.Usuario
                                  on t.IdUsuario equals us.IdUsuario
                                  select new resultadoAsignacionRolUsuario { IdUsuario = us.IdUsuario, IdRol = r.IdRol, Nombre = r.Nombre, DisplayName = us.DisplayName }).Where(rol => rol.IdUsuario == idUsuario).OrderBy(rol => rol.Nombre).ToList();
                    }
                    if(idUsuario == null && idRol != null)
                    {
                        result = (from t in context.AsignacionRolUsuario
                                  join r in context.Rol
                                  on t.IdRol equals r.IdRol
                                  join us in context.Usuario
                                  on t.IdUsuario equals us.IdUsuario
                                  select new resultadoAsignacionRolUsuario { IdUsuario = us.IdUsuario, IdRol = r.IdRol, Nombre = r.Nombre, DisplayName = us.DisplayName }).Where(rol => rol.IdRol == idRol).OrderBy(rol => rol.DisplayName).ThenBy(rol => rol.Nombre).ToList();
                    }
                    if (idUsuario != null && idRol != null)
                    {
                        result = (from t in context.AsignacionRolUsuario
                                  join r in context.Rol
                                  on t.IdRol equals r.IdRol
                                  join us in context.Usuario
                                  on t.IdUsuario equals us.IdUsuario
                                  select new resultadoAsignacionRolUsuario { IdUsuario = us.IdUsuario, IdRol = r.IdRol, Nombre = r.Nombre, DisplayName = us.DisplayName }).Where(rol => rol.IdRol == idRol && rol.IdUsuario == idUsuario).ToList(); //.Where(x => x.IdRol == idRol && x.IdUsuario).ToList();
                    }

                    resultadoAsignacionRolUsuario nuevo;
                    foreach (var item in result)
                    {
                        nuevo = new resultadoAsignacionRolUsuario
                        {
                            IdUsuario = item.IdUsuario,
                            IdRol = item.IdRol,
                            Nombre = item.Nombre,
                            DisplayName = item.DisplayName
                        };

                        resultado.Add(nuevo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return resultado;
        }

        public bool actualizarOpcionRol(int idRol, int idFuncionalidad, int permiso)
        {
            bool resultado = true;
            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    OpcionesRol opcionRol = context.OpcionesRol.FirstOrDefault(c => c.IdRol == idRol && c.IdFuncionalidad == idFuncionalidad);
                    if (opcionRol == null)
                    {
                        context.Add(new OpcionesRol()
                        {
                            IdRol = idRol,
                            IdFuncionalidad = idFuncionalidad,
                            Permiso = Convert.ToString(permiso)
                        });
                    }
                    else
                    {
                        context.OpcionesRol.Remove(opcionRol);
                        //context.Entry(opcionRol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;

        }
    }
}
