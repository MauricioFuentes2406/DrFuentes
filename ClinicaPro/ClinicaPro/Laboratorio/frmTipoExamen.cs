using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Libreria Añadidas

using ClinicaPro.DB.Laboratorio;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;

namespace ClinicaPro.Laboratorio
{
    public partial class frmTipoExamen : Form
    {       
        public int IdTipoExamen { get; set; }
        /// <summary>
        /// = -1
        /// </summary>
        public frmTipoExamen()
        {
            InitializeComponent();
            this.IdTipoExamen = -1;
        }

        private void frmTipoExamen_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        #region Metodos 
        ///<summary>
        ///  Valida los campos que no esten vacios ni incosistentes , los pone Color.AliceBlue
        ///  <value>String Detalles, usado para crear una cadena al final con detalles  </value>
        ///  <value>boolean hallazgo, usado como bandera, si encontro algo = true </value>
        ///  <return>hallazgo</return>
        /// </summary>   
        private Boolean Validar()
        {
            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (txtNombre.Text == String.Empty)
            {
                detalles += "Campo Nombre" + Mensajes.Campo_Requerido;
                this.txtNombre.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }
            private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      " TipoExamenes ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
           private TipoExamenes TipoExamen_ControlAClase()
        {
            TipoExamenes tipo = new TipoExamenes();
            tipo.Nombre = txtNombre.Text.Trim();
            tipo.CostoExamen = (int)numCosto.Value;
            tipo.DiasDeCultivo = (int)numDiasCultivo.Value;
            tipo.isEnviadoASanJose = chkEnvio.Checked;
            tipo.ProcentajeComisionEnvio = (int)numPorcentaje.Value;               
            return tipo;
        }
         private void cargarGrid()
        {
            TipoExamenDB tip = new TipoExamenDB();
            this.dgTipoExamen.DataSource = tip.Listar();
            dgTipoExamen.Columns[0].Visible = false;
           // dgTipoExamen.Columns[6].Visible = false;
        }
         private void Limpiar()
         {
             this.IdTipoExamen = -1;
             this.txtNombre.ResetText();
             this.numCosto.Value = 0;
             this.numDiasCultivo.Value = 0;
             this.numPorcentaje.Value = 0;
             this.chkEnvio.Checked = false;             
             cargarGrid();
             txtNombre.Focus();
         }
        #endregion
        #region Eventos
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                TipoExamenes tipo = TipoExamen_ControlAClase();
                TipoExamenDB tipoDb = new TipoExamenDB();
                if (tipoDb.Agregar_Modificar(tipo, ClinicaPro.General.accion.Agregar) != -1)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                if (dgTipoExamen.SelectedRows.Count == 1)
                {
                    this.IdTipoExamen = (int)dgTipoExamen.CurrentRow.Cells[comboNombreIDs.TipoExamenes].Value;
                }
                TipoExamenes tipo = TipoExamen_ControlAClase();
                tipo.idTipoExamen = this.IdTipoExamen;
                TipoExamenDB tipoDb = new TipoExamenDB();
                if (tipoDb.Agregar_Modificar(tipo, ClinicaPro.General.accion.Modificar) != -1)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgTipoExamen.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    this.IdTipoExamen = (int)dgTipoExamen.CurrentRow.Cells[comboNombreIDs.TipoExamenes].Value;
                    TipoExamenDB tipoDb = new TipoExamenDB();
                    if (tipoDb.Eliminar(this.IdTipoExamen, 0))
                    {
                        Limpiar();
                        MensajeDeActulizacion();
                    }
                }
            }
            else
            {
                MessageBox.Show(Mensajes.Seleccione_Una_Fila, Mensajes.Upss_Falto_Algo,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
        
    }
}
