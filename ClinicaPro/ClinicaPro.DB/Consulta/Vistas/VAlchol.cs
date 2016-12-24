using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VAlchol
    {
        public static List<Entities.VistaAlchol> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaAlchol> lista = (from tabla in Contexto.VistaAlchol.AsNoTracking()
                                                    where tabla.Número_Consulta == idConsulta
                                                    select tabla).ToList();
                return lista;
            }
        }
    }
}
