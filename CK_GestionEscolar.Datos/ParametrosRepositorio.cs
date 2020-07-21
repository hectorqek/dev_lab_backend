using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CampusKey.Datos.Models;
using CampusKey.Entidades.Models;

namespace CampusKey.Datos
{
    public class ParametrosRepositorio
    {
        public ParametrosRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }

        public List<Parametro> consultarParametro(string GrupoDeParametros, string usuario)
        {
            List<Parametro> resultadoConsultarParametro;
            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoConsultarParametro = (from dp in context.Parametro
                                               select dp).Where(parametros => parametros.Grupo == GrupoDeParametros).ToList();
            }

            return resultadoConsultarParametro;
        }

        public bool guardarParametro(int IdParametro, string ValorParametro, string DescripcionParametro, string GrupoParametro, string TipoDatoParametro, string usuario)
        {
            bool resultado = true;
            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    Parametro ConsultaParametro = context.Parametro.FirstOrDefault(param => param.IdParametro == IdParametro);

                    context.Parametro.Remove(ConsultaParametro);

                    context.Add(new Parametro()
                    {
                        IdParametro = IdParametro,
                        Valor = ValorParametro,
                        Descripcion = DescripcionParametro,
                        TipoDato = TipoDatoParametro,
                        Grupo = GrupoParametro

                    });
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
