using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias Añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace ClinicaPro.DB.GastosIngresos
{
    public class CategoriaGastoDB : Abstract.IEstandar_ManejoDB<Entities.CategoriasGasto>
    {
        public int Agregar_Modificar(Entities.CategoriasGasto Entidad, Boolean isModificar)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    if (isModificar)
                    {
                        Entities.CategoriasGasto Original = Contexto.CategoriasGastoes.Find(Entidad.IdCategoriaGasto);
                        if (Original != null)
                        {
                            Original.Nombre = Entidad.Nombre;
                        }else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        Contexto.CategoriasGastoes.Add(Entidad);
                    }
                    Contexto.SaveChanges();
                    return Entidad.IdCategoriaGasto;
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
        public List<Entities.CategoriasGasto> Listar()
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                return (from tabla in Contexto.CategoriasGastoes select tabla).ToList();
            }
        }
        public bool Eliminar(int IdCategoriaGasto, int idTipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                if (ValidarEliminar(Contexto, IdCategoriaGasto) == false)
                {
                    try
                    {
                        Entities.CategoriasGasto categoriaIngresos = Contexto.CategoriasGastoes.Find(IdCategoriaGasto);
                        Contexto.CategoriasGastoes.Remove(categoriaIngresos);
                        Contexto.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else return false;
            }                
        }
        private bool ValidarEliminar(Entities.ClinicaDrFuentesEntities Contexto, int IdCategoriaGasto)
        {
            if (Contexto.CategoriasGastoes.Find(IdCategoriaGasto) == null)
                return true;
            if (ValidarEliminar_SiExisteLLaveForanea(IdCategoriaGasto))
                return true;
            else return false;
        }
        private bool ValidarEliminar_SiExisteLLaveForanea(int IdCategoriaGasto)
        {
            int cantidadIngresos = ListarGastosRelacianados(IdCategoriaGasto);
            if (cantidadIngresos > 0)
            {
                MensajeSiExisteLlaveForanea(cantidadIngresos);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Cuenta la cantidad de veces que se usa el Id en tabla Ingresos
        /// </summary>
        /// <param name="IdFuenteIngreso"></param>
        /// <returns></returns>
        private int ListarGastosRelacianados(int IdCategoriaGasto)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                return Contexto.Gastos.AsNoTracking().Where
                   (EntidadLocal => EntidadLocal.CategoriasGasto.IdCategoriaGasto == IdCategoriaGasto).Count();
            }
        }
        private void MensajeSiExisteLlaveForanea(int cantidad)
        {
            String datos = String.Empty;

            System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n Cantidad Registros encontrados : " + cantidad,
                ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
                , System.Windows.Forms.MessageBoxButtons.OK
                , System.Windows.Forms.MessageBoxIcon.Warning
                );
        }
    }
}
