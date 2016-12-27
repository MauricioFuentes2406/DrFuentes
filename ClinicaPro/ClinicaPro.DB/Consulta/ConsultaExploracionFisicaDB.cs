using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.Entities;
using ClinicaPro.BL;
using System.Data.Entity.Core;
using System.ComponentModel;

/*
 No LLeva Abstract de IListarExpediente pq ' usa una Vista
 */
namespace ClinicaPro.DB.Consulta
{
    public class ConsultaExploracionFisicaDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaExploracionFisica>
    {
       public int Agregar_Modificar(Entities.ConsultaExploracionFisica consultaExFisica, Boolean isModificar)
        {
            try// borre los id de exploracion fisica
            {
               ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaExploracionFisica Original = Contexto.ConsultaExploracionFisicas.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == consultaExFisica.IdConsulta);
                    if (Original != null)
                    {
                        Original.FrecuenciaCardiaca = consultaExFisica.FrecuenciaCardiaca;
                        Original.FrecuenciaRespiratoria = consultaExFisica.FrecuenciaRespiratoria;
                        Original.Peso = consultaExFisica.Peso;
                        Original.PresionArterialDiastolico = consultaExFisica.PresionArterialDiastolico;
                        Original.PresionArterialSistolico = consultaExFisica.PresionArterialSistolico;
                        Original.Talla = consultaExFisica.Talla;
                        Original.Temperatura = consultaExFisica.Temperatura;
                        Original.idExploracionManos = consultaExFisica.idExploracionManos;
                        Original.idColorPaciente = consultaExFisica.idColorPaciente;
                    }
                    if(Original == null)
                    {
                        Contexto.ConsultaExploracionFisicas.Add(consultaExFisica);
                    }
                } 
                else
                {                    
                    Contexto.ConsultaExploracionFisicas.Add(consultaExFisica);
                }
                Contexto.SaveChanges();
                return  1;                           // Retorna 1 por que no devuelve ninguna nueva id
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
        public Entities.ConsultaExploracionFisica GetExploracionFisica(int IdConsulta)
       {
            using (ClinicaDrFuentesEntities Contexto  = new ClinicaDrFuentesEntities())
            {
                return Contexto.ConsultaExploracionFisicas.Find(IdConsulta);
            }
       }
       public List<Entities.ConsultaExploracionFisica> Listar()
        {
            return null;
        }

    }
}
