using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias AÑadias
using ClinicaPro.BL;
using System.Data.Entity.Core;
namespace ClinicaPro.DB
{
   public class FechaHoraServidorDB
    {
       public static DateTime ActualFechayHora()
       {
           DateTime fechaHoraActual;
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
           {
               var dateQuery = Contexto.Database.SqlQuery<DateTime>("SELECT getdate()");
               fechaHoraActual = dateQuery.AsEnumerable().First();
           }
           return fechaHoraActual;
       }
       public static String ActualFecha()
       {
           DateTime fechaHoraActual;
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
           {
               var dateQuery = Contexto.Database.SqlQuery<DateTime>("SELECT getdate()");
               fechaHoraActual = dateQuery.AsEnumerable().First();
           }
           return fechaHoraActual.ToShortDateString();
       }

    }
}
