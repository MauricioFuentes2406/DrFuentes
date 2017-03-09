using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm
{
    public partial class AuxiliarLogin : Form
    {
        private int _tipoUsuario;

        private Secretaria _frmSecretaria;  
        private Frm.Laboratorio.LaboratorioGeneral _frmLaboratorio;
        private Administrador _frmAdministrador;
        private GeneralPrincipal _frmGeneralPrincipal; 

        public AuxiliarLogin(int  TipoUsuario)
        {
            InitializeComponent();
            _tipoUsuario = TipoUsuario;
        }

        private void btnSecretaria_Click(object sender, EventArgs e)
        {
            using (this._frmSecretaria = new Secretaria(_tipoUsuario))
            {
                this.Hide();
                _frmSecretaria.ShowDialog();
            }
            this.Visible = true;           
        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            _frmLaboratorio = new Frm.Laboratorio.LaboratorioGeneral(_tipoUsuario);
            this.Hide();
            _frmLaboratorio.ShowDialog();
            _frmLaboratorio.Dispose();
            this.Visible = true;
            
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            using (_frmAdministrador = new Administrador(_tipoUsuario))
            {
                this.Hide();
                _frmAdministrador.ShowDialog();
                this.Visible = true; 
            }                         
        }
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            _frmGeneralPrincipal = new GeneralPrincipal(_tipoUsuario);
            _frmGeneralPrincipal.Show();
            this.Hide();
            
        }
        private void AuxiliarLogin_Load(object sender, EventArgs e)
        {
            this.btnAdministrador.Focus();
        }
     /// <summary>
     ///  Se asegura que el programa deje de ejecutarse cuando se cierra la ventana sin entrar a ningun modulo
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        private void AuxiliarLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_frmGeneralPrincipal == null && _frmAdministrador == null && _frmLaboratorio == null && _frmSecretaria == null)
                Application.Exit();
        }
    }
}
