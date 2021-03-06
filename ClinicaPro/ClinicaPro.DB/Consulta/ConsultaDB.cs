﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;


namespace ClinicaPro.DB.Consulta
{
    public class ConsultaDB : Abstract.IEstandar_ManejoDB<Entities.Consulta>
    {
        /// <summary>
        ///  Guarda Y modifica los datos de una Consulta y Los servicios Utilzados
        /// </summary>                
        /// <returns></returns>
        public int Agregar_Modificar(Entities.Consulta Entidad, Boolean isModificar)
        {
            try
            {
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities())
                {
                    if (isModificar)
                    {
                        Entities.Consulta Original = Contexto.Consultas.Find(Entidad.IdConsulta);
                        if (Original != null)
                        {                           
                            Original.AntecenteQuirurgico = Entidad.AntecenteQuirurgico;
                            Original.CobroFinalDeConsulta = Entidad.CobroFinalDeConsulta;
                            Original.Descuento = Entidad.Descuento;
                            Original.Diagnostico = Entidad.Diagnostico;
                            Original.DiagnosticoEstado = Entidad.DiagnosticoEstado;
                            if (Original.EscalaTiempo.IdEscalaTiempo != Entidad.EscalaTiempo.IdEscalaTiempo)
                            {
                                Original.EscalaTiempo = Contexto.EscalaTiempoes.Find(Entidad.EscalaTiempo.IdEscalaTiempo);
                            }
                            /*No modifica Fecha de Consulta */
                            Original.MotivoConsulta = Entidad.MotivoConsulta;
                            Original.NumeroTiempo = Entidad.NumeroTiempo;
                            Original.PadecimientoActual = Entidad.PadecimientoActual;
                            Original.PlanTratamiento = Entidad.PlanTratamiento;
                            Original.PrimerIndicio = Entidad.PrimerIndicio;
                            Original.QSucedeAcontinuacion = Entidad.QSucedeAcontinuacion;                            
                            // Para Actulizar Los Servicios
                            ActulizarServicios(Contexto, Original, Entidad);                                                      
                        }
                    }
                    else
                    {
                        Contexto.Consultas.Attach(Entidad);     // Hay unos objetos que se traen de la BD como AsNotTRacking()                   
                        Contexto.Consultas.Add(Entidad);
                    }
                    Contexto.SaveChanges();
                    return Entidad.IdConsulta;
                }// Retorna el ultimo ID pq esta tabla no tiene su propio id
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
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                return -1;
            }
        }
        public bool Eliminar(int IdConsulta, int idTipoUsuario)
        {
            try
            {
                using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    Entities.Consulta consulta = Contexto.Consultas.Find(IdConsulta);
                    if (consulta != null)
                    {
                        Contexto.Consultas.Remove(consulta);
                        Contexto.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }            
        }
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
        public List<Entities.Consulta> Listar()
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.Consulta> list = (from tabla in Contexto.Consultas.AsNoTracking()
                                                select tabla
                                                   ).ToList();
                return list;
            }
        }       
        public Entities.Consulta GetConsulta(int idConsuta)
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities(); 
            
                return (from tabla in Contexto.Consultas.AsNoTracking()
                        where tabla.IdConsulta == idConsuta
                        select tabla).First();                      
        }
        /// <summary>
        /// Actuliza la Lista Servicios referente a la Consulta (Multiplicidad  de Uno a Muchos  ,   : *)
        /// </summary>
        /// <param name="Contexto"></param>
        /// <param name="Original"></param>
        /// <param name="Entidad"></param>
        private void ActulizarServicios( Entities.ClinicaDrFuentesEntities Contexto, Entities.Consulta Original, Entities.Consulta Entidad)
        {
            // Para Actulizar Los Servicios
            List<int> removeList = new List<int>();

            //Recoge los IdServicios que Encuentrar EN Originial y No en nueva  Entidad
            foreach (Entities.GeneralTipoServicio servicio in Original.GeneralTipoServicios)
            {
                if (Entidad.GeneralTipoServicios.Where(x => x.idServicio == servicio.idServicio).Count() > 0)
                {
                    continue;
                }
                else
                {
                    removeList.Add(servicio.idServicio);
                }
            }
            // Por Cada Servicio Que Esta Original y No en Entidad se Elimina
            foreach (int idServicio in removeList)
            {
                Original.GeneralTipoServicios.Remove(Contexto.GeneralTipoServicios.Find(idServicio));
            }
            // Por aca servicio que se encuentra en Entidad y no en Original , se añade
            foreach (var item in Entidad.GeneralTipoServicios)
            {
                if (Original.GeneralTipoServicios.Where(x => x.idServicio == item.idServicio).Count() == 0)
                {
                    Contexto.GeneralTipoServicios.Attach(item);
                    Original.GeneralTipoServicios.Add(item);
                }
            }                   
        }
        public bool ValidarEliminar()
        {
            return false;
        }
        public int SumarConsultaMesActual()
        {
            using (Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities() )
            {
                try
                {
                    return (from tabla in Contexto.Consultas
                            where tabla.FechaConsulta.Month == DateTime.Now.Month &&
                                  tabla.FechaConsulta.Year == DateTime.Now.Year
                            select tabla.CobroFinalDeConsulta).Sum();
                }
                catch (Exception)
                {

                    return 0;
                }
                
            }
        }
        public List<int> ListaIdConsultaPorCliente(int idCliente)
        {
            using (Entities.ClinicaDrFuentesEntities Contexto  = new Entities.ClinicaDrFuentesEntities())
            {
                return (from tabla in Contexto.Consultas
                        where tabla.IdCliente == idCliente
                        select tabla.IdConsulta).ToList();
            }
        }
        //public void  ConsultasXMes()
        //{
        //    using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
        //    {
        //        var results = (from r in Contexto.Consultas
        //                      let year = DbFunctions.AddYears("yy", r.FechaConsulta)
        //                       let month = DbFunctions.DatePart("mm", r.FechaConsulta)
        //                      where (r.datevalue >= frommonth && r.datevalue < tomonth)
        //                      group r by new { year, month } into g
        //                      select new
        //                      {
        //                          Year = g.Key.year,
        //                          Month = g.Key.month,
        //                          NoSales = g.Sum(x => x.No_of_sales)
        //                      });
        //    }

        //}
    }
}
