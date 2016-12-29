using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB.Consulta
{
   public class ConsultaEstadoEmocionalDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaEstadoEmocional>
                                            ,Abstract.IListarExpediente<Entities.ConsultaEstadoEmocional>
    {
      public int Agregar_Modificar(Entities.ConsultaEstadoEmocional consultaEstadoEmocional, Boolean isModificar)
       {
           try
           {
               ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
               if (isModificar)
               {
                   Entities.ConsultaEstadoEmocional Original = Contexto.ConsultaEstadoEmocionals.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == consultaEstadoEmocional.IdConsulta);
                   if (Original != null)
                   {
                       Original.AlteracionSueño = consultaEstadoEmocional.AlteracionSueño;
                       Original.Alucinaciones = consultaEstadoEmocional.Alucinaciones;
                       Original.Debilidad = consultaEstadoEmocional.Debilidad;                       
                       Original.Depresion = consultaEstadoEmocional.Depresion;
                       Original.Desmayos = consultaEstadoEmocional.Desmayos;
                       Original.Distraido = consultaEstadoEmocional.Distraido;
                       Original.EdadAvanzada = consultaEstadoEmocional.EdadAvanzada;
                       Original.Irritabilidad = consultaEstadoEmocional.Irritabilidad;
                       Original.Normal = consultaEstadoEmocional.Normal;
                       Original.Nervioso = consultaEstadoEmocional.Nervioso;
                       Original.Otro = consultaEstadoEmocional.Otro;
                       Original.Tensión = consultaEstadoEmocional.Tensión;
                   }
                   if (Original == null  )
                   {
                       Contexto.ConsultaEstadoEmocionals.Add(consultaEstadoEmocional);
                   }
               }
               else
               {
                   Contexto.ConsultaEstadoEmocionals.Add(consultaEstadoEmocional);
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
      public bool Eliminar(int idCliente, int idTipoUsuario)
       {
           return false;
       }
      public List<Entities.ConsultaEstadoEmocional> Listar() // AsNotracking 
       {
           ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
           
               List<Entities.ConsultaEstadoEmocional> lista = (from tabla in Contexto.ConsultaEstadoEmocionals.AsNoTracking() select tabla ).ToList();
               return lista;           
       }
      public List<Entities.ConsultaEstadoEmocional> ListaPorConsulta(int idConsulta)
      {
          using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
          {
              List<Entities.ConsultaEstadoEmocional> lista = (from tabla in Contexto.ConsultaEstadoEmocionals.AsNoTracking()
                                                              where tabla.IdConsulta == idConsulta
                                                              select tabla).ToList();
              return lista;
          }
      }
    }
}
