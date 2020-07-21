using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Vainilla.Datos
{
    public class EstudianteRepositorio //: IEntityTypeConfiguration<Estudiante>
    {
        public readonly DB_CampusKey_DevContext _context;

        public EstudianteRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }

        public List<Estudiante> consultarEstudiantes(Int32 IdPeriodoLectivo, Int32 IdGrado)
        {
            //se debe hacer con procedimiento almacenado y no con linq, revisar SeguridadRepositorio, el metodo consultarMenu para ver un ejemplo del uso de un procedimiento almacenado
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            using (var context = new DB_CampusKey_DevContext())
            {
                listaEstudiantes = (from dp in context.Estudiante
                                    select dp).ToList();
            }

            return listaEstudiantes;
        }


        public bool asignarEstudianteCurso(Estudiante estudianteAsignar)
        {
            bool respuesta = false;

            return respuesta;
        }

        public bool desasignarEstudianteCurso(Estudiante estudianteDesasignar)
        {
            bool respuesta = false;

            return respuesta;
        }

        public bool cambiarEstadoEstudiante(Int32 IdEstudiante, string NuevoEstado)
        {
            bool respuesta = false;

            return respuesta;
        }
        //public void Configure(EntityTypeBuilder<Estudiante> builder)
        //{

        //}

        //public List<Estudiante> buscarEstudiantes()
        //{
        //    List<Estudiante> listarEstudiante = null;
        //   // AZR_BDSQL_Vainilla_DesContext dbcontext = new AZR_BDSQL_Vainilla_DesContext();
        //listarEstudiante = (from dp in dbcontext.Estudiante
        //                   select dp).Include("Persona").Include("Persona.EstudianteCurso").ToList();
        //    return listarEstudiante;
        //}

        //public List<Estudiante> buscarEstudiantesxNombre(string parametro, int valor)
        //{
        //    List<Estudiante> listarEstudiante = null;
        //    //AZR_BDSQL_Vainilla_DesContext dbcontext = new AZR_BDSQL_Vainilla_DesContext();
        //    //listarEstudiante = (from dp in dbcontext.Estudiante.Where(x => x.Ruta == Convert.ToString(valor))
        //    //                    select dp).Include("Persona").ToList();
        //    return listarEstudiante;
        //}

        //public async Task<Persona> buscarEstudiantexCodigo(long codigoEstudiante)
        //{
        //    Persona estudiante = null;
        //    //AZR_BDSQL_Vainilla_DesContext dbcontext = new AZR_BDSQL_Vainilla_DesContext();

        //    //estudiante = await (from t1 in dbcontext.Persona
        //    //                    from t2 in dbcontext.Estudiante.Where(x => t1.TipoIdentificacion == x.TipoIdentificacion
        //    //                    && t1.NumeroIdentificacion == x.NumeroIdentificacion
        //    //                    && x.CodigoEstudiante == codigoEstudiante)
        //    //                    select t1).FirstAsync();

        //    //estudiante = await (from dp in dbcontext.Estudiante
        //    //                    where dp.CodigoEstudiante == codigoEstudiante select dp).Include("Persona").FirstAsync();
        //                        //from p in dbcontext.Persona.Where(x => dp.TipoIdentificacion == x.TipoIdentificacion && dp.NumeroIdentificacion == x.NumeroIdentificacion)
        //                        //select dp).FirstAsync();
        //    return estudiante;
        //}

        //public async Task<string> consultarParametros()
        //{
        //    // Initialization.  
        //    string lst = null;
        //    AZR_BDSQL_Vainilla_DesContext dbcontext = new AZR_BDSQL_Vainilla_DesContext();

        //    try
        //    {
        //        using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
        //        {
        //            command.CommandText = "dbo.SP_CORE_ConsultarParametros";
        //            command.CommandType = CommandType.StoredProcedure;

        //            dbcontext.Database.OpenConnection();

        //            var dataReader = command.ExecuteReader();

        //            if (dataReader.Read())
        //            {
        //                lst = dataReader.GetString(dataReader.GetOrdinal("JsonParametros"));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lst;
        //}

    }
}
