using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
/*
 No LLeva Abstract de IListarExpediente<T>, pq es de Configuracion
 */
namespace ClinicaPro.DB.Consulta
{
    public class EstadoViviendaDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaEstadoVivienda>
    {
        public int Agregar_Modificar(Entities.ConsultaEstadoVivienda Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaEstadoVivienda Original = Contexto.ConsultaEstadoViviendas.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        Original.AguaPotable = Entidad.AguaPotable;
                        Original.Cielorraso = Entidad.Cielorraso;
                        Original.DetalleExtra = Entidad.DetalleExtra;
                        Original.IsPropia = Entidad.IsPropia;                        
                        Original.Paredes_Material = Entidad.Paredes_Material;
                        Original.Piso = Entidad.Piso;
                        Original.SanitariosCantidad = Entidad.SanitariosCantidad;
                        Original.ServiciosBasicos = Entidad.ServiciosBasicos;
                        Original.Ventilacion = Entidad.Ventilacion;
                        Original.TieneMascota = Entidad.TieneMascota;
                    }if(Original == null)
                    {
                        Contexto.ConsultaEstadoViviendas.Add(Entidad);
                    }
                }
                else
                {
                    Contexto.ConsultaEstadoViviendas.Add(Entidad);
                }
                Contexto.SaveChanges();
                return 1 ;                     // Regresa 1 pq no tiene su propio Id
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
        public Entities.ConsultaEstadoVivienda GetEstadoVivienda(int idConsulta)
       {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
            {
                return Contexto.ConsultaEstadoViviendas.Find(idConsulta);
            }
       }
       public List<Entities.ConsultaEstadoVivienda> Listar()
       {
           return null; 
       }
       // <summary>
       /// Valida Eliminar , true hay un hallazgo , false todo bien
       /// </summary>
       /// <param name="Contexto"></param>
       /// <param name="IdFamiliar"></param>
       /// <returns></returns>
       private bool ValidarEliminar(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdMaterial)
       {
           if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(IdMaterial))
           {
               if (Contexto.Familiars.Find(IdMaterial) == null)
                   return true;
               if (ValidarEliminar_SiExisteLLaveForanea(Contexto, IdMaterial))
                   return true;
               else
                   return false;
           }
           else
               return true;
       }
       private bool ValidarEliminar_SiExisteLLaveForanea(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdMaterial)
       {
           var list = ListasConIdMaterial(Contexto, IdMaterial);
           if (list != null)
           {
               MensajeSiExisteLlaveForanea(list);
               return true;
           }
           else
               return false;
       }
       private List<Entities.ConsultaEstadoVivienda> ListasConIdMaterial(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdMaterial)
       {
           return Contexto.ConsultaEstadoViviendas.Where
                   (EntidadLocal => EntidadLocal.Paredes_Material == IdMaterial || EntidadLocal.Piso == IdMaterial).ToList();
       }
       private void MensajeSiExisteLlaveForanea(List<Entities.ConsultaEstadoVivienda> list)
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
