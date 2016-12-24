using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace ClinicaPro.DB.Consulta
{
   public class AntecedenteVacunaDB : Abstract.IEstandar_ManejoDB<Entities.AntecedenteVacuna>
                                     ,Abstract.IListarExpediente<Entities.AntecedenteVacuna>
    {
        public int Agregar_Modificar(Entities.AntecedenteVacuna Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.AntecedenteVacuna Original = Contexto.AntecedenteVacuna.First(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        if (Original.EscalaTiempo.IdEscalaTiempo != Entidad.EscalaTiempo.IdEscalaTiempo)
                        { Original.EscalaTiempo = Contexto.EscalaTiempoes.Find(Entidad.EscalaTiempo.IdEscalaTiempo); }
                        Original.NumeroTiempo = Original.NumeroTiempo;
                        ActulizarVacunas(Contexto, Original, Entidad);
                        Original.Vacunas = Original.Vacunas;
                    }
                }
                else
                {
                    // Pero lo llama ConsultaDB entonces no es necesario dejarlo Amenos que se invok por separado                    
                    Contexto.AntecedenteVacuna.Attach(Entidad);     // Hay unos objetos que se traen de la BD como AsNotTRacking()
                    Contexto.AntecedenteVacuna.Add(Entidad);
                }
                    Contexto.SaveChanges();
                    Contexto.Dispose();
                return Entidad.idAntecedenteVacuna;                            // Retorna El id Asignado
            }
            catch (EntityException entityException)
            {
                manejaExcepcionesDB.manejaEntityException(entityException);
                throw entityException;
            }
           
            catch (NullReferenceException nullReference)
            {
                manejaExcepcionesDB.manejaNullReference(nullReference);
                throw nullReference;
            }
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                throw;
            }
        }

       public bool Eliminar(int idCliente, int idTipoUsuario)
        {
            return false;
        }       
       public List<Entities.AntecedenteVacuna> Listar()
       {
           return null;
       }
       public List<Entities.AntecedenteVacuna> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.AntecedenteVacuna> lista = (from tabla in Contexto.AntecedenteVacuna.AsNoTracking()
                                                         where tabla.IdConsulta == idConsulta
                                                         select tabla).ToList();
               return lista;
           }
       }
       private void ActulizarVacunas(Entities.ClinicaDrFuentesEntities Contexto, Entities.AntecedenteVacuna Original, Entities.AntecedenteVacuna Entidad)
       {
           // Para Actulizar Los Servicios
           List<int> removeList = new List<int>();

           //Recoge los IdServicios que Encuentrar EN Originial y No en nueva  Entidad
           foreach (Entities.Vacunas vacuna in Original.Vacunas)
           {
               if (Entidad.Vacunas.Where(x => x.idVacunas == vacuna.idVacunas).Count() > 0)
               {
                   continue;
               }
               else
               {
                   removeList.Add(vacuna.idVacunas);
               }
           }
           // Por Cada Servicio Que Esta Original y No en Entidad se Elimina
           foreach (int idServicio in removeList)
           {
               Original.Vacunas.Remove(Contexto.Vacunas.Find(idServicio));
           }
           // Por cada servicio que se encuentra en Entidad y no en Original , se añade
           foreach (var item in Entidad.Vacunas)
           {
               if (Original.Vacunas.Where(x => x.idVacunas == item.idVacunas).Count() == 0)
               {
                   Contexto.Vacunas.Attach(item);
                   Original.Vacunas.Add(item);
               }
           }
       }
    }
}
