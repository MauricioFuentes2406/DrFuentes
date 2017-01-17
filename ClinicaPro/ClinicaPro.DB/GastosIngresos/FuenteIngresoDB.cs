using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.GastosIngresos
{
   public class FuenteIngresoDB : Abstract.IEstandar_ManejoDB<Entities.FuenteIngreso>
    {
        public int Agregar_Modificar(Entities.FuenteIngreso Entidad, Boolean isModificar)
        {
            return -1;
        }

        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
        public List<Entities.FuenteIngreso> Listar()
        {
            return null;
        }

        public List<Entities.FuenteIngreso> ListarPorTipoCliente(int tipoCliente)
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
            return false;
        }
    }
}
