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
    }
}
