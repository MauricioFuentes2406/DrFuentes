using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  Librerias Añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace ClinicaPro.DB.GastosIngresos
{
    public class GastosDB : Abstract.IEstandar_ManejoDB<Entities.Gasto>
    {
        public int Agregar_Modificar(Entities.Gasto Entidad, Boolean isModificar)
        {          
               using ( ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
               {
                   try
                   {
                       if (isModificar)
                       {
                           Entities.Gasto Original = Contexto.Gastos.Find(Entidad.IdGastos);
                           if (Original != null)
                           {
                               Original.CantidadGasto = Entidad.CantidadGasto;
                               Original.CategoriasGasto = Entidad.CategoriasGasto;
                               Original.DescripcionBreve = Entidad.DescripcionBreve;
                               Original.FechaDeGasto = Entidad.FechaDeGasto;
                               Original.FuenteIngreso = Entidad.FuenteIngreso;
                               Original.IdTipoUsuario = Entidad.IdTipoUsuario;
                           }                           
                       }else
                       {
                           Contexto.Gastos.Attach(Entidad);
                           Contexto.Gastos.Add(Entidad);
                       }
                       Contexto.SaveChanges();
                       return Entidad.IdGastos;
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
        }
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
        public List<Entities.Gasto> Listar()
        {
            return null;
        }
        public bool Eliminar(int idGasto, int idTipoUsuario)
        {
            return false;
        }
        /// <summary>
        /// Devuelve los gastos añadidos en el mes actual, por TipoUsuario
        /// </summary>
        /// <returns></returns>
        public int SumarGastoMesActual(int idTipoUsuario)
        {
            if (isTipoUsurioMayorCero(idTipoUsuario))
            {
                using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    try
                    {
                        return (from tabla in Contexto.Gastos
                                where tabla.IdTipoUsuario == idTipoUsuario &&
                                 (tabla.FechaDeGasto.Month == DateTime.Now.Month && tabla.FechaDeGasto.Year == DateTime.Now.Year)
                                select tabla.CantidadGasto).Sum();
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                   
                }
            }
            else return 0;
        }
        public int SumarGastoMesActual(int idTipoUsuario, Entities.FuenteIngreso fuenteIngreso)
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    return (from tabla in Contexto.Gastos
                            where tabla.IdTipoUsuario == idTipoUsuario &&
                             (tabla.FechaDeGasto.Month == DateTime.Now.Month && tabla.FechaDeGasto.Year == DateTime.Now.Year)
                             &&
                               tabla.FuenteIngreso.IdFuenteIngreso == fuenteIngreso.IdFuenteIngreso
                            select tabla.CantidadGasto).Sum();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        private bool isTipoUsurioMayorCero(int IdTipoUsuario)
        {
            if (IdTipoUsuario > 0)
                return true;
            else return false;
        }
    }
}
