﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.General.Constantes
{
    /// <summary>
    /// Estas clase funcionan como alternativas a los Enumerados para llenar los comboBox, 
    /// La ventaja es no tener que estar haciendo tantos  cast para poder
    /// leer los valueMeber de las opciones,  de esta manera es mas sencilla configurarlos
    /// pues nada mas se pone como DataSource un array de la clase , 
    /// 
    /// Luego displaymember = "nombre"
    /// Value member = "valor"
    /// </summary>

   public  class claseGenerica_ComboBox  
    {
        public String nombre { get; set; }
        public byte valor { get; set; }

       /*
       No cambiar los nombres de estas variables                
        */

    }

}
