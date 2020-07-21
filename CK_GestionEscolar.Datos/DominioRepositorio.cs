using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CampusKey.Datos
{
    public class DominioRepositorio
    {
        public DominioRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }

        public List<Dominio> consultarDominio(string NombreDominio, string Usuario)
        {
            List<Dominio> dominioConsultado = new List<Dominio>();
            using (var context = new DB_CampusKey_DevContext())
            {
                //Lista con where segun un parametro de entrada
                dominioConsultado = (from dp in context.Dominio
                                     select dp).Where(d1 => d1.Dominio1 == NombreDominio).ToList();

            }

            return dominioConsultado;
        }

        public bool editarDominio(Dominio dominioEditar)
        {
            bool resultado = true;
            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    Dominio ConsultaDominio = context.Dominio.FirstOrDefault(dominio => dominio.IdValorDominioGrado == dominioEditar.IdValorDominioGrado);

                    ConsultaDominio.Descripcion = dominioEditar.Descripcion;

                    ConsultaDominio.Criterio = dominioEditar.Criterio;

                    ConsultaDominio.Dominio1 = dominioEditar.Dominio1;

                    ConsultaDominio.Activo = dominioEditar.Activo;

                    ConsultaDominio.Valor = dominioEditar.Valor;

                    context.Dominio.Update(ConsultaDominio);

                    context.SaveChanges();
                }
            }

            catch
            {
                resultado = false;
            }

            return resultado;
        }

        public bool crearDominio(Dominio nuevoDominio)
        {
            bool resultado = true;
            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {


                    context.Add(new Dominio()
                    {
                        IdValorDominioGrado = nuevoDominio.IdValorDominioGrado,
                        Dominio1 = nuevoDominio.Dominio1,
                        Valor = nuevoDominio.Valor,
                        Descripcion = nuevoDominio.Descripcion,
                        Criterio = nuevoDominio.Criterio,
                        Activo = nuevoDominio.Activo
                    }) ;

                    context.SaveChanges();
                }
            }

            catch
            {
                resultado = false;
            }

            return resultado;
        }
    }
}
