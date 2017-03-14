using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias Añadidas
using ClinicaPro.DB.Reportes;
using ClinicaPro.DB.Cita;

namespace ClinicaPro.Reportes
{
    public partial class frmCitas : Form
    {
        public frmCitas()
        {
            InitializeComponent();
        }
        private void frmCitas_Load(object sender, EventArgs e)
        {
            CargarCitasTotal();
            CargarCitasCategoria();
        }
        private void CargarCitasTotal()
        {
            var list = SPReportes.CitasTotal();
            this.chartCitaTotal.Series[0].Points.DataBind(list, "Mes", "Cantidad", "");
            DatosGenerales(); 
        }
        private void CargarCitasCategoria()
        {
            var list = SPReportes.CitasCategoria();
            this.chartCitaCAtegoria.Series[0].Points.DataBind(list, "EstadoCita", "Cantidad", "");
        }
        private void DatosGenerales()
        {
            var cita = CitasDB.EstadisticasCitas();
            if (cita != null)
            {
                this.txtClienteAsociado.Text = cita.CitasClienteAsociados.ToString();
                this.txtNoCliente.Text = cita.CitasNoClienteAsociado.ToString();
                this.txtNoPresentaron.Text = cita.NoSepresetaron.ToString();
                this.txtSePresentaron.Text = cita.SePresentaron.ToString();
                this.txtTotal.Text = cita.TotalCitas.ToString();
            }
        }                  
    }
}
