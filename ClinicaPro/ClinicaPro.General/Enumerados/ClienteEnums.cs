using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using ClinicaPro.General.Constantes;

namespace ClinicaPro.General.Enumerados
{
   public class ClienteEnums 
    {
        
             // N.S = No sabe
        public static readonly String[] TipoDeSangre = { "N.S" ,"0+", "0-", "A+", "A-", "B-", "B+", "AB-", "AB+" };
           // Para llenar los comboBox que son de tipo Boolean
        public static readonly String[] RespuestaBasica = { "No","Si"};

        public static readonly claseGenerica_ComboBox[] EstadoCivil = new[]
      {
        new claseGenerica_ComboBox{
                nombre = "Soltero",
                valor = 1 
            },
        new claseGenerica_ComboBox{
                nombre = "Casado",
                valor = 2},

                  new claseGenerica_ComboBox
                  {
                nombre = "Divorciado",
                valor =3 }
      };
    }
}
