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
   public class CategoriaIngresoDB : Abstract.IEstandar_ManejoDB<Entities.CategoriaIngreso>
    {
       public int Agregar_Modificar(Entities.CategoriaIngreso Entidad, Boolean isModificar)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    if (isModificar)
                    {
                        Entities.CategoriaIngreso Original = Contexto.CategoriaIngresoes.Find(Entidad.IdCategoriaIngreso);
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
                        Contexto.CategoriaIngresoes.Add(Entidad);
                    }
                    Contexto.SaveChanges();
                    return Entidad.IdCategoriaIngreso;
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
       public List<Entities.CategoriaIngreso> Listar()
        {
            using ( Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                return (from tabla in Contexto.CategoriaIngresoes select tabla).ToList();
            }
        }
        public bool Eliminar(int IdCategoriaIngreso, int idTipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                if (ValidarEliminar(Contexto, IdCategoriaIngreso) == false)
                {
                    try
                    {
                        Entities.CategoriaIngreso categoriaIngresos = Contexto.CategoriaIngresoes.Find(IdCategoriaIngreso);
                        Contexto.CategoriaIngresoes.Remove(categoriaIngresos);
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
        private bool ValidarEliminar(Entities.ClinicaDrFuentesEntities Contexto, int IdCategoriaIngreso)
        {
            if (Contexto.CategoriaIngresoes.Find(IdCategoriaIngreso) == null)
                return true;
            if (ValidarEliminar_SiExisteLLaveForanea(IdCategoriaIngreso))
                return true;
            else return false;
        }
        private bool ValidarEliminar_SiExisteLLaveForanea(int IdCategoriaGasto)
        {
            int cantidadIngresos = ListarIngresosRelacianados(IdCategoriaGasto);
            if (cantidadIngresos > 0)
            {
                MensajeSiExisteLlaveForanea(cantidadIngresos);
                return true;
            }else           
            return false;
        }
        /// <summary>
        /// Cuenta la cantidad de veces que se usa el Id en tabla Ingresos
        /// </summary>
        /// <param name="IdFuenteIngreso"></param>
        /// <returns></returns>
        private int ListarIngresosRelacianados(int IdCategoriaGasto)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                return Contexto.Ingresos.AsNoTracking().Where
                   (EntidadLocal => EntidadLocal.CategoriaIngreso.IdCategoriaIngreso == IdCategoriaGasto).Count();
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
