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

namespace ClinicaPro.Seguimientos
{
    public partial class frmSeguimientos : Form
    {
        //Atributos
        public int IdSeguimeinto { get; set; }
        private int _IdConsulta;
        /// <summary>
        /// Uso Estetico
        /// </summary>
        private string _NombreCliente;
        public int IdConsulta 
        {
            get { return _IdConsulta; }
            set { 
                _IdConsulta = value ;
                this.txtNumeroConsulta.Text = _IdConsulta.ToString();
            }
        }
        /// <summary>
        /// = -1
        /// </summary>
        const int IdVacia = -1;     
        public frmSeguimientos(int IdConsulta,string NombreCliente)
        {
            InitializeComponent();
            this.IdConsulta = IdConsulta;
            this.IdSeguimeinto = -1;
            this._NombreCliente = NombreCliente;
        }   
        #region Eventos
        private void frmSeguimientos_Load(object sender, EventArgs e)
        {
            cargarGrid();
            this.lblNombre.Text = _NombreCliente;
            this.groupBox1.Focus();

        }
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
          
            if(txtDescripcion.Text == String.Empty)
            {
                detalles += "Campo Descripcion: " + Mensajes.Campo_Requerido;
                this.txtDescripcion.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtNumeroConsulta.Text == String.Empty || txtNumeroConsulta.Text == "-1" )
            {
                detalles += "Campo Número Consulta: " + Mensajes.Numero_Mayor_Cero;
                this.txtNumeroConsulta.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            } if (fechaValidar() )
            {
                detalles += "Campo Fecha: " + Mensajes.FechaAnterior;
                this.dtFecha.BackColor = System.Drawing.Color.AliceBlue;
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
                                      " Seguimientos ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private Seguimiento Seguimiento_ControlAClase()
        {
            Seguimiento segui = new Seguimiento();
            segui.Descripcion = txtDescripcion.Text.Trim();
            segui.FechaSeguimiento = dtFecha.Value;
            segui.IdConsulta = this.IdConsulta;
            if ( IdSeguimeinto != IdVacia)
            {
                segui.IdSeguimiento = this.IdSeguimeinto;
            }
            segui.isVisto = false;
            segui.Prioridad = (byte)numPrioridad.Value;
            return segui;
        }
        private void cargarGrid()
        {
            this.dgSeguimiento.DataSource = SeguimientoDB.Listar();
            dgSeguimiento.Columns["IdSeguimiento"].Visible = false;            
            dgSeguimiento.Columns["IdConsulta"].HeaderText = "Número_Consulta";
            dgSeguimiento.Columns["IsVisto"].Visible = false;
        }
        private void Limpiar()
        {
            this.IdSeguimeinto = -1;
            this.IdConsulta = -1;
            this.txtDescripcion.ResetText();
            this.txtNumeroConsulta.ResetText();
            cargarGrid();
            this.groupBox1.Focus();
        }
        private bool fechaValidar()
        {
            if (dtFecha.Value.Date < DateTime.Today)
                return true;
            else
                return false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                Seguimiento segui = Seguimiento_ControlAClase();              
                if (SeguimientoDB.Agregar(segui) != IdVacia)
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
                if (dgSeguimiento.SelectedRows.Count == 1)
                {
                    this.IdSeguimeinto = (int)dgSeguimiento.CurrentRow.Cells["IdSeguimiento"].Value;                   
                    Seguimiento segui = Seguimiento_ControlAClase();
                    if (SeguimientoDB.Modificar(segui) != IdVacia)
                    {
                        Limpiar();
                        MensajeDeActulizacion();
                    }                    
                }                             
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgSeguimiento.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    this.IdSeguimeinto = (int)dgSeguimiento.SelectedRows[0].Cells["IdSeguimiento"].Value;                    
                  
                    if (SeguimientoDB.Eliminar(this.IdSeguimeinto, this.IdConsulta))
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
        private void dgSeguimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.IdConsulta = (int)dgSeguimiento.CurrentRow.Cells["IdConsulta"].Value;
        }
        private void dgSeguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.IdConsulta = (int)dgSeguimiento.CurrentRow.Cells["IdConsulta"].Value;
            this.dtFecha.Value = (DateTime)dgSeguimiento.CurrentRow.Cells["FechaSeguimiento"].Value;
            this.numPrioridad.Value = (byte)dgSeguimiento.CurrentRow.Cells["Prioridad"].Value;
            this.txtDescripcion.Text = (string)dgSeguimiento.CurrentRow.Cells["Descripcion"].Value;
            this.txtDatosCargados.Visible = true;
            this.lblNombre.Visible = false;
            
        }
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (this.dgSeguimiento.SelectedRows.Count == 1  )
            {
                if (!fechaValidar())
                {                                       
                    // SelectdId Almacena el id sea de gasto o Ingreo 
                    int selectedID = (int)this.dgSeguimiento.CurrentRow.Cells["IdSeguimiento"].Value;
                    if (SeguimientoDB.Clone(selectedID, dtFecha.Value) > 0)
                    {
                        MensajeDeActulizacion();
                        cargarGrid();
                    }
                }else
                    MessageBox.Show(Mensajes.FechaAnterior, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            else
                MessageBox.Show(Mensajes.Seleccione_Una_Fila + "\n Una sola Fila ", Mensajes.Upss_Falto_Algo,
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
        }                
        private void btnCopiar_MouseEnter(object sender, EventArgs e)
        {
            this.dtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));           
        }
        private void btnCopiar_MouseLeave(object sender, EventArgs e)
        {
            this.dtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));           
        }                 
        private void dgSeguimiento_MouseLeave(object sender, EventArgs e)
        {
            if (txtDatosCargados.Visible)
                txtDatosCargados.Visible = false;
        }            
    }
}
