using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm
{
    public partial class Secretaria : Form
    {
        private int _tipoUsuario;
        public Secretaria(int tipoUsuario)
        {
            InitializeComponent();
            this._tipoUsuario = tipoUsuario;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            new MantenimientoCliente(this._tipoUsuario).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm.Citas.frmGeneralCitas frmCitas = new Citas.frmGeneralCitas(this._tipoUsuario);
        }
    }
}
