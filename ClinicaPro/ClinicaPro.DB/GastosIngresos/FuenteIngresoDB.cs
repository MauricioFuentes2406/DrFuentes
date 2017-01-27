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
   public class FuenteIngresoDB : Abstract.IEstandar_ManejoDB<Entities.FuenteIngreso>
    {
        public int Agregar_Modificar(Entities.FuenteIngreso Entidad, Boolean isModificar)
        {
          using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto  = new Entities.ClinicaDrFuentesEntities())
          {
              try
              {
                  if (isModificar)
                  {
                      Entities.FuenteIngreso Original = Contexto.FuenteIngresoes.Find(Entidad.IdFuenteIngreso);
                      if ( Original != null)
                      {
                          Original.Nombre = Entidad.Nombre;                          
                      }
                  }
                  else
                  {
                      Contexto.FuenteIngresoes.Attach(Entidad);
                      Contexto.FuenteIngresoes.Add(Entidad);
                  }
                  Contexto.SaveChanges();
                  return Entidad.IdFuenteIngreso;
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
        public List<Entities.FuenteIngreso> Listar()
        {
            return null;
        }
        public List<Entities.FuenteIngreso> ListarPorTipoUsuario(int tipoCliente)
        {
          using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities() )
          {
              return (from tabla in Contexto.FuenteIngresoes 
                          where tabla.TipoUsuario.IdTipoUsuario == tipoCliente
                          select tabla).ToList();
          }
        }
        public bool Eliminar(int idIngreso, int idTipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                if (ValidarEliminar(Contexto, idIngreso) == false)
                {
                    try
                    {
                        Entities.FuenteIngreso ingreso = Contexto.FuenteIngresoes.Find(idIngreso);
                        Contexto.FuenteIngresoes.Remove(ingreso);
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
        /// <summary>
        /// Valida Eliminar , true hay un hallazgo , false todo bien
        /// </summary>
        /// <param name="Contexto"></param>
        /// <param name="IdFuenteIngreso"></param>
        /// <returns></returns>
        private bool ValidarEliminar(Entities.ClinicaDrFuentesEntities Contexto, int IdFuenteIngreso)
        {          
                if (Contexto.FuenteIngresoes.Find(IdFuenteIngreso) == null)
                    return true;
                if (ValidarEliminar_SiExisteLLaveForanea(IdFuenteIngreso))
                    return true;
                else return false;                        
        }
        private bool ValidarEliminar_SiExisteLLaveForanea( int IdFuenteIngreso)
        {
             int cantidadGastos = ListarGastosRelacianados(IdFuenteIngreso);
             if (cantidadGastos > 0)
            {
                MensajeSiExisteLlaveForanea(cantidadGastos);
                return true;
            }
            else
             {
                 int Ingresos = ListarIngresosRelacianados(IdFuenteIngreso);
                 if (Ingresos >0)
                 {
                     MensajeSiExisteLlaveForanea(Ingresos);
                return true;
                 }
             }
                return false;
        }
       /// <summary>
       /// Cuenta la cantidad de veces que se usa el Id en tabla Gastos
       /// </summary>
       /// <param name="IdFuenteIngreso"></param>
       /// <returns></returns>
        private int ListarGastosRelacianados(int IdFuenteIngreso)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                return Contexto.Gastos.AsNoTracking().Where
                   (EntidadLocal => EntidadLocal.FuenteIngreso.IdFuenteIngreso == IdFuenteIngreso).Count();
            }             
        }
       /// <summary>
       /// Cuenta la cantidad de veces que se usa el Id en tabla Ingresos
       /// </summary>
       /// <param name="IdFuenteIngreso"></param>
       /// <returns></returns>
        private int ListarIngresosRelacianados(int IdFuenteIngreso)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                return Contexto.Ingresos.AsNoTracking().Where
                   (EntidadLocal => EntidadLocal.FuenteIngreso.IdFuenteIngreso == IdFuenteIngreso).Count();
            }
        }
        private void MensajeSiExisteLlaveForanea(int cantidad)
        {
            String datos = String.Empty;

            System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n Cantidad Registros encontrados : "+ cantidad,
                ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
                , System.Windows.Forms.MessageBoxButtons.OK
                , System.Windows.Forms.MessageBoxIcon.Warning
                );
        }

    }
}
