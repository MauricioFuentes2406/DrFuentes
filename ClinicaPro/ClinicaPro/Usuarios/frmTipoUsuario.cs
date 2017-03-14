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
using ClinicaPro.DB.Usuario;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;

namespace ClinicaPro.Usuarios
{
    public partial class frmTipoUsuario : Form
    {
        //Atributos
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        /// <summary>
        /// = -1
        /// </summary>
        const int IdVacia = -1;
        public frmTipoUsuario()
        {
            InitializeComponent();
            this.IdTipoUsuario = IdVacia;
        }

        private void frmTipoUsuario_Load(object sender, EventArgs e)
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
                                      " TipoUsuario ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private TipoUsuario Droga_ControlAClase()
        {
            
            TipoUsuario tipo = new TipoUsuario();
            tipo.Nombre = txtNombre.Text.Trim();
            return tipo;
        }
        private void cargarGrid()
        {
            
            TipoUsuarioDB drogaDB = new TipoUsuarioDB();
            this.dgDrogas.DataSource = drogaDB.Listar();
            dgDrogas.Columns[0].Visible = false;
        }
        private void Limpiar()
        {
            this.IdTipoUsuario = IdVacia;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
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
                TipoUsuario tipo = Droga_ControlAClase();
                TipoUsuarioDB drogaDB = new TipoUsuarioDB();
                if (drogaDB.Agregar_Modificar(tipo, ClinicaPro.General.accion.Agregar) != IdVacia)
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
                if (dgDrogas.SelectedRows.Count == 1)
                {
                    this.IdTipoUsuario = (int)dgDrogas.CurrentRow.Cells[comboNombreIDs.drogas].Value;
                }
                TipoUsuario tipo = Droga_ControlAClase();
                tipo.IdTipoUsuario = this.IdTipoUsuario;
                TipoUsuarioDB drogaDB = new TipoUsuarioDB();
                if (drogaDB.Agregar_Modificar(tipo, ClinicaPro.General.accion.Modificar) != IdVacia)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgDrogas.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    this.IdTipoUsuario = (int)dgDrogas.CurrentRow.Cells[comboNombreIDs.drogas].Value;
                    TipoUsuarioDB drogaDB = new TipoUsuarioDB();
                    if (drogaDB.Eliminar(this.IdTipoUsuario, this.IdUsuario))
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
    }
}
