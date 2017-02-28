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
    public class ConsultaOjosDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaOjo>
                                ,Abstract.IListarExpediente<Entities.ConsultaOjo>
    {
        public int Agregar_Modificar(Entities.ConsultaOjo consultaOjo, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaOjo Original = Contexto.ConsultaOjos.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == consultaOjo.IdConsulta);
                    if (Original != null)
                    {
                        Original.Diplopia = consultaOjo.Diplopia;
                        Original.Epifora = consultaOjo.Epifora;
                        Original.FotoFobia = consultaOjo.FotoFobia;
                        Original.Lentes = consultaOjo.Lentes;
                        Original.Midriasis = consultaOjo.Midriasis;
                        Original.PerdidaAgudezaVisual =  consultaOjo.PerdidaAgudezaVisual;
                        Original.Xerolftamia = consultaOjo.Xerolftamia;
                    }else
                    {
                        Contexto.ConsultaOjos.Add(consultaOjo);
                    }
                }
                else
                {
                    Contexto.ConsultaOjos.Add(consultaOjo);
                }
                Contexto.SaveChanges();
                return 1;                            // Retorna 1 por que no devuelve ninguna nueva id  
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
        public List<Entities.ConsultaOjo> Listar()
        {
            return null;
        }
        public List<Entities.ConsultaOjo> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.ConsultaOjo> lista = (from tabla in Contexto.ConsultaOjos.AsNoTracking()
                                                    where tabla.IdConsulta == idConsulta
                                                    select tabla).ToList();
                return lista;
            }
        }
    }
}
