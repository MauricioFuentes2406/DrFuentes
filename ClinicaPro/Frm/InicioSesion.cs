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
        private void btnIniciar_Click(object sender, EventArgs e)
        {
             int TipoUsuario  =  new UsuarioDB().Autentificar(this.txtUsername.Text, this.txtPassword.Text);
             if (TipoUsuario <= 0) { MessageBox.Show("Nombre usuario y Contraseña Incorrecta","Inicio",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
               
            new AuxiliarLogin(TipoUsuario).Show();
            this.Hide();                               
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
    }
}
