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
       /// <summary>
       ///  Busca un Item por  el Nombre
       /// </summary>
       /// <remarks> CaseIgnore pq  lo hace el motor de Base de Datos
       ///           No Dispose , ya que al evaluar un condicion en el Form Busqueda Busqueda == null , ocurre una excepcion
       /// </remarks>
       /// 
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
                List<Entities.Busqueda> lista = (from tabla in Contexto.Busquedas
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
    }
}
