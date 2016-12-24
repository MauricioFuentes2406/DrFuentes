using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VAntecedenteHereditario
    {
          public static List<Entities.VistaAntecedenteHereditario> ListaPorConsulta (int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaAntecedenteHereditario> lista = (from tabla in Contexto.VistaAntecedenteHereditario.AsNoTracking()
                                                                     where tabla.Número_Consulta == idConsulta
                                                                     select tabla).ToList();
                return lista;
            }
        }
    }
    
}
