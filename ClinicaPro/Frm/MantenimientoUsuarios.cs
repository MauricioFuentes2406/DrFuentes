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
    public partial class MantenimientoUsuarios : Form
    {
        public MantenimientoUsuarios()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new AgregarUsuario().Show();
        }
    }
}
