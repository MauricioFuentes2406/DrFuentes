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
    public partial class AuxiliarLogin : Form
    {
        public AuxiliarLogin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Secretaria().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Frm.Laboratorio.LaboratorioGeneral().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Administrador().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GeneralPrincipal().Show();
            this.Hide();
            this.Close();
        }

        private void AuxiliarLogin_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new PaPobrarSparse().Show();
        }
    }
}
