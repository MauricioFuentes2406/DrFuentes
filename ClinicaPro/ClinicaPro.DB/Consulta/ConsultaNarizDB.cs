using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias Añadidas
using ClinicaPro.Entities;
using ClinicaPro.BL;
using System.Data.Entity.Core;
namespace ClinicaPro.DB.Consulta
{
   public class ConsultaNarizDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaNariz>
                                 ,Abstract.IListarExpediente<Entities.ConsultaNariz>
    {
       public int Agregar_Modificar(ConsultaNariz consultaNariz, Boolean isModificar)
       {
           try
           {
               ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
               if (isModificar)
               {
                   Entities.ConsultaNariz Original = Contexto.ConsultaNarizs.First(EntidadLocal => EntidadLocal.IdConsulta == consultaNariz.IdConsulta);
                   if (Original != null)
                   {
                       Original.Epitaxis = consultaNariz.Epitaxis;
                       Original.ResfrioFrecuente = consultaNariz.ResfrioFrecuente;
                       Original.Rinorrea = consultaNariz.Rinorrea;
                       Original.Sinusitis = consultaNariz.Sinusitis;
                   }
               }
               else
               {
                   Contexto.ConsultaNarizs.Add(consultaNariz);
               }
               Contexto.SaveChanges();
               return 1;                           // Retorna 1 por que no devuelve ninguna nueva id
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
               throw ex;
           }
           
       }
       public bool Eliminar(int idCliente, int idTipoUsuario)
       {
           return false;
       }
      public List<ConsultaNariz> Listar()
       {
           return null;
       }
      public List<ConsultaNariz> ListaPorConsulta(int idConsulta)
      {
          using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
          {
              List<ConsultaNariz> lista = (from tabla in Contexto.ConsultaNarizs.AsNoTracking()
                                           where tabla.IdConsulta == idConsulta
                                           select tabla).ToList();
              return lista;
          }
      }
    }
}
