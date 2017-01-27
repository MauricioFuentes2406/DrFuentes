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
        public static ComboBox llenarComboGenerico(ComboBox combo, List<T> lista)
         {
             combo.DataSource = lista;
             combo.DisplayMember="nombre";
             combo.ValueMember="valor";
             return combo;
         }
        /// <summary>
        /// La diferencia es este para jalar los comboBox que viene de la BaseDatos
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
