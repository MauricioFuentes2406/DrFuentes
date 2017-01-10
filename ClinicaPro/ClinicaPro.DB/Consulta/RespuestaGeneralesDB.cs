using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB.Consulta
{
   public class RespuestaGeneralesDB : Abstract.IEstandar_ManejoDB<Entities.Consulta_RespuestasGenerales>
    {
      public int Agregar_Modificar(Entities.Consulta_RespuestasGenerales Entidad, Boolean isModificar)
       {
           try
           {
               using ( ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
               { 
               if (isModificar)
               {
                   Entities.Consulta_RespuestasGenerales Original = Contexto.Consulta_RespuestasGenerales.First(EntidadLocal => EntidadLocal.idRespuestaGeneral == Entidad.idRespuestaGeneral);
                   if (Original != null)
                   {
                       Original.Nombre = Entidad.Nombre;
                   }
               }
               else
               {
                   Contexto.Consulta_RespuestasGenerales.Attach(Entidad); 
                   Contexto.Consulta_RespuestasGenerales.Add(Entidad);
               }
               Contexto.SaveChanges();
               return Entidad.idRespuestaGeneral; // Retorna 1 por que no devuelve ninguna nueva id  
               }
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
      public bool Eliminar(int idRespuestaGeneral, int idTipoUsuario)
        {
          
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    if (ValidarEliminar(Contexto,idRespuestaGeneral)== false)
                    {Entities.Consulta_RespuestasGenerales rgenerales = Contexto.Consulta_RespuestasGenerales.Where(EntidadLocal => EntidadLocal.idRespuestaGeneral == idRespuestaGeneral).First();
                    Contexto.Consulta_RespuestasGenerales.Remove(rgenerales);
                    Contexto.SaveChanges();
                    return true;
                    }
                    else return false;
                }            
        }
       public List<Entities.Consulta_RespuestasGenerales> Listar()
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.Consulta_RespuestasGenerales> lista = (from tabla in Contexto.Consulta_RespuestasGenerales.AsNoTracking()
                                                                 orderby tabla.idRespuestaGeneral
                                                                 select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
       /// <summary>
       /// Valida Eliminar , true hay un hallazgo , false todo bien
       /// </summary>
       /// <param name="Contexto"></param>
       /// <param name="idVacuna"></param>
       /// <returns></returns>
       private bool ValidarEliminar(Entities.ClinicaDrFuentesEntities Contexto, int idRespuestaGeneral)
       {
           if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(idRespuestaGeneral))
           {
               if (Contexto.Consulta_RespuestasGenerales.Find(idRespuestaGeneral) == null)
                   return true;
               if (ValidarEliminar_SiExisteLLaveForanea(idRespuestaGeneral))
                   return true;
               else return false;
           }
           else
           {
               return true;
           }

       }
       /// <summary>
       /// Valida si existe como llave foranea en algún registor
       /// </summary>
       /// <remarks>En este caso se relaciona con 2 tablas </remarks>
       /// <param name="Contexto"></param>
       /// <param name="idRespuestaGeneral"></param>
       /// <returns></returns>
       private bool ValidarEliminar_SiExisteLLaveForanea (int idRespuestaGeneral)
       {
           var list = ListasConIdRespuestaGeneral_ToraxPulmones(idRespuestaGeneral);
           if (list.Count > 0)
           {
               MensajeSiExisteLlaveForanea(list);
               return true;
           }
           else
           {
               var list2 = ListasConIdRespuestaGeneral_AntecedentePersonal(idRespuestaGeneral);
               if(list2 != null)
               {
                   MensajeSiExisteLlaveForanea(list);
                   return true;
               }
               return false;
           }
       }
       private List<Entities.ConsultaToraxPulmone> ListasConIdRespuestaGeneral_ToraxPulmones(int idRespuestaGeneral)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               return Contexto.ConsultaToraxPulmones.Where
                      (EntidadLocal => EntidadLocal.AscultacionMurmulloVescular == idRespuestaGeneral
                                      || EntidadLocal.ExpasibilidadToraxica == idRespuestaGeneral
                                       || EntidadLocal.RespiracionDiafragmaticaAbdominal == idRespuestaGeneral
                                        || EntidadLocal.RuidosAgregados == idRespuestaGeneral).ToList();
           }
       }
       private List<Entities.AntecedentePersonalesPatologico> ListasConIdRespuestaGeneral_AntecedentePersonal(int idRespuestaGeneral)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               return Contexto.AntecedentePersonalesPatologicos.Where
                      (EntidadLocal => EntidadLocal.Bronquitis == idRespuestaGeneral
                                      || EntidadLocal.Fiebre_Reumatica == idRespuestaGeneral
                                       || EntidadLocal.Paludismo == idRespuestaGeneral
                                        || EntidadLocal.Parotiditis == idRespuestaGeneral
                                        || EntidadLocal.Rubeola == idRespuestaGeneral
                                        || EntidadLocal.Sarampion == idRespuestaGeneral
                                        || EntidadLocal.Varicela == idRespuestaGeneral
                                        ).ToList();
           }
       }
       private void MensajeSiExisteLlaveForanea(List<Entities.ConsultaToraxPulmone> list)
       {
           String datos = String.Empty;
           foreach (var item in list)
           {
               datos += "\n Número Consulta:" + "  " + item.IdConsulta;
           }
           System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n" + datos,
               ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
               , System.Windows.Forms.MessageBoxButtons.OK
               , System.Windows.Forms.MessageBoxIcon.Warning
               );
       }
       private void MensajeSiExisteLlaveForanea(List<Entities.AntecedentePersonalesPatologico> list)
       {
           String datos = String.Empty;
           foreach (var item in list)
           {
               datos += "\n Número Consulta:" + "  " + item.IdConsulta;
           }
           System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n" + datos,
               ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
               , System.Windows.Forms.MessageBoxButtons.OK
               , System.Windows.Forms.MessageBoxIcon.Warning
               );
       }
    }
}
