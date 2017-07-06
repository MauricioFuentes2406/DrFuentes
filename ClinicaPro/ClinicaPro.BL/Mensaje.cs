using System;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
using System.Windows.Forms;
using ClinicaPro.General.Constantes;

namespace ClinicaPro.BL
{
    public class Mensaje
    {
        /// <summary>
        ///  Windows Dialog, Pregunta al usuario si esta seguro de Eliminar
        /// </summary>
        /// <returns></returns>
        public static bool  isSeguroDeEliminar()
        {
            DialogResult dialogresult = MessageBox.Show(Mensajes.Esta_Seguro_Eliminar,
                                            "Eliminar",
                                            MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);
            if (dialogresult == DialogResult.Yes)
                return true;
            else return false;
        }                
      public static void MensajeGuardadoEnDB (String nombreFormulario)
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                            nombreFormulario,
                                              MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Information);
                
        }
      public static void MensajeSeleccionUnaFila()
      {
          MessageBox.Show(Mensajes.Seleccione_Una_Fila,
                                           Mensajes.Upss_Falto_Algo ,
                                            MessageBoxButtons.OKCancel,
                                              MessageBoxIcon.Information);

      }
           
    }
}
