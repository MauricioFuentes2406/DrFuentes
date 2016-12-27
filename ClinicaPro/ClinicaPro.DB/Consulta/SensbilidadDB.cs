using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB.Consulta
{
    public class SensbilidadDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaSensibilidad>
        ,Abstract.IListarExpediente<Entities.ConsultaSensibilidad>
    {
        public int Agregar_Modificar(Entities.ConsultaSensibilidad Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaSensibilidad Original = Contexto.ConsultaSensibilidads.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        Original.Detalles = Entidad.Detalles;
                        Original.S_Discriminacion_Dos_Puntos = Entidad.S_Discriminacion_Dos_Puntos;
                        Original.S_Discriminatoria = Entidad.S_Discriminatoria;
                        Original.S_Profunda = Entidad.S_Profunda;
                        Original.S_Superficial = Entidad.S_Superficial;
                    }
                    if (Original== null)
                    {
                        Contexto.ConsultaSensibilidads.Add(Entidad);
                    }
                }
                else
                {
                    Contexto.ConsultaSensibilidads.Add(Entidad);
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
        public List<Entities.ConsultaSensibilidad> Listar()
        {
            return null;
        }
        public List<Entities.ConsultaSensibilidad> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.ConsultaSensibilidad> lista = (from tabla in Contexto.ConsultaSensibilidads.AsNoTracking()
                                                             where tabla.IdConsulta == idConsulta
                                                             select tabla).ToList();
                return lista;
            }
        }
    }
}
