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
      /// <summary> Añade una coleccion de alergias de una sola vez
      /// </summary>
      /// <param name="listaDataGridAlergia">Es la lista que se usa de dataSource en el Grid de la pestaña Alergia </param>
      /// <param name="idCliente"></param>
      /// <returns></returns>    
       public static bool Agregar_Modificar(BindingList<TipoAlergia> listaDataGridAlergia, int idCliente , bool isModificar)// Este es el qu voy paa la Consulta 
        {            
            try
            {
                using(ClinicaDrFuentesEntities Contexto = new  ClinicaDrFuentesEntities () )
                {
                 if(isModificar)
                 {
                     List<ClienteAlergia> Original = (from tabla in Contexto.ClienteAlergias where tabla.IdCLiente== idCliente select tabla).ToList();

                     if (Original != null)
                     {
                         List<ClienteAlergia> removeIdList = new List<ClienteAlergia>();
                         foreach (var alergia in Original)
                         {
                             if (listaDataGridAlergia.Any(x => x.idAlergia == alergia.IdAlergia))
                             {
                                 continue;
                             }
                             else
                             {
                                 removeIdList.Add(alergia);
                             }
                         }
                         foreach (var item in removeIdList)
                         {
                             Contexto.ClienteAlergias.Remove(item);
                         }
                     }
                         //Add 
                         foreach (var item in listaDataGridAlergia)
                         {
                             if (Original.Where(x => x.IdAlergia == item.idAlergia).Count() == 0)
                             {
                                 ClienteAlergia foreachRegistro = new ClienteAlergia();
                                 foreachRegistro.IdAlergia = item.idAlergia;
                                 foreachRegistro.IdCLiente = idCliente;
                                 Contexto.ClienteAlergias.Add(foreachRegistro);
                             }
                         }
                     
                 }else  // Else de isModificar
                 {
                     foreach (TipoAlergia tipoAlergia in listaDataGridAlergia)
                     {
                         ClienteAlergia foreachRegistro = new ClienteAlergia(); //
                         foreachRegistro.IdAlergia = tipoAlergia.idAlergia;
                         foreachRegistro.IdCLiente = idCliente;
                         Contexto.ClienteAlergias.Add(foreachRegistro);
                     }
                 }
                 
                    Contexto.SaveChanges();
                }
               return true; 
            }
               catch (EntityException entityException)
            {                               
                manejaExcepcionesDB.manejaEntityException(entityException);
                return false;
            }
            catch (SqlException sqlException)
            {
                manejaExcepcionesDB.manejaSQLExcepciones(sqlException);
                return false;
            }
            catch (NullReferenceException nullReference)
            {
                manejaExcepcionesDB.manejaNullReference(nullReference);
                return false;
            }
            catch (Exception ex)
            {                
                manejaExcepcionesDB.manejaExcepcion(ex);
                return false;
            }
        }

        public bool Eliminar(int idCliente, int idTipoUsuario) 
        {
            return false;
        }
        /// <summary>
        /// Actuliza la Lista Alergias referente a un CLiente (Multiplicidad  de Uno a Muchos  ,   : *)
        /// </summary>
        /// <param name="Contexto"></param>
        /// <param name="Original"></param>
        /// <param name="listaDataGridAlergia"></param>
        /// <param name="idCliente"></param>
        private void ActulizarAlergias(Entities.ClinicaDrFuentesEntities Contexto, List<ClienteAlergia> Original, List<TipoAlergia> listaDataGridAlergia,int idCliente)
        {
            List<ClienteAlergia> removeIdList = new List<ClienteAlergia>();
            foreach (var alergia in Original)
            {
                if (listaDataGridAlergia.Any(x => x.idAlergia == alergia.IdAlergia))
                {
                    continue;
                }
                else
                {
                    removeIdList.Add(alergia);
                }
            }
            foreach (var item in removeIdList)
            {
                Contexto.ClienteAlergias.Remove(item);
            }
            //Add 
            foreach (var item in listaDataGridAlergia)
            {
                if (Original.Where(x => x.IdAlergia == item.idAlergia).Count() == 0)
                {
                    ClienteAlergia foreachRegistro = new ClienteAlergia();
                    foreachRegistro.IdAlergia = item.idAlergia;
                    foreachRegistro.IdCLiente = idCliente;
                    Contexto.ClienteAlergias.Add(foreachRegistro);
                }
            }
        }
        public List<ClienteAlergia> Listar()
        {
            return null;
        }        
       public static List<TipoAlergia> ListarCliente(int idCliente)
        {
             using(ClinicaDrFuentesEntities Contexto = new  ClinicaDrFuentesEntities () )
             {
                return (from tabla in Contexto.ClienteAlergias.AsNoTracking()                                  
                        join tablaAlergia in Contexto.TipoAlergias on tabla.IdAlergia equals tablaAlergia.idAlergia
                        where tabla.IdCLiente == idCliente       
                        select tablaAlergia).ToList();
             }
        }
    }
}
