using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias añadidas 
using ClinicaPro.BL;
using ClinicaPro.Entities;
using ClinicaPro.General.Excepciones;
using System.Data.Entity.Core;
using System.Windows.Forms;
using ClinicaPro.General.Constantes;

/*
 No LLeva Abstract de IListarExpediente<T>, pq es de Configuracion
 */

namespace ClinicaPro.DB.Consulta
{     
   public class TipoAlergiaDB : Abstract.IEstandar_ManejoDB<Entities.TipoAlergia>
    {
       public Boolean isModificar { get; set; }
       public  int idTipoUsuario { get; set; }
        public int Agregar_Modificar(Entities.TipoAlergia tipoAlergia, bool isModificar)
        {         
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.TipoAlergia Original = Contexto.TipoAlergias.First(EntidadLocal => EntidadLocal.idAlergia == tipoAlergia.idAlergia);
                    if (Original != null)
                    {
                        Original.Tipo_Alergia = tipoAlergia.Tipo_Alergia;
                        Original.Especificacion= tipoAlergia.Especificacion; 
                    }
                }
                else
                {
                    Contexto.TipoAlergias.Add(tipoAlergia);
                }
                Contexto.SaveChanges();
                return tipoAlergia.idAlergia;
            }
            ///<remark>No me acuerdo que iba a poner  </remark>
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
        public bool Eliminar(int idAlergia, int idCliente)
        {            
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities())
            {
                if (ValidarEliminar(Contexto, idAlergia) == false)
                {
                    try
                    {
                        Entities.TipoAlergia borrarAlergia = Contexto.TipoAlergias.Find(idAlergia);
                        Contexto.TipoAlergias.Remove(borrarAlergia);
                        Contexto.SaveChanges();
                        return true;  
                    }
                    catch (Exception)
                    {
                        return false;
                    }                                    
                }
                else
                {
                    MessageBox.Show(Mensajes.No_Se_Elimina_No_Se_Encontro, Mensajes.No_Se_Elimina_No_Se_Encontro, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public  List<TipoAlergia> Listar()
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
                List<Entities.TipoAlergia> ListaTipoAlergias = (from tabla in Contexto.TipoAlergias.AsNoTracking()  select tabla).ToList();
                Contexto.Dispose();
                return ListaTipoAlergias;
            }
            ///<remark>No me acuerdo que iba a poner  </remark>
            catch (EntityException entityException)
            {                               
                manejaExcepcionesDB.manejaEntityException(entityException);
                return null;
            }
            catch (NullReferenceException nullReference)
            {
                manejaExcepcionesDB.manejaNullReference(nullReference);
                return null;
            }
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                return null;
            }
        }
        private bool ValidarEliminar(Entities.ClinicaDrFuentesEntities Contexto, int idAlergia)
        {           
                if (Contexto.TipoAlergias.Find(idAlergia) == null)
                    return true;
                if (ValidarEliminar_SiExisteLLaveForanea(Contexto, idAlergia))
                    return true;
                else return false;                      
        }
        private bool ValidarEliminar_SiExisteLLaveForanea(Entities.ClinicaDrFuentesEntities Contexto, int idAlergia)
        {
            var list = ListarClientesConAlergia(idAlergia).ToList();
            if (list.Count > 0)
            {
                MensajeSiExisteLlaveForanea(list);
                return true;
            }
            else
                return false;
        }
        private List<Entities.ClienteAlergia> ListarClientesConAlergia(int idAlergia)
        {
            using (ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities())
            {
                return Contexto.ClienteAlergias.Where(EntidadLocal  => EntidadLocal.IdAlergia == idAlergia).ToList();
            }
        }
        private void MensajeSiExisteLlaveForanea(List<Entities.ClienteAlergia> list)
        {
            String datos = String.Empty;
            foreach (var item in list)
            {
                datos += "\n Número Cliente:" + "  " + item.IdCLiente ;
            }
            System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDelete + "\n" + datos,
                ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
                , System.Windows.Forms.MessageBoxButtons.OK
                , System.Windows.Forms.MessageBoxIcon.Warning
                );
        }
    }
}
