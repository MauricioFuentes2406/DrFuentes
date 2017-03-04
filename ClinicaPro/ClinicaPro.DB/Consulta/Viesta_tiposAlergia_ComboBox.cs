using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias añadidas
using ClinicaPro.Entities;
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB.Consulta
{
   public class Viesta_tiposAlergia_ComboBox
    {
       public static List<Vista_TiposAlergia_comboBox> Listar()
        {
            try
            {
                 ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();
                 List<Entities.Vista_TiposAlergia_comboBox> ListaTipoAlergias = (from tabla in
                                                                                     Contexto.Vista_TiposAlergia_comboBox
                                                                                       select tabla).ToList();
                 return ListaTipoAlergias;
            }           
            catch (EntityException entityException)
            {                               
                manejaExcepcionesDB.manejaEntityException(entityException);
                return  null;
            }
            catch (NullReferenceException nullReference)
            {
                manejaExcepcionesDB.manejaNullReference(nullReference);
                return null;
            }
            catch (Exception ex)
            {
                manejaExcepcionesDB.manejaExcepcion(ex);
                return null;
            }           

        }      
    }
}
