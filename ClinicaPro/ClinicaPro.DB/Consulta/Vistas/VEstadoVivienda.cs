using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VEstadoVivienda
    {
        public static List<Entities.VistaEstadoVivienda> Listar(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaEstadoVivienda> lista = (from tabla in Contexto.VistaEstadoVivienda.AsNoTracking()
                                                               where tabla.Número_Consulta == idConsulta
                                                               select tabla).ToList();
                return lista;
            }
        }      
    }
}
