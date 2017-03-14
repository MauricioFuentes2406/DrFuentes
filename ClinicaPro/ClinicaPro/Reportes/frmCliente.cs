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
using ClinicaPro.DB.Cliente;
	
namespace ClinicaPro.Reportes
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.chartCobroAnoActual.DataSource = SPReportes.ClienteLugares();
                DatosGenerales();
                RangoEdades();
            }
            catch (Exception)
            {
                              
            }
           
        }
        private void RangoEdades()
        {
            var list = ClienteDB.PersonasRangoEdad();

            this.chartRangoEdades.Series[0].Points.AddXY("1-20", list.ElementAt(0));            
            this.chartRangoEdades.Series[0].Points.AddXY("21-40", list.ElementAt(1));          
            this.chartRangoEdades.Series[0].Points.AddXY("41-50", list.ElementAt(2));
            this.chartRangoEdades.Series[0].Points.AddXY(">50", list.ElementAt(3));
        }
        /// <summary>
        /// Datos de de los texto de pestaña general
        /// </summary>
        private void DatosGenerales()
        {
            this.txtTotalHombres.Text = ClienteDB.TotalHombres().ToString();
            this.txtMujeres.Text = ClienteDB.TotalMujeres().ToString();
            this.txtExtrajeros.Text = ClienteDB.TotalExtrajeros().ToString();
            this.txtClientesTotal.Text = ClienteDB.TotalClientes().ToString();
        }                    
    }
}
