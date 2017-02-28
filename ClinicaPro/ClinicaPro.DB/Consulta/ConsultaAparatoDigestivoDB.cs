using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
namespace ClinicaPro.DB.Consulta
{
    public class ConsultaAparatoDigestivoDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaAparatoDigestivo>
                                             , Abstract.IListarExpediente<Entities.ConsultaAparatoDigestivo>
    {
       public int Agregar_Modificar(Entities.ConsultaAparatoDigestivo aparatoDigestivo, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaAparatoDigestivo Original = Contexto.ConsultaAparatoDigestivoes.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == aparatoDigestivo.IdConsulta);
                    if (Original != null)
                    {
                        Original.Colicos = aparatoDigestivo.Colicos;
                        Original.Detalles = aparatoDigestivo.Detalles;
                        Original.Diarrea = aparatoDigestivo.Diarrea;
                        Original.Distencion = aparatoDigestivo.Distencion;
                        Original.Dolor = aparatoDigestivo.Dolor;
                        Original.Estreñimiento = aparatoDigestivo.Estreñimiento;
                        Original.FaltaApetito = aparatoDigestivo.FaltaApetito;
                        Original.Nauseas = aparatoDigestivo.Nauseas;
                        Original.Pirosis = aparatoDigestivo.Pirosis;
                        Original.Vomito = aparatoDigestivo.Vomito;
                    }
                    if (Original ==  null)
                    {
                        Contexto.ConsultaAparatoDigestivoes.Add(aparatoDigestivo);
                    }
                }
                else
                {
                    Contexto.ConsultaAparatoDigestivoes.Add(aparatoDigestivo);
                }
                Contexto.SaveChanges();
                return 1;                            // Retorna 1 por que no devuelve ninguna nueva id  
            }
            catch (EntityException entityException)
            {
                manejaExcepcionesDB.manejaEntityException(entityException);
                return -1;
            }
            catch (NullReferenceException nullReference)
            {
                manejaExcepcionesDB.manejaNullReference(nullReference);
                return -1;
            }
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                return -1;
            }
        }
       public bool Eliminar(int idCliente, int idTipoUsuario)
        {
            return false;
        }
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
       public List<Entities.ConsultaAparatoDigestivo> Listar()
        {
            return null;
        }
       public List<Entities.ConsultaAparatoDigestivo> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.ConsultaAparatoDigestivo> lista = (from tabla in Contexto.ConsultaAparatoDigestivoes.AsNoTracking()
                                                                where tabla.IdConsulta == idConsulta
                                                                select tabla).ToList();
               return lista;
           }
       }
    }
}
