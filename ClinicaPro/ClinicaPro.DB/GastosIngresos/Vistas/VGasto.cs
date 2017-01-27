using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.GastosIngresos.Vistas
{
    public class VGasto
    {
        public static List<Entities.VistaGasto> ListarTodo(int tipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaGasto> lista = (from tabla in Contexto.VistaGasto.AsNoTracking()
                                                     where tabla.IdTipoUsuario == tipoUsuario
                                                     select tabla).ToList();
                return lista;
            }
        }
        public static List<Entities.VistaGasto> ListaMesActual(int tipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaGasto> lista = (from tabla in Contexto.VistaGasto.AsNoTracking()
                                                     where tabla.IdTipoUsuario == tipoUsuario &&
                                                     tabla.FechaDeGasto.Month == DateTime.Now.Month &&
                                                     tabla.FechaDeGasto.Year == DateTime.Now.Year
                                                     orderby tabla.IdGastos descending
                                                     select tabla).ToList();
                return lista;
            }
        }
        public static List<Entities.VistaGasto> ListaPorMesEspecifico(int tipoUsuario, int Month)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaGasto> lista = (from tabla in Contexto.VistaGasto.AsNoTracking()
                                                     where tabla.IdTipoUsuario == tipoUsuario &&
                                                     tabla.FechaDeGasto.Month == Month &&
                                                     tabla.FechaDeGasto.Year == DateTime.Now.Year
                                                     select tabla).ToList();
                return lista;
            }
        }
        public static List<Entities.VistaGasto> ListaPorAño(int tipoUsuario, int Year)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaGasto> lista = (from tabla in Contexto.VistaGasto.AsNoTracking()
                                                     where tabla.IdTipoUsuario == tipoUsuario &&
                                                     tabla.FechaDeGasto.Year == Year
                                                     select tabla).ToList();
                return lista;
            }
        }
        public static List<Entities.VistaGasto> ListaPorMesYAños(int tipoUsuario, int Month, int Year)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaGasto> lista = (from tabla in Contexto.VistaGasto.AsNoTracking()
                                                     where tabla.IdTipoUsuario == tipoUsuario &&
                                                       tabla.FechaDeGasto.Month == Month &&
                                                     tabla.FechaDeGasto.Year == Year
                                                     select tabla).ToList();
                return lista;
            }
        }
    }
}
