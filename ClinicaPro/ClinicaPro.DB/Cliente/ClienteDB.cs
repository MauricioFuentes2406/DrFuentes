﻿using System;
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
        #region Atributos
        public Boolean isModificar { get; set; }
        public int idTipoUsuario { get; set; }        
        #endregion
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
                    Entities.Cliente Original = Contexto.Clientes.First(EntidadLocal => EntidadLocal.IdCliente == cliente.IdCliente);
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
        public bool Eliminar(int idCliente, int idTipoUsuario)
        {
            ///<summary>
            ///1- Recibe id
            ///2- Busca la tupla asociada con el registro
            ///3- Verifica que no este vacio (retorna false)
            ///4- Elimina (retorna true)
            /// </summary>

            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities())
            {
                Entities.Cliente borrarCliente = (from tabla in Contexto.Clientes where tabla.IdCliente == idCliente select tabla).First();
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
        #endregion
    }
}
