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
    public class ConsultaCraneoDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaCraneo>
                                    , Abstract.IListarExpediente<Entities.ConsultaCraneo>
    {
        public int Agregar_Modificar(Entities.ConsultaCraneo consultaCraneo, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaCraneo Original = Contexto.ConsultaCraneos.First(EntidadLocal => EntidadLocal.IdConsulta == consultaCraneo.IdConsulta);
                    if (Original != null)
                    {
                        Original.AlteracionOsea = consultaCraneo.AlteracionOsea;
                        Original.Cefalea = consultaCraneo.Cefalea;
                        Original.Mareos = consultaCraneo.Mareos;
                        Original.PerdidaConciencia = consultaCraneo.PerdidaConciencia;
                        Original.Prurito = consultaCraneo.Prurito;
                        Original.Simetrico = consultaCraneo.Simetrico;
                        Original.Sincope = consultaCraneo.Sincope;
                        Original.TamañaFormaNormal = consultaCraneo.TamañaFormaNormal;
                    }
                }
                else
                {
                    Contexto.ConsultaCraneos.Add(consultaCraneo);
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
        public List<Entities.ConsultaCraneo> Listar()
        {
            return null;
        }
        public List<Entities.ConsultaCraneo> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.ConsultaCraneo> Entidad = (from tabla in Contexto.ConsultaCraneos.AsNoTracking()
                                                         where tabla.IdConsulta == idConsulta
                                                         select tabla).ToList();
                return Entidad;
            }
        }
    }
}
