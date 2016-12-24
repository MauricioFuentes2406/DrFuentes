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
            if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(idFamiliar))
            {
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    Entities.Familiar droga = Contexto.Familiars.Where(EntidadLocal => EntidadLocal.IdFamiliar == idFamiliar).First();
                    Contexto.Familiars.Remove(droga);
                    Contexto.SaveChanges();
                    return true;
                }
            }
            else { return false; }                
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
    }
}
