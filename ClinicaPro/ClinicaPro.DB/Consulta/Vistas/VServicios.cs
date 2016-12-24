using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VServicios
    {
       public static List<Entities.VistaServicios> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaServicios> lista = (from tabla in Contexto.VistaServicios.AsNoTracking()
                                                      where tabla.Número_Consulta == idConsulta
                                                                    select tabla).ToList();
               return lista;
           }
       }

    }
}
