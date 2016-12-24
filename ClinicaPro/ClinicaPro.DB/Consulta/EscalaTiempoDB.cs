using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 No LLeva Abstract de IListarExpediente<T>, pq es de Configuracion
 */
namespace ClinicaPro.DB.Consulta
{
    /// <summary>
    /// Se relaciona con la tabla AntecedentesNoPatoligicos,Consulta
    /// </summary>
   public class EscalaTiempoDB : Abstract.IEstandar_ManejoDB<Entities.EscalaTiempo>
    {
        public int Agregar_Modificar(Entities.EscalaTiempo Entidad, Boolean isModificar)
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
        public List<Entities.EscalaTiempo> Listar()
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.EscalaTiempo> lista = (from tabla in Contexto.EscalaTiempoes.AsNoTracking()
                                                     orderby tabla.IdEscalaTiempo
                                                     select tabla).ToList();
                return lista; 
            }
            
        }
    }
}
