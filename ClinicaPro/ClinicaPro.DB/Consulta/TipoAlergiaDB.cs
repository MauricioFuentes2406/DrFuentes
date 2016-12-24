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
                throw ex;
            }
        }
        public bool Eliminar(int idCliente, int idAlergia)
        {
            ///<summary>
            ///1- Recibe id
            ///2- Busca la tupla asociada con el registro
            ///3- Verifica que no este vacio (retorna false)
            ///4- Elimina (retorna true)
            /// </summary>

            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities())
            {
                Entities.TipoAlergia borrarCliente = (from tabla in Contexto.TipoAlergias where tabla.idAlergia == idAlergia select tabla).First();
                if (borrarCliente != null)
                {
                    Contexto.TipoAlergias.Remove(borrarCliente);
                    Contexto.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show(Mensajes.No_Se_Elimina_No_Se_Encontro, Mensajes.Numero_Paciente_NoExiste, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
