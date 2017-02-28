using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;


namespace ClinicaPro.DB.Consulta
{
    public class AntecedenteDrogaDB : Abstract.IEstandar_ManejoDB<Entities.AntecedenteDrogra>
                                      ,Abstract.IListarExpediente<Entities.AntecedenteDrogra>
    {

        public int Agregar_Modificar(Entities.AntecedenteDrogra Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.AntecedenteDrogra Original = Contexto.AntecedenteDrogra.FirstOrDefault(EntidadLocal => EntidadLocal.idConsulta == Entidad.idConsulta);
                    if (Original != null)
                    {
                        ActulizarDrogas(Contexto, Original, Entidad);
                        if (Original.EscalaTiempo.IdEscalaTiempo != Entidad.EscalaTiempo.IdEscalaTiempo)
                        { Original.EscalaTiempo = Contexto.EscalaTiempoes.Find(Entidad.EscalaTiempo.IdEscalaTiempo); }
                        Original.NumeroTiempo = Entidad.NumeroTiempo;
                    }
                    if(Original == null)
                    {
                        // Es modificar pero no existia Lista Drogas Antes => Agrega
                        Contexto.AntecedenteDrogra.Attach(Entidad);    // Hay unos objetos que se traen de la BD como AsNotTRacking()                   
                        Contexto.AntecedenteDrogra.Add(Entidad);
                    }
                }
                else
                {// Pero lo llama ConsultaDB entonces no es necesario dejarlo Amenos que se invok por separado
                    Contexto.AntecedenteDrogra.Attach(Entidad);    // Hay unos objetos que se traen de la BD como AsNotTRacking()                   
                    Contexto.AntecedenteDrogra.Add(Entidad);
                }
                Contexto.SaveChanges();
                Contexto.Dispose();
                return Entidad.idAntecedenteDroga;
            }
            catch (EntityException entityException)
            {
                manejaExcepcionesDB.manejaEntityException(entityException);
                return -1;
            }
            catch (NullReferenceException nullReference)
            {
                manejaExcepcionesDB.manejaNullReference(nullReference);
                return -1;
            }
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                return -1;
            }
        }
        public bool Eliminar(int idConsulta, int idTipoUsuario)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto  = new Entities.ClinicaDrFuentesEntities() )
            {
                return false;
            }
        }
        public List<Entities.AntecedenteDrogra> Listar()
        {
            return null;
        }
        public List<Entities.AntecedenteDrogra> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.AntecedenteDrogra> lista = (from tabla in Contexto.AntecedenteDrogra.AsNoTracking()
                                                           where tabla.idConsulta == idConsulta
                                                           select tabla).ToList();
                return lista;
            }
        }        
        public void EliminarListaDrogas(int IdConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                Entities.AntecedenteDrogra Entidad = (from t in Contexto.AntecedenteDrogra 
                                where t.idConsulta == IdConsulta select t).FirstOrDefault();
                if (Entidad != null)
                {
                    for (int indice = Entidad.Drogas.Count - 1; indice > -1; indice--)
                    {
                        var oso = Entidad.Drogas.ElementAt(indice);
                        Entidad.Drogas.Remove(oso);
                    }
                    Contexto.SaveChanges();
                }
            }                
        }
        private void ActulizarDrogas(Entities.ClinicaDrFuentesEntities Contexto, Entities.AntecedenteDrogra Original, Entities.AntecedenteDrogra Entidad)
        {
            // Para Actulizar Los Servicios
            List<int> removeList = new List<int>();
            //Recoge los IdServicios que Encuentrar EN Originial y No en nueva  Entidad
            foreach (Entities.Drogas droga in Original.Drogas)
            {
                if (Entidad.Drogas.Where(x => x.idDrogas == droga.idDrogas).Count() > 0)
                {
                    continue;
                }
                else
                {
                    removeList.Add(droga.idDrogas);
                }
            }
            // Por Cada Servicio Que Esta Original y No en Entidad se Elimina
            foreach (int idServicio in removeList)
            {
                Original.Drogas.Remove(Contexto.Drogas.Find(idServicio));
            }
            // Por cada servicio que se encuentra en Entidad y no en Original , se añade
            foreach (var item in Entidad.Drogas)
            {
                if (Original.Drogas.Where(x => x.idDrogas == item.idDrogas).Count() == 0)
                {
                    Contexto.Drogas.Attach(item);
                    Original.Drogas.Add(item);
                }
            }
        }        
       /// <summary>
       ///  Debido a Object DIspose en la lista Drogas
       /// </summary>
       /// <param name="Entidad"></param>
       /// <returns></returns>
        public Entities.AntecedenteDrogra Attach(Entities.AntecedenteDrogra Entidad)
        {
            if (Entidad == null)
            {
                return null;
            }
            Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            Contexto.AntecedenteDrogra.Attach(Entidad);
            return Entidad;
        }
        public static void oso()
        {
            Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            Entities.AntecedenteDrogra entidad = new Entities.AntecedenteDrogra();

            entidad.idConsulta = 7;
            entidad.NumeroTiempo = 1;
            entidad.EscalaTiempo = (from tabla in Contexto.EscalaTiempoes.AsNoTracking() select tabla).FirstOrDefault();
            List<Entities.Drogas> listaDrogas = (from tabla in Contexto.Drogas select tabla).Take(2).ToList();

            entidad.Drogas = listaDrogas;

            Contexto.AntecedenteDrogra.Add(entidad);
            Contexto.SaveChanges();
        }
    }
}



