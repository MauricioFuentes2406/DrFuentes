using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB
{
   public class BusquedaDB : Abstract.IEstandar_ManejoDB<Entities.Busqueda>
    {
       public int Agregar_Modificar(Entities.Busqueda Entidad, Boolean isModificar)
       {
           try
           {
               ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
               if (isModificar)
               {
                   Entities.Busqueda Original = Contexto.Busquedas.First(EntidadLocal => EntidadLocal.IdItem == Entidad.IdItem);
                   if (Original != null)
                   {
                       Original.BusquedaImagenes = Entidad.BusquedaImagenes;
                       Original.DescripcionAdicional = Entidad.DescripcionAdicional;
                       Original.EnfermedadRelacionada = Entidad.EnfermedadRelacionada;
                       Original.Nombre = Entidad.Nombre;
                       Original.Síntoma = Entidad.Síntoma;
                       Original.Tratamiento = Entidad.Tratamiento;
                   }
               }
               else
               {
                   Contexto.Busquedas.Add(Entidad);
               }
               Contexto.SaveChanges();
               return Entidad.IdItem;                            // Retorna id de objeto añadido a la DB  
           }
           catch (System.Data.Entity.Infrastructure.DbUpdateException Dbex)
           {
               manejaExcepcionesDB.DbUpdateException(Dbex);
               return -1;
           }
           catch (EntityException entityException)
           {
               manejaExcepcionesDB.manejaEntityException(entityException);
               return -1;
           }
           catch (NullReferenceException nullReference)
           {
               manejaExcepcionesDB.manejaNullReference(nullReference);
               return -1;
           }
           catch (Exception ex)
           {
               manejaExcepcionesDB.manejaExcepcion(ex);
               return -1;
           }
       }
       public bool Eliminar(int idCliente, int idTipoUsuario)
        {
            return false;
        }
       /// <summary>
       ///  Busca un Item por  el Nombre
       /// </summary>
       /// <remarks> CaseIgnore pq  lo hace el motor de Base de Datos
       ///           No Dispose , ya que al evaluar un condicion en el Form Busqueda Busqueda == null , ocurre una excepcion
       /// </remarks>       
       /// <param name="nombreBuscado"></param>
       /// <returns></returns>

       public Entities.Busqueda busquedaPorNombre(string nombreBuscado) // No dispose Ver Summary
       {
           ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
           Entities.Busqueda entidad = (from tabla in Contexto.Busquedas 
                                            where tabla.Nombre == nombreBuscado
                                                 select tabla).FirstOrDefault();           
           return entidad;
       }
       public List<Entities.Busqueda> Listar()
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.Busqueda> lista = (from tabla in Contexto.Busquedas.AsNoTracking()
                                                 select tabla).ToList(); 
                return lista;
            }                   
        }

       public static List<String> ListarNombres()
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<String> lista = (from tabla in Contexto.Busquedas.AsNoTracking()
                                                select tabla.Nombre).ToList();
               return lista;
           }
       }
        #region Busquedas
       /// <summary>
       /// Difiere de BusquedaPorNombre, Devuelve una lista con las entidades que contengan el clave de busqueda, no reconoce mayusculas
       /// </summary>
       /// <param name="nombre"></param>
       /// <returns></returns>       
       public List<Entities.Busqueda> ListarNombre(string nombre)
       {
           using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               
               return (from tabla in Contexto.Busquedas
                       where tabla.Nombre.Contains(nombre)
                       select tabla).ToList();
           }
       }
       public List<Entities.Busqueda> ListarSintoma(string sintoma)
       {
           using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {

               return (from tabla in Contexto.Busquedas
                       where tabla.Síntoma.Contains(sintoma)
                       select tabla).ToList();
           }
       }
       public List<Entities.Busqueda> ListarTratamiento(string tratamiento)
       {
           using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {

               return (from tabla in Contexto.Busquedas
                       where tabla.Tratamiento.Contains(tratamiento)
                       select tabla).ToList();
           }
       }
       public List<Entities.Busqueda> ListarEnfermedadRelacionada(string enfermedadRelacionada)
       {
           using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {

               return (from tabla in Contexto.Busquedas
                       where tabla.EnfermedadRelacionada.Contains(enfermedadRelacionada)
                       select tabla).ToList();
           }
       }
       public List<Entities.Busqueda> ListarDescripcion(string descripcion)
       {
           using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {

               return (from tabla in Contexto.Busquedas
                       where tabla.DescripcionAdicional.Contains(descripcion)
                       select tabla).ToList();
           }
       }    

        #endregion

    }
}
