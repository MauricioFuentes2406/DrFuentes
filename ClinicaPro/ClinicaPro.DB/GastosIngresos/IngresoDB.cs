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
                        Entities.Ingreso Original = Contexto.Ingresos.Where(EntidadLocal => EntidadLocal.IdIngreso == Entidad.IdIngreso).FirstOrDefault();
                        if (Original != null)
                        {
                            Original.CantidadIngreso = Entidad.CantidadIngreso;
                            if ( Original.CategoriaIngreso.IdCategoriaIngreso != Entidad.CategoriaIngreso.IdCategoriaIngreso)
                            {
                                Original.CategoriaIngreso = Contexto.CategoriaIngresoes.Find(Entidad.CategoriaIngreso.IdCategoriaIngreso);
                            }                            
                            Original.DescripcionBreve = Entidad.DescripcionBreve;
                            Original.FechaDeIngreso = Entidad.FechaDeIngreso;
                            if (Original.FuenteIngreso.IdFuenteIngreso != Entidad.FuenteIngreso.IdFuenteIngreso)
                            {
                                Original.FuenteIngreso = Contexto.FuenteIngresoes.Find(Entidad.FuenteIngreso.IdFuenteIngreso);
                            }                                                      
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
        public bool Eliminar(List<int> listids, int idTipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    List<Entities.Ingreso> ingreso = new List<Entities.Ingreso>();
                    foreach (var id in listids)
                    {

                        ingreso.Add(Contexto.Ingresos.Where(EntidadLocal => EntidadLocal.IdIngreso == id).FirstOrDefault());
                    }

                    if (ingreso.Count > 0)
                    {
                        Contexto.Ingresos.RemoveRange(ingreso);
                        Contexto.SaveChanges();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.No_Se_Elimina_No_Se_Encontro
                                                               , "Ingreso", System.Windows.Forms.MessageBoxButtons.OK,
                                                               System.Windows.Forms.MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ClinicaPro.BL.manejaExcepcionesDB.manejaExcepcion(ex);
                    return false;
                }
            }
            return true;
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
        public List<Entities.sp_IngresoGastosUltimos_10_Result> ListarUltimos10(int idTipoUsuario)
        {
            using(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities() )
            {
                return Contexto.sp_IngresoGastosUltimos_10(idTipoUsuario).ToList();
            }
        }
        public Entities.Ingreso GetIngreso(int IdIngreso)
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            try
            {
                return Contexto.Ingresos.AsNoTracking().Where(Entidad => Entidad.IdIngreso == IdIngreso).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }            
        }
        /// <summary>
        /// Crea una Copia de un registro , pero con la Fecha Actual
        /// </summary>
        /// <param name="idGasto"></param>
        /// <returns></returns>
        public int Clone(int idGasto)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    var Entidad = Contexto.Ingresos.Where(EntidadLocal => EntidadLocal.IdIngreso == idGasto).FirstOrDefault();
                    if (Entidad != null)
                    {
                        Entities.Ingreso copia = new Entities.Ingreso();
                        copia.CantidadIngreso = Entidad.CantidadIngreso;
                        copia.CategoriaIngreso = Contexto.CategoriaIngresoes.Find(Entidad.CategoriaIngreso.IdCategoriaIngreso);
                        copia.DescripcionBreve = Entidad.DescripcionBreve;
                        copia.FechaDeIngreso = DateTime.Now;
                        copia.FuenteIngreso = Contexto.FuenteIngresoes.Find(Entidad.FuenteIngreso.IdFuenteIngreso);
                        copia.IdTipoUsuario = Entidad.IdTipoUsuario;

                        Contexto.Ingresos.Add(copia);
                        Contexto.SaveChanges();
                        return copia.IdIngreso;
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    manejaExcepcionesDB.manejaExcepcion(ex);
                    return -1;
                }
            }



        }
        public List<int> ListarAnosUsados(int tipoUsurio)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                var list = (from tabla in Contexto.Ingresos
                            where tabla.IdTipoUsuario == tipoUsurio
                            select tabla.FechaDeIngreso.Year).Distinct().ToList();
                list.Reverse();
                return list;
            }
        }
    }
}
