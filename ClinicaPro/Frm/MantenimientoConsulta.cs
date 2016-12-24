using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias Añadias

namespace Frm
{
    public partial class MantenimientoConsulta : Form
    {
        //        ~~~~~~~~~~~~~~~~~~ Atributos  ~~~~~~~~~~~~~~~~~~~~~~~~

        public int IdCliente { get; set; }
        private const String Numero_Cliente = "Número_Cliente";
        private const String Numero_Consulta = "Número Consulta";

        //        ~~~~~~~~~~~~~~~~~~ Constructor  ~~~~~~~~~~~~~~~~~~~~~~~~
        public MantenimientoConsulta()
        {
            InitializeComponent();
        }
        public MantenimientoConsulta(int IdCliente)
        {
            InitializeComponent();
            this.IdCliente = IdCliente;
        }
        private void MantenimientoConsulta_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        #region Metodos
        private void CargarDatos()
        {
            ClinicaPro.DB.Consulta.Vistas.VConsulta.LlenarGridSoloDatosConsulta(dgConsulta);           
        }              
        #endregion

        #region Eventos
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        #endregion

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string nombre = this.dgConsulta.CurrentRow.Cells["Nombre"].Value.ToString();
            int IdCliente = (int)this.dgConsulta.CurrentRow.Cells["Número_Cliente"].Value;
            int IdConsulta = (int)this.dgConsulta.CurrentRow.Cells["Número_Consulta"].Value;
            this.Hide();
            this.dgConsulta.Dispose();
            this.Close();
            new AgregarConsulta(IdCliente,IdConsulta,nombre).Show();
        }
        
    }
}
