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
    public class AntecedenteHereditarioDB : Abstract.IEstandar_ManejoDB<Entities.AntecedenteHereditario>
                                            ,Abstract.IListarExpediente<Entities.AntecedenteHereditario>
    {
       public int Agregar_Modificar(Entities.AntecedenteHereditario Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.AntecedenteHereditario Original = Contexto.AntecedenteHereditarios.First(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        Original.AfeccionTiroide = Entidad.AfeccionTiroide;
                        Original.Asma = Entidad.Asma;
                        Original.AVC = Entidad.AVC;
                        Original.Cancer = Entidad.Cancer;
                        Original.Cardiopatía = Entidad.Cardiopatía;
                        Original.DM = Entidad.DM;
                        Original.EnfermedadPulmonar = Original.EnfermedadPulmonar;
                        Original.Hepatopapia = Entidad.Hepatopapia;
                        Original.HTA = Entidad.HTA;
                        Original.Neuropatia = Original.Neuropatia;
                        Original.otro = Entidad.otro;
                    }
                }
                else
                {
                    Contexto.AntecedenteHereditarios.Add(Entidad);
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
       public List<Entities.AntecedenteHereditario> Listar()
       {
           return null;
       }
       public List<Entities.AntecedenteHereditario> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.AntecedenteHereditario> lista = (from tabla in Contexto.AntecedenteHereditarios.AsNoTracking()
                                                              where tabla.IdConsulta == idConsulta
                                                              select tabla).ToList();
               return lista;
           }
       }

    }
}
