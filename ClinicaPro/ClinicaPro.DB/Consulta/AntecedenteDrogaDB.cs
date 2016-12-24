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
                    Entities.AntecedenteDrogra Original = Contexto.AntecedenteDrogra.First(EntidadLocal => EntidadLocal.idConsulta == Entidad.idConsulta);
                    if (Original != null)
                    {
                        Original.Drogas = Entidad.Drogas;
                        Original.EscalaTiempo = Entidad.EscalaTiempo;
                        Original.NumeroTiempo = Entidad.NumeroTiempo;
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
        public static void oso()
        {
            Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            Entities.AntecedenteDrogra entidad = new Entities.AntecedenteDrogra();



            entidad.idConsulta = 7;
            entidad.NumeroTiempo = 1;
            //entidad.EscalaTiempo = Contexto.EscalaTiempoes.FirstOrDefault();
            entidad.EscalaTiempo = (from tabla in Contexto.EscalaTiempoes.AsNoTracking() select tabla).FirstOrDefault();


            List<Entities.Drogas> listaDrogas = (from tabla in Contexto.Drogas select tabla).Take(2).ToList();

            entidad.Drogas = listaDrogas;

            Contexto.AntecedenteDrogra.Add(entidad);
            Contexto.SaveChanges();

        }
    }
}



