using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
/*
 No LLeva Abstract de IListarExpediente<T>, pq es de Configuracion
 */
namespace ClinicaPro.DB.Consulta
{
    public class GeneralTipoServicioDB : Abstract.IEstandar_ManejoDB<Entities.GeneralTipoServicio>
    {
        public int Agregar_Modificar(Entities.GeneralTipoServicio Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.GeneralTipoServicio Original = Contexto.GeneralTipoServicios.First(EntidadLocal => EntidadLocal.idServicio == Entidad.idServicio);
                    if (Original != null)
                    {
                        Original.IsPrecioEditable = Entidad.IsPrecioEditable;
                        Original.Nombre = Entidad.Nombre;
                        Original.Precio = Entidad.Precio;                             
                    }
                }
                else
                {
                    Contexto.GeneralTipoServicios.Add(Entidad);
                }
                Contexto.SaveChanges();
                return 1;                            // Retorna 1 por que no devuelve ninguna nueva id  
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
        public bool Eliminar(int idServicio, int idTipoUsuario)
        {                           
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    if (ValidarEliminar(Contexto, idServicio) == false)
                    {
                        Entities.GeneralTipoServicio service = Contexto.GeneralTipoServicios.Find(idServicio);
                        Contexto.GeneralTipoServicios.Remove(service);
                        Contexto.SaveChanges();
                        return true;
                    }
                    else 
                        return false; 
                }                        
        }
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
       public List<Entities.GeneralTipoServicio> Listar()
        {
             ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.GeneralTipoServicio> lista = (from tabla in Contexto.GeneralTipoServicios.AsNoTracking()
                                                 select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
       private bool ValidarEliminar(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdGeneralServicio)
       {
           if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(IdGeneralServicio))
           {
               if (Contexto.GeneralTipoServicios.Find(IdGeneralServicio) == null)
                   return true;
               if (ValidarEliminar_SiExisteLLaveForanea(IdGeneralServicio))
                   return true;
               else
                   return false;
           }
           else
               return true;
       }
       private bool ValidarEliminar_SiExisteLLaveForanea(int IdConsulta)
       {
           var list = ListasConIdServicio(IdConsulta);
           if (list.Count > 0 )
           {
               MensajeSiExisteLlaveForanea(list);
               return true;
           }
           else
               return false;
       }
          private List<int> ListasConIdServicio( int idServicio)     
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               return (from consulta in Contexto.Consultas
                       from servicios in consulta.GeneralTipoServicios
                       where servicios.idServicio == idServicio
                       select consulta.IdConsulta).ToList();
           }
       }
         // private void MensajeSiExisteLlaveForanea(List<Entities.Consulta> list)
          private void MensajeSiExisteLlaveForanea(List<int> list)
          {
              String datos = String.Empty;
              foreach (var item in list)
              {
                  datos += "\n Número Consulta:" + "  " + item;
              }
              System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n" + datos,
                  ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
                  , System.Windows.Forms.MessageBoxButtons.OK
                  , System.Windows.Forms.MessageBoxIcon.Warning
                  );
          }
    }  
}
