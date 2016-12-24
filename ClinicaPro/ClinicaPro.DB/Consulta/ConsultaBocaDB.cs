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
   public class ConsultaBocaDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaBoca>
                                    ,Abstract.IListarExpediente<Entities.ConsultaBoca>
    {
     public int Agregar_Modificar(Entities.ConsultaBoca consultaBoca, Boolean isModificar)
       {       
            try
            {
                ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
                if (isModificar)
                {
                    Entities.ConsultaBoca Original = Contexto.ConsultaBocas.First(EntidadLocal => EntidadLocal.IdConsulta == consultaBoca.IdConsulta);
                    if (Original != null)
                    {
                        Original.Adoncia = consultaBoca.Adoncia;
                        Original.Amigdalitis = consultaBoca.Amigdalitis;
                        Original.Calzas = consultaBoca.Calzas;
                        Original.Disfagia = consultaBoca.Disfagia;
                        Original.Faringitis = consultaBoca.Faringitis;
                        Original.Laringitis = consultaBoca.Laringitis;
                        Original.LenguaDolorosa = consultaBoca.LenguaDolorosa;
                        Original.Protesis_Dentales = consultaBoca.Protesis_Dentales;
                        Original.Ronquera = consultaBoca.Ronquera;
                        Original.UlcerasOrales = consultaBoca.UlcerasOrales;                        
                    }
                }
                else
                {
                    Contexto.ConsultaBocas.Add(consultaBoca);
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
      public  bool Eliminar(int idCliente, int idTipoUsuario)
       {
           return false;
       }
       public List<Entities.ConsultaBoca> Listar() 
        {
            return null;
        }
       public List<Entities.ConsultaBoca> ListaPorConsulta(int idConsulta)
       {
           using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
           {
               List<Entities.ConsultaBoca> lista = (from tabla in Contexto.ConsultaBocas.AsNoTracking()
                                                    where tabla.IdConsulta == idConsulta
                                                    select tabla).ToList();
               return lista;
           }
       }
    }
}
