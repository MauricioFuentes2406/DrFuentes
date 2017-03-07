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
using ClinicaPro.DB.Usuario;
using ClinicaPro.General.Constantes;
namespace Frm
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }         
        private void IniciarSesion()
        {
            int TipoUsuario = new UsuarioDB().Autentificar(this.txtUsername.Text, this.txtPassword.Text);
            if (TipoUsuario <= 0)
            {
                txtUsername.ResetText();
                txtPassword.ResetText();
                MessageBox.Show("Nombre usuario y Contraseña Incorrecta", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;               
            }
            new AuxiliarLogin(TipoUsuario).Show();
            // new AuxiliarLogin(1).Show();
            this.Hide();                               
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }
        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnFraseRecordar_Click(object sender, EventArgs e)
        {
           if(!String.IsNullOrWhiteSpace(txtUsername.Text) && txtUsername.Text != "Username" )
           {
               String Result = new UsuarioDB().FraseRecordatorio(txtUsername.Text);
               if(String.IsNullOrWhiteSpace(Result) )
                   MessageBox.Show("No se encontro Frase asociada a ese Usuario\n Digito bien?");
               else
                   MessageBox.Show(Result);
           }else
               MessageBox.Show("Digite Su nombre de Usuario");
        }        
        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPasswordStyle();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPasswordStyle();
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPasswordStyle();
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPasswordStyle();
        }
        private void txtPasswordStyle()
        {
            if (this.txtPassword.Text == "Password")
            {
                this.txtPassword.ResetText();
                this.txtPassword.Multiline = false;
                this.txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                IniciarSesion();
            }
        }
        /// <summary>
        ///  Cuando se toca enter, se dirige al sigt control (usa el TabOrder en referencia al orden)
        /// </summary>                
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }        
        

      
    }
}
