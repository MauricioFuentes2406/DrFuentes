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
    }
}
