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
using ClinicaPro.BL;

namespace ClinicaPro.Usuarios
{
    public partial class AgregarUsuario : Form
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }
        /// <summary>
        /// Constructor para agregar
        /// </summary>
        public AgregarUsuario(int IdTipoUsuario)
        {
            InitializeComponent();
            this.idUsuario  = - 1;
            this.idTipoUsuario = IdTipoUsuario;           
        }
        /// <summary>
        /// Constructor para Modificar
        /// </summary>
        public AgregarUsuario(int  IdUsuario,int IdTipoUsuario)
        {
            InitializeComponent();
            this.idUsuario = IdUsuario;
            this.idTipoUsuario = IdTipoUsuario;
        }
        private void AgregarUsuario_Load(object sender, EventArgs e)
        {
            cargarTipoUsuario();
            this.cbEstado.SelectedIndex = 0;
            if(this.idUsuario > 0)
            {
                Usuario_Clase_A_Controles();
            }
        }
        #region Metodos
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
            if (txtUsername.Text == String.Empty)
            {
                detalles += "Campo Username" + Mensajes.Campo_Requerido;
                this.txtUsername.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtPassword.Text == String.Empty)
            {
                detalles += "Campo Contraseña" + Mensajes.Campo_Requerido;
                this.txtPassword.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtRepetirContrasena.Text == String.Empty)
            {
                detalles += "Campo Repetir Contraseña" + Mensajes.Campo_Requerido;
                this.txtRepetirContrasena.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtFraseRecordatorio.Text == String.Empty)
            {
                detalles += "Campo FraseRecordatorio " + Mensajes.Campo_Requerido;
                this.txtFraseRecordatorio.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if ( txtApellido1.Text == String.Empty)
            {
                detalles += "Campo Primer Apellido " + Mensajes.Campo_Requerido;
                this.txtApellido1.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }           
            if (!txtCelular.MaskFull)
            {
                detalles += "Campo Celular " + Mensajes.Campo_Requerido;
                this.txtCelular.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (!String.Equals(txtPassword.Text,txtRepetirContrasena.Text))
            {
                detalles +=  Mensajes.ContrasenaNoCoincide;
                this.txtNombre.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if(String.Equals(txtFraseRecordatorio.Text, txtPassword.Text))
            {
                detalles +=  Mensajes.FraseIgualPassword;
                this.txtFraseRecordatorio.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }
        private void Limpiar_Datos()  // Resetea todos los campos a sus valores por defecto
        {
            this.idUsuario = -1;
            this.idTipoUsuario = -1;
            this.txtNombre.ResetText();
            this.txtApellido1.ResetText();
            this.txtApellido2.ResetText();
            this.txtCelular.ResetText();
            this.txtPassword.ResetText();
            this.txtEmail.ResetText();
            this.txtFraseRecordatorio.ResetText();
            this.txtRepetirContrasena.ResetText();
            this.txtUsername.ResetText();
            this.cbEstado.SelectedIndex = 0;
            this.cbTipoUsuario.SelectedIndex = 0;
            this.txtUsername.Focus();
        }
        private Usuario Usuario_Controles_A_Clase()
        {
            Usuario user = new Usuario();
            user.Apellido1 = txtApellido1.Text.Trim();
            user.Apellido2 = txtApellido2.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.Estado = Estado();
            user.FraseRecordar = txtFraseRecordatorio.Text.Trim();            
            user.Nombre = txtNombre.Text.Trim();
            user.Password = txtPassword.Text.Trim();
            
            int cel;
            int.TryParse (txtCelular.Text, out cel);
            user.Telefono = cel;
            user.TipoUsuario = (TipoUsuario)this.cbTipoUsuario.SelectedItem;
            user.Username = txtUsername.Text.Trim();
            if (idUsuario != -1)
            { user.IdUsuario = this.idUsuario; }

            return user;
        }
        private void Usuario_Clase_A_Controles()
        {
            var user = new UsuarioDB().getUsuario(this.idUsuario);
            if (user != null)
            {
                this.txtNombre.Text = user.Nombre;
                this.txtApellido1.Text = user.Apellido1;
                this.txtApellido2.Text = user.Apellido2;
                this.txtCelular.Text = user.Telefono.ToString();
                this.txtEmail.Text = user.Email;
                this.txtFraseRecordatorio.Text = user.FraseRecordar;
                this.txtUsername.Text = user.Username;
                if (user.Estado)
                    this.cbEstado.SelectedIndex = 0;
                else
                    cbTipoUsuario.SelectedIndex = 1;
                this.cbTipoUsuario.SelectedValue = user.TipoUsuario.IdTipoUsuario;    
            }else
                MessageBox.Show("No se encontro Usuario en la Base Datos ",Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool Estado()
        {
            if (cbEstado.SelectedIndex == 0)
                return true;
            else
                return false;
        }
        private void cargarTipoUsuario()
        {
            var lista = new ClinicaPro.DB.Usuario.TipoUsuarioDB().Listar();            
            new ClinicaPro.BL.ComboBoxBL<TipoUsuario>().fuenteBaseDatos(cbTipoUsuario,lista , ClinicaPro.General.Constantes.comboNombreIDs.TipoUsuario);

        }            
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Validar() == false)
            {
                int result = -1;
                if (this.idUsuario == -1)
                {
                     result = new UsuarioDB().Agregar_Modificar(Usuario_Controles_A_Clase(), ClinicaPro.General.accion.Agregar);

                }
                else
                {
                    result = new UsuarioDB().Agregar_Modificar(Usuario_Controles_A_Clase(), ClinicaPro.General.accion.Modificar);
                }
                if (result > 0)
                {
                    MessageBox.Show(Mensajes.Agregar_Modificar,
                            "Agregar_Modificar Usuario",
                              MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information);
                    Limpiar_Datos();
                }
            }
        }
        #endregion            
        #region KeyDown
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtRepetirContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtFraseRecordatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void cbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((ComboBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cbTipoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((ComboBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtApellido1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtApellido2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((MaskedTextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        #endregion
    }
}
