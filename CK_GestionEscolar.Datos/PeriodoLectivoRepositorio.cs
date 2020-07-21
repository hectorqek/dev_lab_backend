using System.Collections.Generic;
using CampusKey.Entidades.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CampusKey.Datos.Models
{
    public class PeriodoLectivoRepositorio
    {
        public readonly DB_CampusKey_DevContext _context;
        public PeriodoLectivoRepositorio()
        {
            DB_CampusKey_DevContext dbcontext = new DB_CampusKey_DevContext();
        }

        public List<TipoAtributo> consultarTipoAtributo()
        {
            List<TipoAtributo> resultadoTipoAtributo = new List<TipoAtributo>();


            using (var context = new DB_CampusKey_DevContext())
            {

                resultadoTipoAtributo = (from dp in context.TipoAtributo
                                           select dp).OrderByDescending(tipo => tipo.IdTipoAtributo).ToList();

            }

            return resultadoTipoAtributo;
        }

        // -- =============================================
        // -- Autor: Andrés Borbón
        // -- Fecha Creación: 10/07/2020
        // -- Descripción: Consulta los periodos lectivos definidos en el aplicativo incluyendo la informacion de los atributos segun el mismo.
        // -- =============================================
        public List<PeriodoLectivo> consultarPeriodoLectivo()
        {
            List<PeriodoLectivo> resultadoPeriodoLectivo = new List<PeriodoLectivo>();
            List<TipoAtributo> resultadoTipoAtributo = new List<TipoAtributo>();


            using (var context = new DB_CampusKey_DevContext())
            {

                resultadoPeriodoLectivo = (from dp in context.PeriodoLectivo
                                    select dp).Include("AtributoPeriodoLectivo").OrderByDescending(fecha => fecha.FechaInicio).ToList();
                    
            }

            return resultadoPeriodoLectivo;
        }
        // -- =============================================
        // -- Autor: Andrés Borbón
        // -- Fecha Creación: 10/07/2020
        // -- Descripción: Crea o actualiza el periodo lectivo junto con sus atributos extensibles y propiedades (si el id del periodo lectivo recibido como argumento del frontend es igual a 0 se crea si no se actualiza).
        // -- =============================================
        public bool agregarPeriodoLectivo(PeriodoLectivo periodoLectivo)
        {
            bool resultadoAgregarPeriodoLectivo = true;

            try
            {
                using (var context = new DB_CampusKey_DevContext())
                {
                    if (periodoLectivo.IdPeriodoLectivo != 0)
                    {
                        PeriodoLectivo ConsultaPeriodoLectivo = context.PeriodoLectivo.FirstOrDefault(periodo => periodo.IdPeriodoLectivo == periodoLectivo.IdPeriodoLectivo);
                        PeriodoLectivo ConsultaPeriodoActivo = context.PeriodoLectivo.FirstOrDefault(periodo => periodo.PeriodoActivo == true);
                        PeriodoLectivo ConsultaPeriodoAdmisiones = context.PeriodoLectivo.FirstOrDefault(periodo => periodo.PeriodoAdmisiones == true);

                        ConsultaPeriodoLectivo.Nombre = periodoLectivo.Nombre;

                        ConsultaPeriodoLectivo.FechaInicio = periodoLectivo.FechaInicio;

                        ConsultaPeriodoLectivo.FechaFin = periodoLectivo.FechaFin;

                        if (ConsultaPeriodoActivo == null)
                        {
                            ConsultaPeriodoLectivo.PeriodoActivo = periodoLectivo.PeriodoActivo;
                        }
                        else
                        {
                            if (ConsultaPeriodoLectivo.PeriodoActivo != periodoLectivo.PeriodoActivo)
                            {
                                ConsultaPeriodoActivo.PeriodoActivo = false;
                                ConsultaPeriodoLectivo.PeriodoActivo = periodoLectivo.PeriodoActivo;
                            }
                        }

                        if (ConsultaPeriodoAdmisiones == null)
                        {
                            ConsultaPeriodoLectivo.PeriodoAdmisiones = periodoLectivo.PeriodoAdmisiones;
                        }
                        else
                        {
                            if (ConsultaPeriodoLectivo.PeriodoAdmisiones != periodoLectivo.PeriodoAdmisiones)
                            {
                                ConsultaPeriodoAdmisiones.PeriodoAdmisiones = false;
                                ConsultaPeriodoLectivo.PeriodoAdmisiones = periodoLectivo.PeriodoAdmisiones;
                            }
                        }
                        

                        var ConsultaAtributoPeriodoLectivo = context.AtributoPeriodoLectivo.Where(atributo => atributo.IdPeriodoLectivo == periodoLectivo.IdPeriodoLectivo);

                        foreach (var atributo in ConsultaAtributoPeriodoLectivo)
                        {
                            foreach (var item in periodoLectivo.AtributoPeriodoLectivo)
                            {
                                if (item.IdAtributoPeriodoLectivo == atributo.IdAtributoPeriodoLectivo)
                                {
                                    atributo.Valor = item.Valor;
                                }
                            }
                        }

                        context.SaveChanges();
                    }
                    else
                    {
                        PeriodoLectivo ConsultaPeriodoLectivo = context.PeriodoLectivo.OrderByDescending(periodoLectivo => periodoLectivo.IdPeriodoLectivo).FirstOrDefault();

                        context.Add(new PeriodoLectivo() {
                            IdPeriodoLectivo = ConsultaPeriodoLectivo.IdPeriodoLectivo + 1,
                            Nombre = periodoLectivo.Nombre,
                            FechaInicio = periodoLectivo.FechaInicio,
                            FechaFin = periodoLectivo.FechaFin,
                            PeriodoActivo = false,
                            PeriodoAdmisiones = false
                    });

                        AtributoPeriodoLectivo ConsultaAtributoPeriodoLectivo = context.AtributoPeriodoLectivo.OrderByDescending(atributo => atributo.IdAtributoPeriodoLectivo).FirstOrDefault();

                        int indexIdAtributo = ConsultaAtributoPeriodoLectivo.IdAtributoPeriodoLectivo;

                        foreach (var item in periodoLectivo.AtributoPeriodoLectivo)
                        {
                            context.Add(new AtributoPeriodoLectivo()
                            {
                                IdAtributoPeriodoLectivo = indexIdAtributo + 1,
                                IdPeriodoLectivo = ConsultaPeriodoLectivo.IdPeriodoLectivo + 1,
                                IdTipoAtributo = item.IdTipoAtributo,
                                Valor = item.Valor
                            });
                            indexIdAtributo++;
                        }

                        context.SaveChanges();
                    }
                }
            }
            catch
            {
                resultadoAgregarPeriodoLectivo = false;
            }

            

            return resultadoAgregarPeriodoLectivo;
        }

        public List<PeriodoLectivo> modificarPeriodoLectivo(PeriodoLectivo[] periodoLectivo, string usuario)
        {
            List<PeriodoLectivo> resultadoModificarPeriodoLectivo = new List<PeriodoLectivo>();

            using (var context = new DB_CampusKey_DevContext())
            {
                resultadoModificarPeriodoLectivo = (from dp in context.PeriodoLectivo
                                                  select dp).ToList();
            }

            return resultadoModificarPeriodoLectivo;
        }
    }
}
