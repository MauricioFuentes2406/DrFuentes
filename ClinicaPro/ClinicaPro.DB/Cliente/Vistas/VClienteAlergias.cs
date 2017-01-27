using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Cliente.Vistas
{
  public  class VClienteAlergias
    {
        public static List<Entities.VistaClienteAlergias> Listar(int idCliente)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaClienteAlergias> lista = (from tabla in Contexto.VistaClienteAlergiasSet.AsNoTracking()
                                                               where tabla.Número_Cliente == idCliente
                                                               select tabla).ToList();
                return lista;
            }
        }
        public static List<Entities.VistaClienteAlergias> Listar(List<int> list)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaClienteAlergias> lista = new List<Entities.VistaClienteAlergias>();
                foreach (var idCliente in list)
                {
                    lista.AddRange((from tabla in Contexto.VistaClienteAlergiasSet.AsNoTracking()
                                                                 where tabla.Número_Cliente == idCliente
                                                                 select tabla).ToList() );                   
                }
                return lista;
            }
        }      
    }
}
