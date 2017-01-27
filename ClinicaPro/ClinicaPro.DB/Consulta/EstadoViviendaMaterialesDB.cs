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
            
                using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
                {
                    if (ValidarEliminar(Contexto, IdMaterial) == false)
                    {
                        Entities.ConsultaEstadoViviendaMateriale material = Contexto.ConsultaEstadoViviendaMateriales.Find(IdMaterial);
                        Contexto.ConsultaEstadoViviendaMateriales.Remove(material);
                        Contexto.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }                           
        }
        public List<Entities.ConsultaEstadoViviendaMateriale> Listar()
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities();
            List<Entities.ConsultaEstadoViviendaMateriale> lista = (from tabla in Contexto.ConsultaEstadoViviendaMateriales.AsNoTracking()
                                                                    orderby tabla.IdMaterial
                                                                   select tabla).ToList();
            Contexto.Dispose();
            return lista;
        }
        // <summary>
        /// Valida Eliminar , true hay un hallazgo , false todo bien
        /// </summary>
        /// <param name="Contexto"></param>
        /// <param name="IdFamiliar"></param>
        /// <returns></returns>
        private bool ValidarEliminar(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdMaterial)
        {
            if (ClinicaPro.BL.manejaExcepcionesDB.isID_distintodeUNO(IdMaterial))
            {
                if (Contexto.Familiars.Find(IdMaterial) == null)
                    return true;
                if (ValidarEliminar_SiExisteLLaveForanea(Contexto, IdMaterial))
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        private bool ValidarEliminar_SiExisteLLaveForanea(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdMaterial)
        {
            var list = ListasConIdMaterial(Contexto, IdMaterial);
            if (list.Count > 0 )
            {
                MensajeSiExisteLlaveForanea(list);
                return true;
            }
            else
                return false;
        }
        private List<Entities.ConsultaEstadoVivienda> ListasConIdMaterial(ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto, int IdMaterial)
        {
            return Contexto.ConsultaEstadoViviendas.Where
                    (EntidadLocal => EntidadLocal.Paredes_Material == IdMaterial || EntidadLocal.Piso == IdMaterial).ToList();
        }
        private void MensajeSiExisteLlaveForanea(List<Entities.ConsultaEstadoVivienda> list)
        {
            String datos = String.Empty;
            foreach (var item in list)
            {
                datos += "\n Número Consulta:" + "  " + item.IdConsulta;
            }
            System.Windows.Forms.MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.fk_ConstraintDeleteConsulta + "\n" + datos,
                ClinicaPro.General.Constantes.Mensajes.Upss_Falto_Algo
                , System.Windows.Forms.MessageBoxButtons.OK
                , System.Windows.Forms.MessageBoxIcon.Warning
                );
        }
    }
}
    

