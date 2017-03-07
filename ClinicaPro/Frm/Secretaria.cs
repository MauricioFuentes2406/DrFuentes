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
        private void Secretaria_Load(object sender, EventArgs e)
        {

        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            new MantenimientoCliente(this._tipoUsuario).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm.Citas.frmGeneralCitas frmCitas = new Citas.frmGeneralCitas(this._tipoUsuario);
            frmCitas.ShowDialog();
            frmCitas.Dispose();
        }

        private void Secretaria_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
       
    }
}
