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
   public class FamiliarDB : Abstract.IEstandar_ManejoDB<Entities.Familiar>
    {
      public int Agregar_Modificar(Entities.Familiar Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.Familiar Original = Contexto.Familiars.First(EntidadLocal => EntidadLocal.IdFamiliar == Entidad.IdFamiliar);
                    if (Original != null)
                    {
                        Original.Nombre = Entidad.Nombre;
                    }
                }
                else
                {
                    Contexto.Familiars.Add(Entidad);
                }
                Contexto.SaveChanges();
                return Entidad.IdFamiliar;
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
      public bool Eliminar(int idFamiliar, int idTipoUsuario)
        {
          
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    if (ValidarEliminar(Contexto,idFamiliar) == false)
                    {
                        Entities.Familiar droga = Contexto.Familiars.Find(idFamiliar);
                        Contexto.Familiars.Remove(droga);
                        Contexto.SaveChanges();
                        return true;
                    }
                    else return false;
                }                         
        }
      public List<Entities.Familiar> Listar()
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            { 
              List<Entities.Familiar> lista =  (from tabla in Contexto.Familiars.AsNoTracking()
                                                orderby tabla.IdFamiliar
                                                                 select tabla).ToList();
              return lista;
            }
        }
       /// <summary>
       /// Valida Eliminar , true hay un hallazgo , false todo bien
       /// </summary>
       /// <param name="Contexto"></param>
       /// <param name="IdFamiliar"></param>
       /// <returns></returns>
       private bool ValidarEliminar(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdFamiliar)
       {
           if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(IdFamiliar))
           {
               if (Contexto.Familiars.Find(IdFamiliar) == null)
                   return true;
               if (ValidarEliminar_SiExisteLLaveForanea(Contexto, IdFamiliar))
                   return true;
               else 
                   return false;               
           }
           else           
               return true;          
       }
       private  bool ValidarEliminar_SiExisteLLaveForanea(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdFamiliar)
       {
           var list = ListasConIdFamiliar(Contexto, IdFamiliar);                                                             
           if (list.Count > 0 )
           {
               MensajeSiExisteLlaveForanea(list);
               return true;
           }
           else
               return false;
       }
       private List<Entities.AntecedenteHereditario> ListasConIdFamiliar(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdFamiliar)
       {
          return  Contexto.AntecedenteHereditarios.Where
                  (EntidadLocal => EntidadLocal.AfeccionTiroide == IdFamiliar || EntidadLocal.Asma == IdFamiliar ||EntidadLocal.AVC == IdFamiliar 
                   ||EntidadLocal.Cancer == IdFamiliar || EntidadLocal.Cardiopatía == IdFamiliar || EntidadLocal.DM == IdFamiliar 
                   || EntidadLocal.EnfermedadPulmonar == IdFamiliar || EntidadLocal.Hepatopapia == IdFamiliar || EntidadLocal.HTA == IdFamiliar 
                   || EntidadLocal.Neuropatia == IdFamiliar).ToList();
       }
       private void MensajeSiExisteLlaveForanea(List<Entities.AntecedenteHereditario> list)
       {
           String datos = String.Empty;
           foreach (var item in list)
           {
               datos += "\n Número Consulta:" + "  " + item.IdConsulta;
           }
           System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDeleteConsulta + "\n" + datos,
               ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
               , System.Windows.Forms.MessageBoxButtons.OK
               , System.Windows.Forms.MessageBoxIcon.Warning
               );
       }
    }
}
