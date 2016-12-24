using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Windows.Forms;

/*    
 Este chico es especial no tomar como referencia
 */

namespace ClinicaPro.DB.Consulta
{
    public class ConsultaGaslowDB
    {
        public Entities.GlasgowResultado getGlasgow(int IdresultadoGlasgow)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {                
                return Contexto.GlasgowResultado.AsNoTracking().Where(Entidadlocal => Entidadlocal.IdGlasgowResultado == IdresultadoGlasgow).First();
            }

        }
        /// <summary>
        ///  Para mayor facilidad se trae el Grid, no se puede crear ENtidad especifica pq la contiene Consulta
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <param name="gridGlasgow"></param>
          public static void ListaPorConsulta(int idConsulta, DataGridView gridGlasgow)
        {
               using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
               {
                   gridGlasgow.DataSource = (from tabla in Contexto.Consultas
                                             where tabla.IdConsulta == idConsulta                                             
                                             select new 
                                             {
                                               Número_Consulta = idConsulta,
                                               Resultado = tabla.GlasgowResultado.Interpretacion
                                             }                                             
                                             ).ToList();                   
               }

        }
    }
    
}
