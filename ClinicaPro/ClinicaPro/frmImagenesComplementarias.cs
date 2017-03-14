using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Libreria Añadidas
using ClinicaPro.BL;
using ClinicaPro.General.Constantes;

namespace ClinicaPro
{
    public partial class frmImagenesComplementarias : Form
    {
        private int idCliente;
        private string filename;

        public frmImagenesComplementarias(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
        }

        private void frmImagenesComplementarias_Load(object sender, EventArgs e)
        {
            ClinicaPro.BL.manejaImagenes.ConfigurarFileDialogFilter(this.openFileDialog1);
        }
        private void btnExaminarImagen_Click(object sender, EventArgs e)
        {
            DialogResult resultado = openFileDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                try
                {
                    this.pictureBox1.Load(openFileDialog1.FileName);
                    this.filename = openFileDialog1.FileName;
                }catch (ArgumentException)
                {
                    MessageBox.Show(this, Mensajes.ExtencionImagen, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    return;                    
                }               
            }
        }
        private void limpiar()
        {
            this.pictureBox1.Image = null;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
             Byte[] ByteArray = manejaImagenes.ImagenABitArray(filename, pictureBox1);
             bool result= ClinicaPro.DB.Cliente.ImagenesExamenesComplementariasBD.agregarImagen(ByteArray, this.idCliente);
            if (result)
            {
                MessageBox.Show(this,Mensajes.Agregar_Modificar,"Imagenes complementarias"
                                ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
        }
    }
}
