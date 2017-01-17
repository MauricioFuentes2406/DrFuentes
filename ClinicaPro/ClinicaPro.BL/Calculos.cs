using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.BL
{
   public class Calculos
    {
      public static decimal IndiceMasaCorporal(decimal peso, decimal talla )
       {
           if (peso > 0)
               return peso / (talla * talla);
           else return 0;
       }
       public static int Saldo(int Ingreso , int Gasto )
      {
          return Ingreso - Gasto;
      }
    }
}
