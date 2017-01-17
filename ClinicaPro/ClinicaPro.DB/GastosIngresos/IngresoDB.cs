using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias Añadidas 
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;


namespace ClinicaPro.DB.GastosIngresos
{
   public class IngresoDB : Abstract.IEstandar_ManejoDB<Entities.Ingreso>
    {
        public int Agregar_Modificar(Entities.Ingreso Entidad, Boolean isModificar)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    if (isModificar)
                    {
                        Entities.Ingreso Original = Contexto.Ingresos.Find(Entidad.IdIngreso);
                        if (Original != null)
                        {
                            Original.CantidadIngreso = Entidad.CantidadIngreso;
                            Original.CategoriaIngreso = Entidad.CategoriaIngreso;
                            Original.DescripcionBreve = Entidad.DescripcionBreve;
                            Original.FechaDeIngreso = Entidad.FechaDeIngreso;
                            Original.FuenteIngreso = Entidad.FuenteIngreso;
                            Original.IdTipoUsuario = Entidad.IdTipoUsuario;
                        }
                    }
                    else
                    {
                        Contexto.Ingresos.Attach(Entidad);
                        Contexto.Ingresos.Add(Entidad);
                    }
                    Contexto.SaveChanges();
                    return Entidad.IdIngreso;
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
        public List<Entities.Ingreso> Listar()
        {
            return null;
        }
        public bool Eliminar(int idIngreso, int idTipoUsuario)
        {
            return false;
        }
        /// <summary>
        /// Devuelve los gastos añadidos en el mes actual, por TipoUsuario
        /// </summary>
        /// <returns></returns>
        public int SumarIngresoMesActual(int idTipoUsuario)
        {            
                using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    try
                    {
                        return (from tabla in Contexto.Ingresos
                                where tabla.IdTipoUsuario == idTipoUsuario &&
                                 (tabla.FechaDeIngreso.Month == DateTime.Now.Month && tabla.FechaDeIngreso.Year == DateTime.Now.Year)
                                select tabla.CantidadIngreso).Sum();
                    }
                    catch (Exception)
                    {
                        return 0;                        
                    }                   
                }           
        }
        public int SumarIngresoMesActual(int idTipoUsuario, Entities.FuenteIngreso fuenteIngreso)
        {           
                using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    try
                    {
                        return (from tabla in Contexto.Ingresos
                                where tabla.IdTipoUsuario == idTipoUsuario &&
                                 (tabla.FechaDeIngreso.Month == DateTime.Now.Month && tabla.FechaDeIngreso.Year == DateTime.Now.Year)
                                 &&
                                 tabla.FuenteIngreso.IdFuenteIngreso == fuenteIngreso.IdFuenteIngreso
                                select tabla.CantidadIngreso).Sum();
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
        public void ListarUltimo10(DataGridView datagrid, int idTipoUsuario)
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    int cantidad = (from tabla in Contexto.Ingresos
                               where tabla.IdTipoUsuario == idTipoUsuario
                               orderby tabla.IdTipoUsuario descending
                               select tabla).Count();
                    if(cantidad  <= 9)
                    {
                        datagrid.DataSource = (from tabla in Contexto.Ingresos                                               
                                               where tabla.IdTipoUsuario == idTipoUsuario
                                               orderby tabla.IdTipoUsuario descending
                                               select new 
                                               {
                                               Ingreso = tabla.CantidadIngreso,
                                               Categoria = tabla.CategoriaIngreso.Nombre,
                                               Detalle = tabla.DescripcionBreve

                                               }
                                               ).ToList().GetRange(0, cantidad);
                    }else
                    {
                        datagrid.DataSource = (from tabla in Contexto.Ingresos
                                               where tabla.IdTipoUsuario == idTipoUsuario
                                               orderby tabla.IdTipoUsuario descending
                                               select new 
                                               {
                                               Ingreso = tabla.CantidadIngreso,
                                               Categoria = tabla.CategoriaIngreso.Nombre,
                                               Detalle = tabla.DescripcionBreve
                                               }
                                               ).ToList().GetRange(0, 9);
                    }
                }
                catch (Exception ex)
                {
                    manejaExcepcionesDB.manejaExcepcion(ex);
                }
            }           
        }
    }
}
