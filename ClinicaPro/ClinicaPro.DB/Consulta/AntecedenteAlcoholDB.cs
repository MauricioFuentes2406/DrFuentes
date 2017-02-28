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
 public  class AntecedenteAlcoholDB : Abstract.IEstandar_ManejoDB<Entities.AntecedenteAlcohol>
                                      ,Abstract.IListarExpediente<Entities.AntecedenteAlcohol>
    {
       public int Agregar_Modificar(Entities.AntecedenteAlcohol Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.AntecedenteAlcohol Original = Contexto.AntecedenteAlcohol.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        Original.BebeEnPromedio = Entidad.BebeEnPromedio;
                        if (Original.EscalaTiempo.IdEscalaTiempo != Entidad.EscalaTiempo.IdEscalaTiempo)
                        { Original.EscalaTiempo = Contexto.EscalaTiempoes.Find(Entidad.EscalaTiempo.IdEscalaTiempo); }
                        Original.NumeroTiempo = Entidad.NumeroTiempo;
                    }if ( Original == null)
                    {
                        Contexto.AntecedenteAlcohol.Attach(Entidad);     // Hay unos objetos que se traen de la BD como AsNotTRacking()
                        Contexto.AntecedenteAlcohol.Add(Entidad);
                    }
                }
                else
                {
                    Contexto.AntecedenteAlcohol.Attach(Entidad);     // Hay unos objetos que se traen de la BD como AsNotTRacking()
                    Contexto.AntecedenteAlcohol.Add(Entidad);

                }            
                Contexto.SaveChanges();
                Contexto.Dispose();
                return 1;                            // Retorna 1 pq esta tabla no tiene su propio id
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
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                return -1;
            }
        }
      public  bool Eliminar(int idCliente, int idTipoUsuario)
        {
            return false;
        }
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
      public  List<Entities.AntecedenteAlcohol> Listar()
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List <Entities.AntecedenteAlcohol> lista = (from tabla in Contexto.AntecedenteAlcohol.AsNoTracking()
                                                      
                                                       select tabla).ToList();
                return lista;
            }
        }
      public List<Entities.AntecedenteAlcohol> ListaPorConsulta(int idConsulta)
      {
          using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
          {
              List<Entities.AntecedenteAlcohol> lista = (from tabla in Contexto.AntecedenteAlcohol.AsNoTracking()
                                                       where tabla.IdConsulta == idConsulta
                                                       select tabla).ToList();
              return lista;
          }
      }
      public Entities.AntecedenteAlcohol Attach(Entities.AntecedenteAlcohol Entidad)
      {
          if (Entidad == null)
          {
              return null;
          }
          Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
          Contexto.AntecedenteAlcohol.Attach(Entidad);
          return Entidad;
      }
      
    }
}
