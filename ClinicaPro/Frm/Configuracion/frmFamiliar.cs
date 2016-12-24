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
using ClinicaPro.DB.Consulta;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;

namespace Frm.Configuracion
{
    public partial class frmFamiliar : Form
    {
        public int IdUsuario { get; set; }
        public byte IdFamiliar { get; set; }

        public frmFamiliar()
        {
            InitializeComponent();
            this.IdFamiliar = 0;
        }

        private void frmFamiliar_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void cargarGrid()
        {
            
            FamiliarDB familiarDB = new FamiliarDB();
            this.dgFamiliar.DataSource = familiarDB.Listar();
            dgFamiliar.Columns[comboNombreIDs.familiar].Visible = false;
        }
        private void Limpiar()
        {
            this.IdFamiliar = 0;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
        }
        private Familiar Familiar_ControlesAClase()
        {
            
            Familiar familiar = new Familiar();
            familiar.Nombre = txtNombre.Text.Trim();
            return familiar;
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
                                      " Familiares ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
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
                Familiar familiar = Familiar_ControlesAClase();
                FamiliarDB familiarDB = new FamiliarDB();
                if (familiarDB.Agregar_Modificar(familiar, ClinicaPro.General.accion.Agregar) != 0)
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
                if (dgFamiliar.SelectedRows.Count == 1)
                {
                    this.IdFamiliar = (byte)dgFamiliar.CurrentRow.Cells[comboNombreIDs.familiar].Value;
                }
                Familiar familiar = Familiar_ControlesAClase();
                familiar.IdFamiliar = this.IdFamiliar;
                FamiliarDB familiarDB = new FamiliarDB();                
                if (familiarDB.Agregar_Modificar(familiar, ClinicaPro.General.accion.Modificar) != -1)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgFamiliar.SelectedRows.Count == 1)
            {
                this.IdFamiliar = (byte)dgFamiliar.CurrentRow.Cells[comboNombreIDs.familiar].Value;
            }
            FamiliarDB familiarDB = new FamiliarDB();
            if (familiarDB.Eliminar(this.IdFamiliar, this.IdUsuario))
            {
                Limpiar();
                MensajeDeActulizacion();
            }            
        }
        #endregion
      
    }
}
