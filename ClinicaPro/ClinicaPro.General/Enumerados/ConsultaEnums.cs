using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias Anañadidas

using ClinicaPro.General.Constantes;

namespace ClinicaPro.General.Enumerados
{
    public class ConsultaEnums
    {
        public enum Fuente_y_Veracidad
        {
            Directa = 1,
            Indirecta,
            Confiable,
            No_Confiable
        }


        public enum enumNariz
        {
            Rinorrea = 0,
            Epitaxis,
            Sinusitis,
            ResfríoFrecuente
        }

        public static readonly claseGenerica_ComboBox[] colorVomito = new[]
      {
        new claseGenerica_ComboBox{
                nombre = "Alimenticio",
                valor = 1 
            },
            new claseGenerica_ComboBox{
                nombre = "Marrón",
                valor = 2 
            },
        new claseGenerica_ComboBox{
                nombre = "Rojo",
                valor = 3},
                  new claseGenerica_ComboBox
                  {
                nombre = "Blanco",
                valor =4 
             },
         new claseGenerica_ComboBox{
                nombre = "Rojo Oscuro",
                valor = 5}

      };


        #region  Escala de Glasgow



        #endregion



    }
}
