using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias añadidas
using ClinicaPro.Entities;
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.ComponentModel;
using System.Data.SqlClient;

namespace ClinicaPro.DB.Cliente
{
   public class ClienteAlergiasDB : Abstract.IEstandar_ManejoDB<Entities.ClienteAlergia> 
    {     
      public int Agregar_Modificar(ClienteAlergia Entidad, Boolean isModificar) // 
        {
            return -1;
        }
      /// <summary> La diferencia de este Agregar es que va añadir una coleccion de una sola vez
      /// </summary>
      /// <param name="listaDataGridAlergia">Es la lista que se usa de dataSource en el Grid de la pestaña Alergia </param>
      /// <param name="idCliente"></param>
      /// <returns></returns>
       public static bool Agregar_Modificar(BindingList<TipoAlergia> listaDataGridAlergia, int idCliente)// Este es el qu voy para la Consulta 
        {            
            try
            {
                using(ClinicaDrFuentesEntities Contexto = new  ClinicaDrFuentesEntities () )
                {
                    
                 foreach(TipoAlergia tipoAlergia in listaDataGridAlergia)
                 {
                   ClienteAlergia foreachRegistro = new ClienteAlergia(); //
                   foreachRegistro.IdAlergia= tipoAlergia.idAlergia;
                   foreachRegistro.IdCLiente= idCliente;                   
                   Contexto.ClienteAlergias1.Add(foreachRegistro);
                   
                 }
                    Contexto.SaveChanges();
                }
               return true; 
            }
               catch (EntityException entityException)
            {                               
                manejaExcepcionesDB.manejaEntityException(entityException);
                throw entityException;
            }
            catch (SqlException sqlException)
            {
                manejaExcepcionesDB.manejaSQLExcepciones(sqlException);
                throw;
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
        public List<ClienteAlergia> Listar()
        {
            return null;
        }
    }
}
