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
    public class EstadoViviendaMaterialesDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaEstadoViviendaMateriale>
    {
        public int Agregar_Modificar(Entities.ConsultaEstadoViviendaMateriale Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaEstadoViviendaMateriale Original = Contexto.ConsultaEstadoViviendaMateriales.First(EntidadLocal => EntidadLocal.IdMaterial == Entidad.IdMaterial);
                    if (Original != null)
                    {
                        Original.Nombre = Entidad.Nombre;                         
                    }
                }
                else
                {
                    Contexto.ConsultaEstadoViviendaMateriales.Add(Entidad);
                }
                Contexto.SaveChanges();
                return Entidad.IdMaterial;                            
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
        public bool Eliminar(int IdMaterial, int idTipoUsuario)
        {
            if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(IdMaterial))
            {
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    Entities.ConsultaEstadoViviendaMateriale material = Contexto.ConsultaEstadoViviendaMateriales.Where(EntidadLocal => EntidadLocal.IdMaterial == IdMaterial).First();
                    Contexto.ConsultaEstadoViviendaMateriales.Remove(material);
                    Contexto.SaveChanges();
                    return true;
                }
            }
            else { return false; }                
        }
        public List<Entities.ConsultaEstadoViviendaMateriale> Listar()
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.ConsultaEstadoViviendaMateriale> lista = (from tabla in Contexto.ConsultaEstadoViviendaMateriales.AsNoTracking()
                                                                 select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }

    }
}
    

