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
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {        
            new AuxiliarLogin().Show();
            this.Hide();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.AntecedenteDrogaDB.oso();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            new frmBusquedas().ShowDialog();
        }

      
    }
}
