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
  public  class VExploracionFisica
    {
      public static List<Entities.VistaExploracionFisica> Listar(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaExploracionFisica> lista = (from tabla in Contexto.VistaExploracionFisica.AsNoTracking()
                                                               where tabla.Número_Consulta == idConsulta
                                                               select tabla).ToList();
                return lista;
            }
        }      
    }
}
