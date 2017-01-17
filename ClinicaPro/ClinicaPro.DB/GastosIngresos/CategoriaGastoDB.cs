using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.GastosIngresos
{
    public class CategoriaGastoDB : Abstract.IEstandar_ManejoDB<Entities.CategoriasGasto>
    {
        public int Agregar_Modificar(Entities.CategoriasGasto Entidad, Boolean isModificar)
        {
            return -1;
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
        public bool Eliminar(int idIngreso, int idTipoUsuario)
        {
            return false;
        }
        
    }
}
