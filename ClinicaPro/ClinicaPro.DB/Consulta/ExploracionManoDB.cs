using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 No LLeva Abstract de IListarExpediente<T>, para las Tablas Hijas idMano id Color se usa una Vista
 */
namespace ClinicaPro.DB.Consulta
{
   public class ExploracionManoDB : Abstract.IEstandar_ManejoDB<Entities.ExploracionMano>
    {
       public int Agregar_Modificar(Entities.ExploracionMano Entidad, Boolean isModificar)
       {
           return -1;
       }
       public bool Eliminar(int idCliente, int idTipoUsuario)
       {
           return false;
       }
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
       public List<Entities.ExploracionMano> Listar()
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.ExploracionMano> lista = (from tabla in Contexto.ExploracionManos.AsNoTracking()
                                            select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
    }
}
