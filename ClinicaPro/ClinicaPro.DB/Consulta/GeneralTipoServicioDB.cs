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
    public class GeneralTipoServicioDB : Abstract.IEstandar_ManejoDB<Entities.GeneralTipoServicio>
    {
        public int Agregar_Modificar(Entities.GeneralTipoServicio Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.GeneralTipoServicio Original = Contexto.GeneralTipoServicios.First(EntidadLocal => EntidadLocal.idServicio == Entidad.idServicio);
                    if (Original != null)
                    {
                        Original.IsPrecioEditable = Entidad.IsPrecioEditable;
                        Original.Nombre = Entidad.Nombre;
                        Original.Precio = Entidad.Precio;                             
                    }
                }
                else
                {
                    Contexto.GeneralTipoServicios.Add(Entidad);
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
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
       public List<Entities.GeneralTipoServicio> Listar()
        {
             ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.GeneralTipoServicio> lista = (from tabla in Contexto.GeneralTipoServicios.AsNoTracking()
                                                 select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
       public static Entities.GeneralTipoServicio ListarPorIdservicio()
       { 
         using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
         {
             return  (from n in Contexto.GeneralTipoServicios.AsNoTracking() where n.idServicio == 1  select n).FirstOrDefault();
         }
       }
    }
}
