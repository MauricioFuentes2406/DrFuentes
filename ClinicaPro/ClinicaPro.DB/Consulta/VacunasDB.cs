using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Libreria añadidas 
using ClinicaPro.BL;
using System.Data.Entity.Core;
/*
 No LLeva Abstract de IListarExpediente<T>, pq es de Configuracion
 */
namespace ClinicaPro.DB.Consulta
{
  public class VacunasDB : Abstract.IEstandar_ManejoDB<Entities.Vacunas>        
    {
      public int Agregar_Modificar(Entities.Vacunas Entidad, Boolean isModificar)
        {
            try
            {
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
                {
                    if (isModificar)
                    {
                        Entities.Vacunas Original = Contexto.Vacunas.First(EntidadLocal => EntidadLocal.idVacunas == Entidad.idVacunas);
                        if (Original != null)
                        {
                            Original.Nombre = Entidad.Nombre;
                        }
                    }
                    else
                    {
                        Contexto.Vacunas.Attach(Entidad);     // Hay unos objetos que se traen de la BD como AsNotTRacking()
                        Contexto.Vacunas.Add(Entidad);
                    }
                    Contexto.SaveChanges();
                }
                return Entidad.idVacunas;
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
      public bool Eliminar(int idVacuna, int idTipoUsuario)
        {
            
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    if (ValidarEliminar(Contexto,idVacuna) == false)
                    {                    
                    Entities.Vacunas vacuna = Contexto.Vacunas.Where(EntidadLocal => EntidadLocal.idVacunas == idVacuna).First();
                    Contexto.Vacunas.Remove(vacuna);
                    Contexto.SaveChanges();                    
                    return true;
                    }
                    else return false;
                }
        }
      public List<Entities.Vacunas> Listar(int idCliente)
      {
          return null;
      }
      public List<Entities.Vacunas> Listar()
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.Vacunas> lista = (from tabla in Contexto.Vacunas.AsNoTracking()
                                            orderby tabla.idVacunas
                                           select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
      /// <summary>
      /// Valida Eliminar , true hay un hallazgo , false todo bien
      /// </summary>
      /// <param name="Contexto"></param>
      /// <param name="idVacuna"></param>
      /// <returns></returns>
      private bool ValidarEliminar(Entities.ClinicaDrFuentesEntities Contexto, int idVacuna)
      {
          if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(idVacuna))
          {
              if (Contexto.Vacunas.Find(idVacuna) == null)
                  return true;
              if (ValidarEliminar_SiExisteLLaveForanea(Contexto, idVacuna))
                  return true;
              else return false;
          }
          else
          {
              return true;
          }

      }
      private bool ValidarEliminar_SiExisteLLaveForanea(Entities.ClinicaDrFuentesEntities Contexto, int idVacuna)
      {
          List<Entities.sp_VacunaListarConsultasRelacionadas_Result> list = Contexto.sp_VacunaListarConsultasRelacionadas(idVacuna).ToList();
          if (list != null)
          {
              String datos = String.Empty;
              foreach (var item in list)
              {
                  datos += "\n Número Consulta:" + "  " + item.NúmeroConsulta + "  Nombre:" + "   " + item.Nombre_Cliente + "  Vacuna: " + item.Nombre_Vacuna;
              }
              System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n" + datos,
                  ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
                  , System.Windows.Forms.MessageBoxButtons.OK
                  , System.Windows.Forms.MessageBoxIcon.Warning
                  );
              return true;
          }
          else
              return false;
      }
    }
     
}
