using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClinicaPro.DB.Consulta;

namespace Frm
{
    public partial class PaPobrarSparse : Form
    {
        public PaPobrarSparse()
        {
            InitializeComponent();
        }

        private void PaPobrarSparse_Load(object sender, EventArgs e)
        {
           // this.dataGridView1.DataSource = new ConsultaEstadoEmocionalDB().Listar();
            
            //this.dataGridView1.DataSource = ClinicaPro.DB.Cliente.ClienteDB.ListarNombresCiudad();
            foreach (var item in ClinicaPro.DB.Cliente.ClienteDB.ListarNombresCiudad())
            {
                MessageBox.Show(item);
            }
        }

    }
}
