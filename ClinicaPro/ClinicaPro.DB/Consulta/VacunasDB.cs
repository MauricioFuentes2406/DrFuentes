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
            if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(idVacuna))
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    Entities.Vacunas vacuna = Contexto.Vacunas.Where(EntidadLocal => EntidadLocal.idVacunas == idVacuna).First();
                    Contexto.Vacunas.Remove(vacuna);
                    Contexto.SaveChanges();                    
                    return true;
                }
            else return false;

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
    }
}
