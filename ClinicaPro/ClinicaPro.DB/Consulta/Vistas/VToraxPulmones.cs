using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VToraxPulmones
    {
       public static List<Entities.VistaToraxPulmones> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaToraxPulmones> lista = (from tabla in Contexto.VistaToraxPulmones.AsNoTracking()
                                                                    where tabla.Número_Consulta == idConsulta
                                                                    select tabla).ToList();
               return lista;
           }
       }
    }
}
