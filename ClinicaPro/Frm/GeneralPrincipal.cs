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
    public partial class GeneralPrincipal : Form
    {
        public int idCliente { get; set; }
        public String nombreCompleto { get; set; }
        public GeneralPrincipal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MantenimientoCliente Cl = new MantenimientoCliente();
            Cl.Show();         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MantenimientoConsulta frmMantenimientoConsulta = new MantenimientoConsulta();
            frmMantenimientoConsulta.Show();

          //  AgregarConsulta Co = new AgregarConsulta(idCliente);  // Falta anadir parametro idCLiente
           // Co.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Expediente().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Frm.IngresoGastos.frmVentanaInicial().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new MantenimientoInventario().Show();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
           using(  ConfiguracionGeneral ventanaConfiguracionGeneral = new ConfiguracionGeneral())
           {
               ventanaConfiguracionGeneral.ShowDialog();
           }

        }
    }
}
