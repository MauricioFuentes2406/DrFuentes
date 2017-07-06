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
        private int _NumeroIntentos;  // Número de intentos para iniciar sesion      
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
                if (_NumeroIntentos < 3)
                {
                    _NumeroIntentos++;
                }else
                {
                //   Suspender();           Por pedido de cfch no se suspendera
                    //   MensajeSuspended();   Por pedido de cfch no se suspendera
                    this.Close();
                }
                return;
            }
            new AuxiliarLogin(TipoUsuario).Show();
            // new AuxiliarLogin(1).Show();
            this.Hide();
        }
        /// <summary>
        ///  Si ha fallado mas de 3 veces mara iniciar sesion muestra mensaje de suspendido
        /// </summary>
        private void MensajeSuspended()
        {
            MessageBox.Show(Mensajes.Suspended,"Olvidaste la Contraseña?",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }
        /// <summary>
        /// Revisa el estado actual, de pasar los minutos de suspensión se habilitara 
        /// </summary>
        /// <returns></returns>
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
                   MessageBox.Show(this,Result,"Inicio Sesion",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
        /// <summary>
        /// El activa el UseSystemPasswordChar , y además quita el multline(No funcionan juntos)
        /// </summary>
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
