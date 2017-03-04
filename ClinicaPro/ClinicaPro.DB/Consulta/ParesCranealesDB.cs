using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB.Consulta 
{
    public class ParesCranealesDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaParesCraneale>
                                    ,Abstract.IListarExpediente<Entities.ConsultaParesCraneale>
    {
       public int Agregar_Modificar(Entities.ConsultaParesCraneale Entidad, Boolean isModificar)
        {
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaParesCraneale Original = Contexto.ConsultaParesCraneales.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == Entidad.IdConsulta);
                    if (Original != null)
                    {
                        Original.PC_I_Olfatorio = Entidad.PC_I_Olfatorio;
                        Original.PC_II_AgudezaVisual = Entidad.PC_II_AgudezaVisual;
                        Original.PC_II_Campimetria = Entidad.PC_II_Campimetria;
                        Original.PC_II_FondoOjo = Entidad.PC_II_FondoOjo;
                        Original.PC_II_ReflejoPupilar= Entidad.PC_II_ReflejoPupilar;
                        Original.PC_II_VisionColores = Entidad.PC_II_VisionColores;
                        Original.PC_III_IV_VI_MovimientoOcular = Entidad.PC_III_IV_VI_MovimientoOcular;
                        Original.PC_III_IV_VI_ReflejoFotoMotorDirectoyConsensual = Entidad.PC_III_IV_VI_ReflejoFotoMotorDirectoyConsensual;
                        Original.PC_IX_FunciasGustativa = Entidad.PC_IX_FunciasGustativa;
                        Original.PC_V_MovimientoMandibula = Entidad.PC_V_MovimientoMandibula;
                        Original.PC_V_ReflejoCorneano = Entidad.PC_V_ReflejoCorneano;
                        Original.PC_V_SensibilidadCara = Entidad.PC_V_SensibilidadCara;
                        Original.PC_VII_CierreOjosVsResistencia = Entidad.PC_VII_CierreOjosVsResistencia;
                        Original.PC_VII_Gustos2TerciosAnterioresLengua = Entidad.PC_VII_Gustos2TerciosAnterioresLengua;
                        Original.PC_VII_MovibilidadMusculosCara = Entidad.PC_VII_MovibilidadMusculosCara;
                        Original.PC_VII_MuecasAmbosLado = Entidad.PC_VII_MuecasAmbosLado;
                        Original.PC_VII_SoplaMuentraDientes = Entidad.PC_VII_SoplaMuentraDientes;
                        Original.PC_VIII_Romberg = Entidad.PC_VIII_Romberg;
                        Original.PC_VIII_WebberYRinne= Entidad.PC_VIII_WebberYRinne;
                        Original.PC_X_ElevacionSimetrica = Entidad.PC_X_ElevacionSimetrica;
                        Original.PC_X_Lengua = Entidad.PC_X_Lengua;
                        Original.PC_X_Paladar = Entidad.PC_X_Paladar;
                        Original.PC_X_ReflejoNauseano = Entidad.PC_X_ReflejoNauseano;
                        Original.PC_XI_MovimientoEsternocleidomastoideo = Original.PC_XI_MovimientoEsternocleidomastoideo;
                        Original.PC_XI_MovimientoTrapecio = Entidad.PC_XI_MovimientoTrapecio;
                        Original.PC_XI_TonoFuerzaMuscarlarEsterno = Entidad.PC_XI_TonoFuerzaMuscarlarEsterno;
                        Original.PC_XI_TonoFuerzaMuscarlarTrapecio = Entidad.PC_XI_TonoFuerzaMuscarlarTrapecio;                       
                    }
                    if (Original == null)
                    {
                        Contexto.ConsultaParesCraneales.Add(Entidad);
                    }
                }
                else
                {
                    Contexto.ConsultaParesCraneales.Add(Entidad);
                }
                Contexto.SaveChanges();
                return 1;                        // Retorna 1 por que no devuelve ninguna nueva id  
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
        /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
        /// </summary>
        /// <returns>Lista de objetos de Clase </returns>       
       public List<Entities.ConsultaParesCraneale> Listar()
        {
            return null;
        }
       public List<Entities.ConsultaParesCraneale> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.ConsultaParesCraneale> lista = (from tabla in Contexto.ConsultaParesCraneales.AsNoTracking()
                                                             where tabla.IdConsulta == idConsulta
                                                             select tabla).ToList();
               return lista;
           }
       }
    }
}
