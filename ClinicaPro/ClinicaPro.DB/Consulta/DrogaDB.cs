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
            if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(idDroga) )
            {
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    Entities.Drogas droga = Contexto.Drogas.Where(EntidadLocal => EntidadLocal.idDrogas == idDroga).First();
                    Contexto.Drogas.Remove(droga);
                    Contexto.SaveChanges();
                    return true;
                }
            }
            else { return false; }

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

    }

}
