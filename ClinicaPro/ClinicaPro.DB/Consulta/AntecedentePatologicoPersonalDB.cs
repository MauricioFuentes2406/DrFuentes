﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;


namespace ClinicaPro.DB.Consulta
{
  public  class AntecedentePatologicoPersonalDB : Abstract.IEstandar_ManejoDB<Entities.AntecedentePersonalesPatologico>
                                                 , Abstract.IListarExpediente<Entities.AntecedentePersonalesPatologico>
    {
        public int Agregar_Modificar(Entities.AntecedentePersonalesPatologico Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.AntecedentePersonalesPatologico Original = Contexto.AntecedentePersonalesPatologicos.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        Original.Bronquitis = Entidad.Bronquitis;
                        Original.Fiebre_Reumatica = Entidad.Fiebre_Reumatica;
                        Original.Detalle = Original.Detalle;
                        Original.Paludismo = Original.Paludismo;
                        Original.Parotiditis = Original.Parotiditis;
                        Original.Rubeola = Original.Rubeola;
                        Original.Sarampion = Original.Sarampion;
                        Original.Varicela = Original.Varicela;                                       
                    }if (Original == null)
                    {
                        Contexto.AntecedentePersonalesPatologicos.Add(Entidad);
                    }
                }
                else
                {
                    Contexto.AntecedentePersonalesPatologicos.Add(Entidad);
                }
                Contexto.SaveChanges();
                return 1;                            // Retorna 1 por que no devuelve ninguna nueva id  
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
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
       public List<Entities.AntecedentePersonalesPatologico> Listar()
       {
           return null;
       }
       public List<Entities.AntecedentePersonalesPatologico> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.AntecedentePersonalesPatologico> lista = (from tabla in Contexto.AntecedentePersonalesPatologicos.AsNoTracking()
                                                                       where tabla.IdConsulta == idConsulta
                                                                       select tabla).ToList();
               return lista;
           }
       }
    }
}
