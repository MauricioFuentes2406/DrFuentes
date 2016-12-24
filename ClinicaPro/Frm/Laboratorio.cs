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
    public partial class Laboratorio : Form
    {
        public Laboratorio()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AgregarExamenes().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new AgregarTipoExamen().Show();
        }
    }
}
