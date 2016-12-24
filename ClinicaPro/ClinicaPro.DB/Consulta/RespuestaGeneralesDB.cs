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
   public class RespuestaGeneralesDB : Abstract.IEstandar_ManejoDB<Entities.Consulta_RespuestasGenerales>
    {
      public int Agregar_Modificar(Entities.Consulta_RespuestasGenerales Entidad, Boolean isModificar)
       {
           try
           {
               using ( ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
               { 
               if (isModificar)
               {
                   Entities.Consulta_RespuestasGenerales Original = Contexto.Consulta_RespuestasGenerales.First(EntidadLocal => EntidadLocal.idRespuestaGeneral == Entidad.idRespuestaGeneral);
                   if (Original != null)
                   {
                       Original.Nombre = Entidad.Nombre;
                   }
               }
               else
               {
                   Contexto.Consulta_RespuestasGenerales.Attach(Entidad); 
                   Contexto.Consulta_RespuestasGenerales.Add(Entidad);
               }
               Contexto.SaveChanges();
               return Entidad.idRespuestaGeneral; // Retorna 1 por que no devuelve ninguna nueva id  
               }
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
      public bool Eliminar(int idRespuestaGeneral, int idTipoUsuario)
        {
            if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(idRespuestaGeneral))
            {
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    Entities.Consulta_RespuestasGenerales rgenerales = Contexto.Consulta_RespuestasGenerales.Where(EntidadLocal => EntidadLocal.idRespuestaGeneral == idRespuestaGeneral).First();
                    Contexto.Consulta_RespuestasGenerales.Remove(rgenerales);
                    Contexto.SaveChanges();
                    return true;
                }
            }
            else return false;
        }

       public List<Entities.Consulta_RespuestasGenerales> Listar()
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.Consulta_RespuestasGenerales> lista = (from tabla in Contexto.Consulta_RespuestasGenerales.AsNoTracking()
                                                                 orderby tabla.idRespuestaGeneral
                                                                 select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
    }
}
