using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;


namespace ClinicaPro.DB.Consulta 
{
   public class ConsultaAbdomenDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaAbdomen>
                                   ,Abstract.IListarExpediente<Entities.ConsultaAbdomen>
    {
      public int Agregar_Modificar(Entities.ConsultaAbdomen Entidad, Boolean isModificar)
    {
         try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaAbdomen Original = Contexto.ConsultaAbdomen.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {                        
                        Original.Ascititis = Entidad.Ascititis;
                        Original.Recto = Entidad.Recto;
                        Original.Riñon = Entidad.Riñon;
                        Original.TamanoOrganos = Entidad.TamanoOrganos;
                        Original.Vaso = Entidad.Vaso;
                    }if( Original == null )
                    {
                        Contexto.ConsultaAbdomen.Add(Entidad);
                    }
                }
                else
                {
                    Contexto.ConsultaAbdomen.Add(Entidad);
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
       public List<Entities.ConsultaAbdomen> Listar()
        {
            return null;
        }
       public List<Entities.ConsultaAbdomen> ListaPorConsulta(int idConsulta)
      {
          using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
          {
              List<Entities.ConsultaAbdomen> lista = (from tabla in Contexto.ConsultaAbdomen.AsNoTracking()
                                                      where tabla.IdConsulta == idConsulta
                                                      select tabla).ToList();
              return lista;
          }
      }
    }
}
