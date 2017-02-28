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
        private bool _IsFiltradaPorDiagnosticoEstado = false;

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
            int IdConsulta = getIdConsultaDataGridView();
            this.Hide();
            this.dgConsulta.Dispose();
            this.Close();
            new AgregarConsulta(IdCliente,IdConsulta,nombre).Show();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgConsulta.SelectedRows.Count >= 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    new ClinicaPro.DB.Consulta.ConsultaDB().Eliminar(getIdConsultaDataGridView(), this.IdCliente);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.Seleccione_Una_Fila, "Para Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private int  getIdConsultaDataGridView()
        {
            if (dgConsulta.SelectedRows.Count == 1)
            {
               return (int)this.dgConsulta.CurrentRow.Cells["Número_Consulta"].Value;
            }
            else return -1;
        }

        /// <summary>
        /// Oculta las filas En Con estado Diagnostico false, no consulta a la DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRechazados_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgConsulta.Rows)
            {
                bool DiagnosticoEstado = (bool)row.Cells["Diagnostico_Confirmado"].Value;
               if (DiagnosticoEstado)
               {                                                  
                   row.Visible = false;                                                                                   
               }
            }
        }
        
    }
}
