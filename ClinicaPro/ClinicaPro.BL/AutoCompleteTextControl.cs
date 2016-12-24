using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias Añadidas
using System.Windows.Forms;


namespace ClinicaPro.BL
{
    public class AutoCompleteTextControl
    {
        /// <summary>
        /// Activa el AutoComplete modo "Suggest" en un Control Texto, puede crear un ListarNombre en DB 
        /// </summary>
        /// <param name="txtAlgo">txtSomething</param>
        /// <param name="listaNombres">Nombre Sugeridos</param>
        public static void Activar(TextBox txtAlgo, List<String> listaNombres)
        {
            txtAlgo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAlgo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (String nombre in listaNombres)
            {
                autoCompleteCollection.Add(nombre);
            }
            txtAlgo.AutoCompleteCustomSource = autoCompleteCollection;
        }
        /// <summary>
        /// Desactiva el modo AutoComlete de un Control Texto
        /// </summary>
        /// <param name="txtAlgo"></param>
        public static void DesActivar(TextBox txtAlgo)
        {
            txtAlgo.AutoCompleteMode = AutoCompleteMode.None;
            txtAlgo.AutoCompleteSource = AutoCompleteSource.None;
        }
    }
}
