using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using ClinicaPro.Entities;
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.ComponentModel;
using System.Windows.Forms;

namespace ClinicaPro.DB.Consulta
{
  public  class GinecoObstreticosDB : Abstract.IEstandar_ManejoDB<Entities.AntecedentesGinecoObstrectico>
                                        , Abstract.IListarExpediente<Entities.AntecedentesGinecoObstrectico>
    {      
      public   int Agregar_Modificar(Entities.AntecedentesGinecoObstrectico antecedenteGineco, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.AntecedentesGinecoObstrectico Original = Contexto.AntecedentesGinecoObstrecticos.First(EntidadLocal => EntidadLocal.idConsulta == antecedenteGineco.idConsulta);
                    if (Original != null)
                    {
                        Original.Abortos = antecedenteGineco.Abortos;
                        Original.Cecareas = antecedenteGineco.Cecareas;
                        Original.FUM = antecedenteGineco.FUM;
                        Original.FUPAC = antecedenteGineco.FUPAC;
                        Original.Gestaciones = antecedenteGineco.Gestaciones;
                        Original.Partos = antecedenteGineco.Partos;
                    }
                }
                else
                {
                    Contexto.AntecedentesGinecoObstrecticos.Add(antecedenteGineco);
                }
                Contexto.SaveChanges();
                return antecedenteGineco.idConsulta;
            }
            catch (EntityException entityException)
            {
                manejaExcepcionesDB.manejaEntityException(entityException);
                throw entityException;
            }
            catch (UpdateException sqlException)
            {
                manejaExcepcionesDB.UpdateExcepcion(sqlException);
                throw;
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
            return false;
        }
      public List<Entities.AntecedentesGinecoObstrectico> Listar()
      {
          ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
          List<Entities.AntecedentesGinecoObstrectico> lista = (from tabla in Contexto.AntecedentesGinecoObstrecticos .AsNoTracking()                                         
                                         select tabla).ToList();
          Contexto.Dispose();
          return lista; 
        }
      public List<Entities.AntecedentesGinecoObstrectico> ListaPorConsulta(int idConsulta)
      {
          using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
          {
              List<Entities.AntecedentesGinecoObstrectico> lista = (from tabla in Contexto.AntecedentesGinecoObstrecticos.AsNoTracking()
                                                  where tabla.idConsulta == idConsulta
                                                  select tabla).ToList();
              return lista;
          }
      }

      ///// <summary>
      ///// Propando  Un Inner Join , devolviendo una Entidad Nueva(Columnas distintas)
      ///// </summary>
      ///// <param name="Dg"></param>
      //public static void ListarGrid( DataGridView Dg  )
      //{
      //   using (ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities() )
      //   {
      //       var lista = (from gineco in Contexto.AntecedentesGinecoObstrecticos
      //                    join consulta in Contexto.Consultas
      //                        on gineco.idConsulta equals consulta.IdConsulta
      //                    select new
      //                    {
      //                        IdCliente = consulta.IdCliente,
      //                        IdConsulta = gineco.idConsulta,
      //                        Abortos = gineco.Abortos,
      //                        Cecareas = gineco.Cecareas,
      //                        FUM = gineco.FUM,
      //                        FUPAC = gineco.FUPAC,
      //                        Gestaciones = gineco.Gestaciones,
      //                        Partos = gineco.Partos
      //                    }).ToList();
      //       Dg.DataSource = lista;
      //   }
      //} 
    }
}
