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
 public   class ConsultaCuelloDB : Abstract.IEstandar_ManejoDB<Entities.ConsultaCuello>
                                   , Abstract.IListarExpediente<Entities.ConsultaCuello>
    {
     public int Agregar_Modificar(Entities.ConsultaCuello consultaCuello, Boolean isModificar)
     {
         try
         {
             ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaPro.Entities.ClinicaDrFuentesEntities();
             if (isModificar)
             {
                 Entities.ConsultaCuello Original = Contexto.ConsultaCuelloes.First(EntidadLocal => EntidadLocal.IdConsulta == consultaCuello.IdConsulta);
                 if (Original != null)
                 {
                     Original.AdenoPatias = consultaCuello.AdenoPatias;
                     Original.ArteriasCarotidas = consultaCuello.ArteriasCarotidas;
                     Original.ConfiguracionDelCuello = consultaCuello.ConfiguracionDelCuello;                   
                     Original.GangliosLinfaticos = consultaCuello.GangliosLinfaticos;
                     Original.LesionesPiel = consultaCuello.LesionesPiel;
                     Original.PresionVenosa = consultaCuello.PresionVenosa;
                     Original.Simetrico = consultaCuello.Simetrico;
                 }
             }
             else
             {
                 Contexto.ConsultaCuelloes.Add(consultaCuello);
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
     public  List<Entities.ConsultaCuello> Listar()
     {
         return null;
     }
     public List<Entities.ConsultaCuello> ListaPorConsulta(int idConsulta)
     {
         using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
         {
             List<Entities.ConsultaCuello> lista = (from tabla in Contexto.ConsultaCuelloes.AsNoTracking()
                                                    where tabla.IdConsulta == idConsulta
                                                    select tabla).ToList();
             return lista;
         }
     }
    }
}
