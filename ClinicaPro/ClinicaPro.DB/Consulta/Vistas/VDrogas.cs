using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VDrogas
    {
        public static List<Entities.VistaDrogas> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaDrogas> lista = (from tabla in Contexto.VistaDrogas.AsNoTracking()
                                                       where tabla.Número_Consulta == idConsulta
                                                       select tabla).ToList();
                return lista;
            }
        }
    }
}
