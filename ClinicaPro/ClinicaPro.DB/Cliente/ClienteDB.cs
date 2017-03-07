using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias Añadidas
using ClinicaPro.Entities;
using System.Windows.Forms;
using System.Data.Entity.Core;
using ClinicaPro.General.Excepciones;
using ClinicaPro.General.Constantes;
using ClinicaPro.BL;

namespace ClinicaPro.DB.Cliente
{
    public class ClienteDB : Abstract.IEstandar_ManejoDB<Entities.Cliente> 
    {        
        #region Metodos Publicos

        /// <param name="isModificar">En caso  agregar un nuevo registro su valor es, false</param>
        /// <returns> idCliente </returns>
        public int Agregar_Modificar(Entities.Cliente cliente, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.Cliente Original = Contexto.Clientes.Find(cliente.IdCliente);
                    if (Original != null)
                    {
                        Original.Nombre = cliente.Nombre;
                        Original.Cedula = cliente.Cedula;
                        Original.Edad = cliente.Edad;
                        Original.Sexo = cliente.Sexo;
                        Original.isExtranjero = cliente.isExtranjero;
                        Original.Celular = cliente.Celular;
                        Original.Estado = cliente.Estado;
                        Original.Apellido1 = cliente.Apellido1;
                        Original.Apellido2 = cliente.Apellido2;
                        Original.TipoSangre = cliente.TipoSangre;
                        Original.Email = cliente.Email;
                        Original.Ciudad = cliente.Ciudad;
                    }
                    else {
                            return NosePudoActualizar();
                         }                   
                }
                else
                {
                    Contexto.Clientes.Add(cliente);
                }
                Contexto.SaveChanges();
                return cliente.IdCliente;
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
        /// <summary>
        /// Elimina un Cliente y las Consultas Asociadas // Seguimientos y citas  aun no
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="idTipoUsuario"></param>
        /// <returns></returns>
        public bool Eliminar(int idCliente, int idTipoUsuario)
        {           
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities())
            {
               try
               { 
                Entities.Cliente borrarCliente = Contexto.Clientes.Find(idCliente);

                EliminarConsultasAsociadas(borrarCliente, idTipoUsuario);

                if (borrarCliente != null)
                {                   
                        Contexto.Clientes.Remove(borrarCliente);
                        Contexto.SaveChanges();
                        return true;                                        
                }
                else  
                {                    
                    MessageBox.Show(Mensajes.No_Se_Elimina_No_Se_Encontro, Mensajes.Numero_Paciente_NoExiste, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }                   
               }
                catch(Exception ex)
               {
                   MessageBox.Show(Mensajes.AlgoPaso);
                   return false;
               }               
            }
        }
        public  List<Entities.Cliente> Listar()                                     //AsNoTracking()
        {
            try                           
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
                List<Entities.Cliente> ListaClientes = (from tabla in Contexto.Clientes.AsNoTracking() 
                                                        orderby tabla.IdCliente 
                                                        descending 
                                                        select tabla).ToList();
                Contexto.Dispose();
                return ListaClientes;
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
        /// <summary>
        /// Trae una lista con los distintos nombres de las ciudades de clientes existentes
        /// </summary>
        /// <returns></returns>
        public static List<string> ListarNombresCiudad()
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<String> lista = (from tabla in Contexto.Clientes.AsNoTracking()
                                      select tabla.Ciudad).Distinct().ToList();
                return lista;
            }           
        }              
        /// <summary>
        /// Obtiene un instancia de un Clinete con el Id correpondiente , utiliza el metodo Find
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        public Entities.Cliente getCliente(int IdCliente)
        {
            using (ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities())
            {
                try
                {
                    return Contexto.Clientes.Find(IdCliente);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        
        #endregion
        /// <summary>
        /// Si no existe algun registro en la DB
        /// </summary>
        /// <returns></returns>
        private int NosePudoActualizar()
        {
            MessageBox.Show(Mensajes.No_Se_Actualizo,Mensajes.No_hay_Cliente,
                                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return -1;
        }
        /// <summary>
        ///  Cliente no es parte de la PK de consulta
        /// </summary>                
        private void EliminarConsultasAsociadas(Entities.Cliente  Entidad,int idTipoUsuario)
        {
           using(ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities())
           {
               Consulta.ConsultaDB consultaDb = new Consulta.ConsultaDB();
               var listIdConsulta = consultaDb.ListaIdConsultaPorCliente(Entidad.IdCliente);
               foreach (int idConsulta in listIdConsulta)
               {
                   consultaDb.Eliminar(idConsulta, idTipoUsuario);
               }
           }
        }
        public static int TotalHombres()
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    return (from tabla in Contexto.Clientes.AsNoTracking()
                            where tabla.Sexo == "H"
                            select tabla.IdCliente).Count();
                }
                catch (Exception)
                {
                    return 0;
                }
                
            }
        }
        public static int TotalMujeres()
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    return (from tabla in Contexto.Clientes.AsNoTracking()
                            where tabla.Sexo == "M"
                            select tabla.IdCliente).Count();
                }
                catch (Exception)
                {
                    return 0;
                }                
            }
        }
        public static int TotalClientes()
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    return (from tabla in Contexto.Clientes.AsNoTracking()
                            select tabla.IdCliente).Count();
                }
                catch (Exception)
                {
                    
                  return 0;
                }                
            }
        }
        public static int TotalExtrajeros()
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    return (from tabla in Contexto.Clientes.AsNoTracking()
                            where tabla.isExtranjero
                            select tabla.IdCliente).Count();
                }
                catch (Exception)
                {
                    return 0;
                }               
            }
        }
        public static List<int> PersonasRangoEdad()
        {
            List<int> list = new List<int>();
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                try
                {
                    // de 1  a 20
                    list.Add((from tabla in Contexto.Clientes.AsNoTracking()
                              where tabla.Edad >= 1 && tabla.Edad <= 20
                              select tabla.IdCliente).Count());
                    // 21 a 40
                    list.Add((from tabla in Contexto.Clientes.AsNoTracking()
                              where tabla.Edad >= 21 && tabla.Edad <= 40
                              select tabla.IdCliente).Count());
                    // 41 a 50
                    list.Add((from tabla in Contexto.Clientes.AsNoTracking()
                              where tabla.Edad >= 41 && tabla.Edad <= 50
                              select tabla.IdCliente).Count());
                    //> 50
                    list.Add((from tabla in Contexto.Clientes.AsNoTracking()
                              where tabla.Edad > 50
                              select tabla.IdCliente).Count());
                    return list;
                }
                catch (Exception)
                {
                    return list;          
                }              
            }
        }
    }
}
