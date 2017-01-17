using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.BL
{
   public class SystemProces
    {
       public static void AbrirCalculadoraWindows()
       {
           try
           {
               System.Diagnostics.Process.Start("calc");
           }
           catch (Exception)
           {
               System.Windows.Forms.MessageBox.Show("No se pudo Abrir la Calculadora");               
           }
           
       }
    }
}
