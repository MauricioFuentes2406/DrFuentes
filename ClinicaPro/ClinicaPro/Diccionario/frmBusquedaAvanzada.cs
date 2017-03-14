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
using ClinicaPro.DB.Consulta;
using ClinicaPro.General.Constantes;

namespace ClinicaPro.Diccionario
{
    public partial class frmBusquedaAvanzada : Form
    {
        public frmBusquedaAvanzada()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void frmBusquedaAvanzada_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void cargarGrid()
        {
            this.dgBusqueda.DataSource = new ClinicaPro.DB.BusquedaDB().Listar();
            OcultarIdColumn();
        }
        private void OcultarIdColumn()
        {
            this.dgBusqueda.Columns[0].Visible = false;
            this.dgBusqueda.Columns["BusquedaImagenes"].Visible = false;
        }
        private void Limpiar()
        {
            txtDescricpcion.ResetText();
            txtEnfeRelacionada.ResetText();
            txtNombre.ResetText();
            txtSintoma.ResetText();
            txtTratamiento.ResetText();
        }
        private void txtTratamiento_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void btnBusquedaNombre_Click(object sender, EventArgs e)
        {
            var resultado = new ClinicaPro.DB.BusquedaDB().ListarNombre(txtNombre.Text);
            validarBusqueda(resultado);
        }       
        private void btnBusquedaSintoma_Click(object sender, EventArgs e)
        {
            var resultado = new ClinicaPro.DB.BusquedaDB().ListarSintoma(txtSintoma.Text);
            validarBusqueda(resultado);
        }

        private void btnBusquedaTratamiento_Click(object sender, EventArgs e)
        {
            var resultado = new ClinicaPro.DB.BusquedaDB().ListarTratamiento(txtTratamiento.Text);
            validarBusqueda(resultado);
        }

        private void btnBusquedaEnfermedadRelaionada_Click(object sender, EventArgs e)
        {
          var resultado = new ClinicaPro.DB.BusquedaDB().ListarEnfermedadRelacionada(txtEnfeRelacionada.Text);
          validarBusqueda(resultado);
        }

        private void btnBusquedaDescripcion_Click(object sender, EventArgs e)
        {
           var resultado = new ClinicaPro.DB.BusquedaDB().ListarDescripcion(txtDescricpcion.Text);
           validarBusqueda(resultado);
        }
        /// <summary>
        /// Si hay mas de  un  resultado actualiza Grid, sino muestra un mensaje
        /// </summary>
        /// <param name="resultado"></param>
        private void validarBusqueda(List<ClinicaPro.Entities.Busqueda>  resultado)
        {
            if (resultado.Count == 0)
            {
                MessageBox.Show(Mensajes.No_Se_Encontro_Ningun_Registro, "Intenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                this.dgBusqueda.DataSource = resultado;
        }
    }
}
 