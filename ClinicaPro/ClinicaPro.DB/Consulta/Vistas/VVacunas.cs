using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VVacunas
    {
        public static List<Entities.VistaVacunas> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaVacunas> lista = (from tabla in Contexto.VistaVacunas.AsNoTracking()
                                                    where tabla.Número_Consulta == idConsulta
                                                    select tabla).ToList();
                return lista;
            }
        }
    }
}
