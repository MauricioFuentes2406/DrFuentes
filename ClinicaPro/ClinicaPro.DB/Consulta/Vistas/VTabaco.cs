using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VTabaco
    {
       public static List<Entities.VistaTabaco> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaTabaco> lista = (from tabla in Contexto.VistaTabaco.AsNoTracking()
                                                   where tabla.Número_Consulta == idConsulta
                                                   select tabla).ToList();
               return lista;
           }
       }
    }
}
