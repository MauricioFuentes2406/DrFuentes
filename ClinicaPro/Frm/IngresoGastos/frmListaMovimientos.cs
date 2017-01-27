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
using ClinicaPro.DB.GastosIngresos.Vistas;
using ClinicaPro.General.Constantes;
using ClinicaPro.DB.GastosIngresos;

namespace Frm.IngresoGastos
{
    public partial class frmListaMovimientos : Form
    {
        public int idTipoUsuario { get; set; }

        private const int Gasto = 0;
        private const int Ingreso = 1;

        public frmListaMovimientos(int idtipousuairo)
        {
            InitializeComponent();           
            this.idTipoUsuario = idtipousuairo;
        }

        private void frmListaMovimientos_Load(object sender, EventArgs e)
        {
            this.cbIngresoOEgreso.SelectedIndex = 0;
            this.cbMes.SelectedIndex = 0;
            cargarcomboAno();
            cargarGrid(this.cbIngresoOEgreso.SelectedIndex);                                    
        }
        #region Metodos
        private void cargarGrid( int IngresoEgresoIndex )
        {
            if (IngresoEgresoIndex == Gasto)
                cargarGastos();
            else
            { cargarIngresos(); }

             OcultarColumnas();
             AlternarColoresEnGrid();
             SumarTotal();
        }
        private void cargarGastos()
        {
            if (chk_Todo.Checked)
                this.dgMovimientos.DataSource = VGasto.ListarTodo(this.idTipoUsuario);
            else if (cbMes.SelectedIndex == Meses.MesActual)
            {
                this.dgMovimientos.DataSource = VGasto.ListaMesActual(this.idTipoUsuario);
            }
            else if (cbMes.SelectedIndex == Meses.Todos)
                this.dgMovimientos.DataSource = VGasto.ListaPorAño(this.idTipoUsuario, (int)cbAño.SelectedValue);
            else
                this.dgMovimientos.DataSource = VGasto.ListaPorMesYAños(idTipoUsuario, cbMes.SelectedIndex, (int)cbAño.SelectedValue);
        }
        private void cargarIngresos()
        {
            if (chk_Todo.Checked)
                this.dgMovimientos.DataSource = VIngreso.ListarTodo(this.idTipoUsuario);
            else if (cbMes.SelectedIndex == Meses.MesActual)
            {
                this.dgMovimientos.DataSource = VIngreso.ListaMesActual(this.idTipoUsuario);
            }
            else if (cbMes.SelectedIndex == Meses.Todos)
                this.dgMovimientos.DataSource = VIngreso.ListaPorAño(this.idTipoUsuario, (int)cbAño.SelectedValue);
            else
                this.dgMovimientos.DataSource = VIngreso.ListaPorMesYAños(idTipoUsuario, cbMes.SelectedIndex, (int)cbAño.SelectedValue);
        }
        private void OcultarColumnas()
        {
            this.dgMovimientos.Columns[0].Visible = false;
            this.dgMovimientos.Columns[1].Visible = false;
        }
        private void AlternarColoresEnGrid()
        {
            if (this.cbIngresoOEgreso.SelectedIndex == Gasto)
                this.dgMovimientos.Columns[3].DefaultCellStyle.ForeColor = Color.Maroon;
            else
                this.dgMovimientos.Columns[3].DefaultCellStyle.ForeColor = Color.ForestGreen;
        }
        private void CambiarIcono()
        {
            if (this.cbIngresoOEgreso.SelectedIndex == Gasto)
            {
                if (pictureBox1.Image != Frm.Properties.Resources.minus_1)
                {
                    pictureBox1.Image = Frm.Properties.Resources.minus_1;
                }
            }
            else
            {
                if (pictureBox1.Image != Frm.Properties.Resources.add_1)
                {
                    pictureBox1.Image = Frm.Properties.Resources.add_1;
                }
            }
        }
        private void cargarcomboAno()
        {
            cbAño.DataSource = new ClinicaPro.DB.GastosIngresos.GastosDB().ListarAnosUsados(idTipoUsuario);
        }
        private void ReestablecerFiltros()
        {
            cbMes.SelectedIndex = 0;
            cbAño.SelectedIndex = 0;
            chk_Todo.Checked = false;
        }
        private List<int> GetIdsFilasSeleccionadas()
        {
            List<int> Identificadores = new List<int>();
                    foreach (DataGridViewRow fila in dgMovimientos.SelectedRows)
                    {
                        Identificadores.Add((int)fila.Cells[1].Value);   //Fila 1 corresponde Idgasto o IdIngresos
                    }
                    return Identificadores;
        }
        private void SumarTotal()
        {
            int suma = 0;
            if (this.dgMovimientos.Rows.Count <= 0)
            {
                numTotal.Value = 0;
                return;
            }
            try
            {
                foreach (DataGridViewRow fila in this.dgMovimientos.Rows)
                {                    
                    suma += (int)fila.Cells[3].Value;
                }
                 if ( numTotal.Value != suma)
                 {
                     numTotal.Value = suma;
                 }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensajes.HuboErrorConteo , "Conteo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);                                
            }            
        }
        #endregion           
        #region Eventos
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid(cbIngresoOEgreso.SelectedIndex);
            ReestablecerFiltros();
        }
        private void cbIngresoOEgreso_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarGrid(cbIngresoOEgreso.SelectedIndex);
            CambiarIcono();
        }
        private void cbMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarGrid(cbIngresoOEgreso.SelectedIndex);
        }

        private void cbAño_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbMes.SelectedIndex == Meses.Todos)
            {
                this.dgMovimientos.DataSource = VGasto.ListaPorAño(idTipoUsuario, (int)cbAño.SelectedValue);
            }
            else
                this.dgMovimientos.DataSource = VGasto.ListaPorMesYAños(this.idTipoUsuario, cbMes.SelectedIndex, (int)cbAño.SelectedValue);
            SumarTotal();
        }
        private void chk_Todo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_Todo.Checked == false)
            {
                this.chk_Todo.BackgroundImage = global::Frm.Properties.Resources.switch_OFF;
                cbMes.Enabled = true;
                cbAño.Enabled = true;
            }
            else
            {
                this.chk_Todo.BackgroundImage = global::Frm.Properties.Resources.switch_ON;
                cbMes.Enabled = false;
                cbAño.Enabled = false;
            }
            cargarGrid(cbIngresoOEgreso.SelectedIndex);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
            {                
                if (dgMovimientos.SelectedRows.Count > 0)
                {
                    List<int> Identificadores = GetIdsFilasSeleccionadas();
 
                    if (cbIngresoOEgreso.SelectedIndex == Gasto)
                    {
                        new GastosDB().Eliminar(Identificadores, this.idTipoUsuario);
                    }
                    else { new IngresoDB().Eliminar(Identificadores, this.idTipoUsuario); }
                }
                else
                {
                    MessageBox.Show(Mensajes.Seleccione_Una_Fila, Mensajes.Upss_Falto_Algo,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cargarGrid(cbIngresoOEgreso.SelectedIndex);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgMovimientos.SelectedRows.Count == 1)
            {
                // SelectdId Almacena el id sea de gasto o Ingreo
                int selectedID = (int)this.dgMovimientos.CurrentRow.Cells[1].Value;
                if (cbIngresoOEgreso.SelectedIndex == Gasto)
                {
                    using (frmAgregarGastos frmgastos = new frmAgregarGastos(selectedID, idTipoUsuario))
                    {
                        frmgastos.ShowDialog();
                    }
                }
                else
                {
                    using (frmAgregarIngreso frmIngreso = new frmAgregarIngreso(selectedID, idTipoUsuario))
                    {
                        frmIngreso.ShowDialog();
                    }
                }
                cargarGrid(cbIngresoOEgreso.SelectedIndex);
            }
            else
                MessageBox.Show(Mensajes.Seleccione_Una_Fila + "\n Una sola Fila ", Mensajes.Upss_Falto_Algo,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (dgMovimientos.SelectedRows.Count == 1)
            {
                // SelectdId Almacena el id sea de gasto o Ingreo 
                int selectedID = (int)this.dgMovimientos.CurrentRow.Cells[1].Value;
                if (cbIngresoOEgreso.SelectedIndex == Gasto)
                {
                    if (new GastosDB().Clone(selectedID) > 0)
                    {
                        MessageBox.Show("Mensaje Actualizado");
                    }
                }
                else
                {
                    if (new IngresoDB().Clone(selectedID) > 0)
                    {
                        MessageBox.Show("Mensaje Actualizado");
                    }
                }
                cargarGrid(cbIngresoOEgreso.SelectedIndex);
            }
            else
                MessageBox.Show(Mensajes.Seleccione_Una_Fila + "\n Una sola Fila ", Mensajes.Upss_Falto_Algo,
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cargarGrid(cbIngresoOEgreso.SelectedIndex);
            CambiarIcono();
        }          
        #endregion                               
    }
}
