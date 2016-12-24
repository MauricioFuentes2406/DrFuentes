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
    public class ConsultaReflejosDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaReflejo>
        ,Abstract.IListarExpediente<Entities.ConsultaReflejo>
    {
        public int Agregar_Modificar(Entities.ConsultaReflejo consultaReflejo, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaReflejo Original = Contexto.ConsultaReflejos.First(EntidadLocal => EntidadLocal.IdConsulta == consultaReflejo.IdConsulta);
                    if (Original != null)
                    {
                        Original.Observacion = consultaReflejo.Observacion;
                        Original.R_Adominales = consultaReflejo.R_Adominales;
                        Original.R_Bicipital = consultaReflejo.R_Bicipital;
                        Original.R_Carneano = consultaReflejo.R_Carneano;
                        Original.R_Mentoniano = consultaReflejo.R_Mentoniano;
                        Original.R_Orbicular_De_Los_Ojos = consultaReflejo.R_Orbicular_De_Los_Ojos;
                        Original.R_Patelar = consultaReflejo.R_Patelar;
                        Original.R_Radial = consultaReflejo.R_Radial;
                        Original.R_Tricipital = consultaReflejo.R_Tricipital;
                        Original.R_ValoracionGeneral = consultaReflejo.R_ValoracionGeneral;                        
                    }
                }
                else
                {
                    Contexto.ConsultaReflejos.Add(consultaReflejo);
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
        public List<Entities.ConsultaReflejo> Listar()
        {
            return null;
        }
        public List<Entities.ConsultaReflejo> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.ConsultaReflejo> lista = (from tabla in Contexto.ConsultaReflejos.AsNoTracking()
                                                        where tabla.IdConsulta == idConsulta
                                                        select tabla).ToList();
                return lista;
            }
        }
    }
}
