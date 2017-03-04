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
        public static void ProblemaConexion ()
        {

        }
    }
}
