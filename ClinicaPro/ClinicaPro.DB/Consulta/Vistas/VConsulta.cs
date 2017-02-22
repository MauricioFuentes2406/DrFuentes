using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Windows.Forms;

namespace ClinicaPro.DB.Consulta.Vistas
{
   public class VConsulta
    {
        public static List<Entities.VistaConsulta> Listar()
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaConsulta> lista = (from tabla in Contexto.VistaConsulta.AsNoTracking()       
                                                      orderby tabla.Número_Consulta descending      
                                                                     select tabla).ToList();
                return lista;
            }
        }
        public static void LlenarGridSoloDatosConsulta(DataGridView dgConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                dgConsulta.DataSource = (from tabla in Contexto.VistaConsulta.AsNoTracking()
                                                      orderby tabla.Número_Consulta descending
                                                      select new 
                                                       {
                                                           Número_Consulta = tabla.Número_Consulta
                                                          , Número_Cliente = tabla.IdCliente
                                                           ,Nombre  = tabla.Nombre
                                                           ,FechaDeConsulta = tabla.FechaConsulta
                                                           ,CobroFinalDeConsulta = tabla.CobroFinalDeConsulta
                                                           ,PlanTratamiento = tabla.PlanTratamiento                                                           
                                                           ,Descuento = tabla.Descuento
                                                           ,PadecimientoActual = tabla.PadecimientoActual
                                                           ,Diagnostico = tabla.Diagnostico                                                           
                                                           ,PrimerIndicio= tabla.PrimerIndicio
                                                           ,QSucedeAcontinuacion = tabla.QSucedeAcontinuacion
                                                           ,Diagnostico_Confirmado = tabla.Diagnostico_Confirmado                                                           
                                                       }
                                                      ).ToList();
              
            }
        }

    }
}
