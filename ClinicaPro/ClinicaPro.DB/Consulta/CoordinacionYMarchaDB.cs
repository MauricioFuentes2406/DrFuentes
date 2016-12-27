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
 public   class CoordinacionYMarchaDB : Abstract.IEstandar_ManejoDB<Entities.CoordinacionyMarcha>
                                        ,Abstract.IListarExpediente<Entities.CoordinacionyMarcha>
    {
    public int Agregar_Modificar(Entities.CoordinacionyMarcha coordinacionMarcha, Boolean isModificar)
     {
         try
         {
             ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
             if (isModificar)
             {
                 Entities.CoordinacionyMarcha Original = Contexto.CoordinacionyMarchas.FirstOrDefault(EntidadLocal => EntidadLocal.IdConsulta == coordinacionMarcha.IdConsulta);
                 if (Original != null)
                 {
                     Original.Camina = coordinacionMarcha.Camina;
                     Original.Dedo_Nariz = coordinacionMarcha.Dedo_Nariz;
                     Original.Observacion = coordinacionMarcha.Observacion;
                     Original.Romberg = coordinacionMarcha.Romberg;
                     Original.Talon_Rodilla = coordinacionMarcha.Talon_Rodilla;
                 }
                 if (Original ==  null)
                 {
                     Contexto.CoordinacionyMarchas.Add(coordinacionMarcha);
                 }
             }
             else
             {
                 Contexto.CoordinacionyMarchas.Add(coordinacionMarcha);
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
        public List<Entities.CoordinacionyMarcha> Listar()
       {
           return null;
       }
        public List<Entities.CoordinacionyMarcha> ListaPorConsulta(int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.CoordinacionyMarcha> lista = (from tabla in Contexto.CoordinacionyMarchas.AsNoTracking()
                                                            where tabla.IdConsulta == idConsulta
                                                            select tabla).ToList();
                return lista;
            }
        }
    }
}
