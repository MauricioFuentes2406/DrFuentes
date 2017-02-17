using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias añadias
using System.Windows.Forms;
namespace ClinicaPro.BL
{
    public  class ComboBoxBL<T>  // Aun probando
    {      
        /// <summary>
        /// Configura los comboBox que carga los datos de la BD , PD: la columna de tabla debe llamarse nombre  
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="lista"></param>
        /// <returns></returns>               
           public void fuenteBaseDatos(ComboBox combo, List<T> lista, string nombreID)
           {
               combo.DataSource = lista;
               combo.DisplayMember = "Nombre";
               combo.ValueMember = nombreID;               
           }          
    }
}
