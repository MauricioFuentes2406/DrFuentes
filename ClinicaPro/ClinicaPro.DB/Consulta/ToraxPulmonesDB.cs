using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
/*
 No LLeva Abstract de IListarExpediente<T>, pq tiene uns Vista
 */
namespace ClinicaPro.DB.Consulta
{
    public class ToraxPulmonesDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaToraxPulmone>                                   
    {
       public int Agregar_Modificar(Entities.ConsultaToraxPulmone Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaToraxPulmone Original = Contexto.ConsultaToraxPulmones.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        Original.AscultacionMurmulloVescular = Entidad.AscultacionMurmulloVescular;
                        Original.ExpasibilidadToraxica = Entidad.ExpasibilidadToraxica;
                        Original.RespiracionDiafragmaticaAbdominal = Entidad.RespiracionDiafragmaticaAbdominal;
                        Original.RuidosAgregados = Entidad.RuidosAgregados;
                        Original.SonoridadPulmunar = Entidad.SonoridadPulmunar;                        
                    }
                    if(Original == null)
                    {
                        Contexto.ConsultaToraxPulmones.Add(Entidad);
                    }
                }
                else
                {
                    Contexto.ConsultaToraxPulmones.Add(Entidad);
                }
                Contexto.SaveChanges();
                return 1;                            // Retorna 1 por que no devuelve ninguna nueva id  
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
       public bool Eliminar(int idCliente, int idTipoUsuario)
        {
            return false;
        }
        public Entities.ConsultaToraxPulmone GetToraxYPulmones(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
           {
              return  Contexto.ConsultaToraxPulmones.Find(idConsulta);
           }
       }
       public List<Entities.ConsultaToraxPulmone> Listar()
       {
           return null;
       }
    }
}
