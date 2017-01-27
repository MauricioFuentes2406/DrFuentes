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
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    if (isModificar)
                    {
                        Entities.Gasto Original = Contexto.Gastos.Where(Entidadlocal => Entidadlocal.IdGastos == Entidad.IdGastos).FirstOrDefault();
                        if (Original != null)
                        {
                            Original.CantidadGasto = Entidad.CantidadGasto;
                            if (Original.CategoriasGasto.IdCategoriaGasto != Entidad.CategoriasGasto.IdCategoriaGasto)
                            {
                                Original.CategoriasGasto = Contexto.CategoriasGastoes.Find(Entidad.CategoriasGasto.IdCategoriaGasto);
                            }
                            Original.DescripcionBreve = Entidad.DescripcionBreve;
                            Original.FechaDeGasto = Entidad.FechaDeGasto;
                            if (Original.FuenteIngreso.IdFuenteIngreso != Entidad.FuenteIngreso.IdFuenteIngreso)
                            {
                                Original.FuenteIngreso = Contexto.FuenteIngresoes.Find(Entidad.FuenteIngreso.IdFuenteIngreso);
                            }
                        }
                    }
                    else
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
        public bool Eliminar(List<int> listids, int idTipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    List<Entities.Gasto> gasto = new List<Entities.Gasto>();
                    foreach (var id in listids)
                    {

                        gasto.Add(Contexto.Gastos.Where(EntidadLocal => EntidadLocal.IdGastos == id).FirstOrDefault());
                    }

                    if (gasto.Count > 0)
                    {
                        Contexto.Gastos.RemoveRange(gasto);
                        Contexto.SaveChanges();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.No_Se_Elimina_No_Se_Encontro
                                                               , "Gasto", System.Windows.Forms.MessageBoxButtons.OK,
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
        public List<Entities.sp_IngresoGastosUltimos_10_Result> ListarUltimos10(int idTipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                return Contexto.sp_IngresoGastosUltimos_10(idTipoUsuario).ToList();
            }
        }
        public List<int> ListarAnosUsados(int tipoUsurio)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                var list = (from tabla in Contexto.Gastos
                            where tabla.IdTipoUsuario == tipoUsurio
                            select tabla.FechaDeGasto.Year).Distinct().ToList();
                list.Reverse();
                return list;
            }
        }
        public Entities.Gasto GetGasto(int idGasto)
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            try
            {
                return Contexto.Gastos.AsNoTracking().Where(Entidad => Entidad.IdGastos == idGasto).FirstOrDefault();
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
                    var Entidad = Contexto.Gastos.Where(EntidadLocal => EntidadLocal.IdGastos == idGasto).FirstOrDefault();
                    if (Entidad != null)
                    {
                        Entities.Gasto copia = new Entities.Gasto();
                        copia.CantidadGasto = Entidad.CantidadGasto;
                        copia.CategoriasGasto = Contexto.CategoriasGastoes.Find(Entidad.CategoriasGasto.IdCategoriaGasto);
                        copia.DescripcionBreve = Entidad.DescripcionBreve;
                        copia.FechaDeGasto = DateTime.Now;
                        copia.FuenteIngreso = Contexto.FuenteIngresoes.Find(Entidad.FuenteIngreso.IdFuenteIngreso);
                        copia.IdTipoUsuario = Entidad.IdTipoUsuario;

                        Contexto.Gastos.Add(copia);
                        Contexto.SaveChanges();
                        return copia.IdGastos;
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
    }
}
