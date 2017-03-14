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
using ClinicaPro.Entities;

namespace Frm.Configuracion
{
    public partial class frmServicios : Form
    {
        //Atributo        
        public int IdUsuario { get; set; }
        public int idServicio { get; set; }
        public frmServicios()
        {
            InitializeComponent();
            this.idServicio = -1;
        }
        private void frmServicios_Load(object sender, EventArgs e)
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
            if (txtPrecio.Value == 0 )
            {
                detalles += "Campo  Precio" + Mensajes.Numero_Mayor_Cero;
                this.txtPrecio.BackColor = System.Drawing.Color.AliceBlue;
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
                                      " Servicios ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private void cargarGrid()
        {
            GeneralTipoServicioDB servicioDb = new GeneralTipoServicioDB();
            this.dgServicios.DataSource = servicioDb.Listar();
            dgServicios.Columns[comboNombreIDs.GeneralServicio].Visible = false;
        }
        private void Limpiar()
        {
            this.idServicio = -1;
            this.txtNombre.ResetText();
            this.chkIsEditable.Checked = false;
            this.txtPrecio.Value = 0;
            cargarGrid();
            txtNombre.Focus();
        }
        private GeneralTipoServicio Servicio_ControlAClase()
        {
            GeneralTipoServicio servicio = new GeneralTipoServicio();
            servicio.Nombre = txtNombre.Text.Trim();
            servicio.IsPrecioEditable = this.chkIsEditable.Checked;
            servicio.Precio = (int) this.txtPrecio.Value;
            return servicio;
        }
        #endregion
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                GeneralTipoServicio service = Servicio_ControlAClase();
                GeneralTipoServicioDB servicioDb = new GeneralTipoServicioDB();
                if (servicioDb.Agregar_Modificar(service, ClinicaPro.General.accion.Agregar) != 0)
                {
                    Limpiar();                    
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                if ( dgServicios.SelectedRows.Count == 1)
                {
                    this.idServicio = (int)dgServicios.SelectedRows[0].Cells[comboNombreIDs.GeneralServicio].Value;
                
                GeneralTipoServicio service = Servicio_ControlAClase();
                service.idServicio = this.idServicio;

                GeneralTipoServicioDB servicioDb = new GeneralTipoServicioDB();
                if (servicioDb.Agregar_Modificar(service, ClinicaPro.General.accion.Modificar) != 0)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
               }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgServicios.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    this.idServicio = (int)dgServicios.SelectedRows[0].Cells[comboNombreIDs.GeneralServicio].Value;
                    GeneralTipoServicioDB servicioDb = new GeneralTipoServicioDB();
                    if (servicioDb.Eliminar(this.idServicio, this.IdUsuario))
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
        private void dgServicios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = sender as DataGridView;
            this.txtNombre.Text = (string)senderGrid.CurrentRow.Cells["Nombre"].Value;
            this.txtPrecio.Value = (int)senderGrid.CurrentRow.Cells["Precio"].Value;
            this.chkIsEditable.Checked = (bool)senderGrid.CurrentRow.Cells["IsPrecioEditable"].Value;
        }
        private void chkLimpiar_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
        }      
    }
}
