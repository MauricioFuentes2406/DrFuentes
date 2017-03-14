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

namespace ClinicaPro
{
    public partial class InicioSesion : Form
    {

        private int _NumeroIntentos;        
        public InicioSesion()
        {
            InitializeComponent();
            _NumeroIntentos = 0;
        }
        #region Metodos
        private void IniciarSesion()
        {            
            int TipoUsuario = new UsuarioDB().Autentificar(this.txtUsername.Text, this.txtPassword.Text);
            if (TipoUsuario <= 0)
            {
                txtPasswordStyle();                
                MessageBox.Show("Nombre usuario y Contraseña Incorrecta", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseWaitCursor = false;
                if (_NumeroIntentos < 3)
                {
                    _NumeroIntentos++;
                }else
                {
                    Suspender();
                    MensajeSuspended();
                    this.Close();
                }
                return;
            }
            new AuxiliarLogin(TipoUsuario).Show();
            // new AuxiliarLogin(1).Show();
            this.Hide();
        }
        private void MensajeSuspended()
        {
            MessageBox.Show(Mensajes.Suspended,"Olvidaste la Contraseña?",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }
        private bool isSuspended()
        {
            bool Suspended  = Properties.Settings.Default.isTemporalSuspended;
            if (Suspended)
            {
                if (DateTime.Now.Minute - Properties.Settings.Default.HoraDeSuspencion.Minute  < 3) // Recordar pasar a 1  minute
                    return Suspended;
                else
                {
                    Properties.Settings.Default.isTemporalSuspended = false;
                    Properties.Settings.Default.Save();
                    return !Suspended;
                }
            }
            else
                return Suspended;
        }
        /// <summary>
        /// Si falla en logearse mas de 3 veces, la aplicacion se cerrara automaticamente por 5 minutos
        /// </summary>
        private void Suspender()
        {
            Properties.Settings.Default.isTemporalSuspended = true;
            Properties.Settings.Default.HoraDeSuspencion = DateTime.Now;
            Properties.Settings.Default.Save();
        }
        #endregion

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }
        private void InicioSesion_Load(object sender, EventArgs e)
        {
            if (isSuspended())
            {                 
                MensajeSuspended();
                this.Close();
            }
           
        }             
        private void btnFraseRecordar_Click(object sender, EventArgs e)
        {            
           if(!String.IsNullOrWhiteSpace(txtUsername.Text) && txtUsername.Text != "Username" )
           {
               String Result = new UsuarioDB().FraseRecordatorio(txtUsername.Text);
               if(String.IsNullOrWhiteSpace(Result) )
                   MessageBox.Show(Mensajes.FraseNoseEncontro,"Frase",MessageBoxButtons.OK,MessageBoxIcon.Question);
               else
                   MessageBox.Show(Result);
           }else
               MessageBox.Show("Digite Un Nombre de Usuario","Frase",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
            if (!txtPassword.UseSystemPasswordChar)
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
                e.SuppressKeyPress = true;
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }                                     
    }
}
