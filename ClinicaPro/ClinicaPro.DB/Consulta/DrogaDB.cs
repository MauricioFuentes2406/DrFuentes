using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

/*
 No LLeva Abstract de IListarExpediente<T>, pq es de Configuracion
 */
namespace ClinicaPro.DB.Consulta
{
   public class DrogaDB : Abstract.IEstandar_ManejoDB<Entities.Drogas>
    {
       public int Agregar_Modificar(Entities.Drogas Entidad, Boolean isModificar)
        {
            try
            {
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
                {
                    if (isModificar)
                    {
                        Entities.Drogas Original = Contexto.Drogas.First(EntidadLocal => EntidadLocal.idDrogas == Entidad.idDrogas);
                        if (Original != null)
                        {
                            Original.Nombre = Entidad.Nombre;
                        }
                    }
                    else
                    {
                        Contexto.Drogas.Attach(Entidad);     // Hay unos objetos que se traen de la BD como AsNotTRacking()
                        Contexto.Drogas.Add(Entidad);
                    }
                    Contexto.SaveChanges();                 
                }
                return Entidad.idDrogas;                          
            }
            catch (EntityException entityException)
            {
                manejaExcepcionesDB.manejaEntityException(entityException);
                throw entityException;
            }
            catch (NullReferenceException nullReference)
            {
                manejaExcepcionesDB.manejaNullReference(nullReference);
                throw nullReference;
            }              
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                throw;
            }

        }
       public bool Eliminar(int idDroga, int idTipoUsuario)
        {

                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    if (ValidarEliminar(Contexto, idDroga) == false)
                    {
                        try
                        {
                            Entities.Drogas droga = Contexto.Drogas.Find(idDroga);
                            Contexto.Drogas.Remove(droga);
                            Contexto.SaveChanges();
                            return true;
                        }                     
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else return false;
                }
            
          

        }

       public List<Entities.Drogas> Listar()
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.Drogas> lista = (from tabla in Contexto.Drogas.AsNoTracking()
                                           orderby tabla.idDrogas
                                                 select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
       /// <summary>
       /// Valida Eliminar , true hay un hallazgo , false todo bien
       /// </summary>
       /// <param name="Contexto"></param>
       /// <param name="idDroga"></param>
       /// <returns></returns>
       private bool ValidarEliminar(Entities.ClinicaDrFuentesEntities Contexto, int idDroga)
       {
           if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(idDroga))
           {
               if (Contexto.Drogas.Find(idDroga) == null)
                   return true;               
               if (ValidarEliminar_SiExisteLLaveForanea(Contexto, idDroga))
                   return true;
               else return false;               
           }
           else 
               return true;
       }
       private bool ValidarEliminar_SiExisteLLaveForanea(Entities.ClinicaDrFuentesEntities Contexto, int idDroga)
       {
           var list = Contexto.sp_Droga_ListarConsultasRelacionadas(idDroga).ToList();
           if (list != null)
           {
               MensajeSiExisteLlaveForanea(list);
               return true;
           }
           else
               return false;
       }
       private void MensajeSiExisteLlaveForanea(List<Entities.sp_Droga_ListarConsultasRelacionadas_Result> list)
       {
           String datos = String.Empty;
           foreach (var item in list)
           {
               datos += "\n Número Consulta:" + "  " + item.NúmeroConsulta + "  Nombre:" + "   " + item.Nombre_Cliente + "  Droga: " + item.Nombre_Droga;
           }
           System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n" + datos,
               ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
               , System.Windows.Forms.MessageBoxButtons.OK
               , System.Windows.Forms.MessageBoxIcon.Warning
               );
       }
    }
}
