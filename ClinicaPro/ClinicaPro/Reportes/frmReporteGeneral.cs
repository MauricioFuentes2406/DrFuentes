using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaPro.Reportes
{
    public partial class frmReporteGeneral : Form
    {
        public int IdTipoUsuario { get; set; }
        public frmReporteGeneral( int IdTipoUsuario)
        {
            this.IdTipoUsuario = IdTipoUsuario;
            InitializeComponent();
        }     
        private void btnCliente_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Reportes.frmCliente().Show();
        }
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Reportes.frmConsultas().Show();
        }
        private void btnGastosIngresos_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Reportes.frmIngresoEgreso(this.IdTipoUsuario).Show();
        }
        private void btnCitas_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Reportes.frmCitas().Show();
        }

        private void frmReporteGeneral_Load(object sender, EventArgs e)
        {

        }
    }
}
