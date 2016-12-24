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
    public class AntecedenteTabacoDB : Abstract.IEstandar_ManejoDB<Entities.AntecedenteTabaco>
                                       ,Abstract.IListarExpediente<Entities.AntecedenteTabaco>
        
    {
        public int Agregar_Modificar(Entities.AntecedenteTabaco Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.AntecedenteTabaco Original = Contexto.AntecedenteTabaco.First(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        if (Original.EscalaTiempo.IdEscalaTiempo != Entidad.EscalaTiempo.IdEscalaTiempo)
                        {
                            Original.EscalaTiempo = Contexto.EscalaTiempoes.Find(Entidad.EscalaTiempo.IdEscalaTiempo);
                        }                        
                        Original.NumeroTiempo = Entidad.NumeroTiempo;                         
                    }
                }
                else
                {
                    Contexto.AntecedenteTabaco.Attach(Entidad);     // Hay unos objetos que se traen de la BD como AsNotTRacking()
                    Contexto.AntecedenteTabaco.Add(Entidad);
                }
                Contexto.SaveChanges();
                Contexto.Dispose();
                return 1;                            // Retorna 1 pq esta tabla no tiene su propio id
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
       public List<Entities.AntecedenteTabaco> Listar()
       {
           return null;
       }
       public List<Entities.AntecedenteTabaco> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.AntecedenteTabaco> lista = (from tabla in Contexto.AntecedenteTabaco.AsNoTracking()
                                   where tabla.IdConsulta == idConsulta
                                   select tabla).ToList();
               return lista;
           }
       }
    }
}
