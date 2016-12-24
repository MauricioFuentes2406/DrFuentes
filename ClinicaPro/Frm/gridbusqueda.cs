using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClinicaPro.DB;


namespace Frm
{
    public partial class gridbusqueda : Form
    {
        public gridbusqueda()
        {
            InitializeComponent();
        }

        private void gridbusqueda_Load(object sender, EventArgs e)
        {
            ClinicaPro.DB.BusquedaDB oso = new ClinicaPro.DB.BusquedaDB();
            this.dataGridView1.DataSource = oso.Listar();            
            this.dataGridView1.Columns["BusquedaImagenes"].Visible = false;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection( );           

            foreach (String nombre in BusquedaDB.ListarNombres() )
            {
                auto.Add(nombre);
            }
            textBox1.AutoCompleteCustomSource = auto;
           

        }
    }
}
