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
    public class ConsultaOidosDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaOido>
                                    ,Abstract.IListarExpediente<Entities.ConsultaOido>
    {
        public int Agregar_Modificar(Entities.ConsultaOido consultaOidos, Boolean isModificar)
       {
           try
           {
               ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
               if (isModificar)
               {
                   Entities.ConsultaOido Original = Contexto.ConsultaOidos.First(EntidadLocal => EntidadLocal.IdConsulta == consultaOidos.IdConsulta);
                   if (Original != null)
                   {
                       Original.Acusia = consultaOidos.Acusia;
                       Original.Hipercusia = consultaOidos.Hipercusia;
                       Original.Hipocusia = consultaOidos.Hipocusia;
                       Original.Otalgia = consultaOidos.Otalgia;
                       Original.Otorrea = consultaOidos.Otorrea;
                       Original.Tinitus = consultaOidos.Tinitus;
                   }
               }
               else
               {
                   Contexto.ConsultaOidos.Add(consultaOidos);
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
               throw ;
           }                 
         }
        public bool Eliminar(int idCliente, int idTipoUsuario)
        {
            return false;
        }
        public List<Entities.ConsultaOido> Listar()
        {
            return null;
        }
        public List<Entities.ConsultaOido> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.ConsultaOido> lista = (from tabla in Contexto.ConsultaOidos.AsNoTracking()
                                                     where tabla.IdConsulta == idConsulta
                                                     select tabla).ToList();
                return lista;
            }
        }
    }
}
