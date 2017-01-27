using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.GastosIngresos.Vistas
{
   public class VIngreso
    {
       public static List<Entities.VistaIngreso> ListarTodo(int tipoUsuario)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaIngreso> lista = (from tabla in Contexto.VistaIngreso.AsNoTracking()
                                                    where tabla.IdTipoUsuario == tipoUsuario                                                     
                                                    select tabla).ToList();
               return lista;
           }
       }
       public static List<Entities.VistaIngreso> ListaMesActual(int tipoUsuario)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaIngreso> lista = (from tabla in Contexto.VistaIngreso.AsNoTracking()
                                                   where tabla.IdTipoUsuario == tipoUsuario  &&
                                                   tabla.FechaDeIngreso.Month == DateTime.Now.Month &&
                                                   tabla.FechaDeIngreso.Year == DateTime.Now.Year
                                                    orderby tabla.IdIngreso descending
                                                   select tabla).ToList();
               return lista;
           }
       }
       public static List<Entities.VistaIngreso> ListaPorMesEspecifico(int tipoUsuario, int Month)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaIngreso> lista = (from tabla in Contexto.VistaIngreso.AsNoTracking()
                                                    where tabla.IdTipoUsuario == tipoUsuario &&
                                                    tabla.FechaDeIngreso.Month == Month &&
                                                    tabla.FechaDeIngreso.Year == DateTime.Now.Year
                                                    select tabla).ToList();
               return lista;
           }
       }
       public static List<Entities.VistaIngreso> ListaPorAño(int tipoUsuario, int Year)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaIngreso> lista = (from tabla in Contexto.VistaIngreso.AsNoTracking()
                                                    where tabla.IdTipoUsuario == tipoUsuario &&
                                                    tabla.FechaDeIngreso.Year == Year
                                                    select tabla).ToList();
               return lista;
           }
       }
       public static List<Entities.VistaIngreso> ListaPorMesYAños(int tipoUsuario,int Month ,int Year)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.VistaIngreso> lista = (from tabla in Contexto.VistaIngreso.AsNoTracking()
                                                    where tabla.IdTipoUsuario == tipoUsuario &&
                                                      tabla.FechaDeIngreso.Month == Month &&
                                                    tabla.FechaDeIngreso.Year == Year
                                                    select tabla).ToList();
               return lista;
           }
       }


    }
}
