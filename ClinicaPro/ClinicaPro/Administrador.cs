using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaPro
{
    public partial class Administrador : Form
    {
        private int _IdTipoUsuario;
        public Administrador(int idTipoUsuario)
        {
            InitializeComponent();
            this._IdTipoUsuario = idTipoUsuario;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Usuarios.MantenimientoUsuarios(this._IdTipoUsuario).Show();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearBackUp_Click(object sender, EventArgs e)
        {
             bool isHecho  = new ClinicaPro.DB.RespaldoBD().CrearRespaldo();
             if(isHecho)
                 MessageBox.Show("Respaldo","Respaldo Actualizado",MessageBoxButtons.OK,MessageBoxIcon.Information);
             else
                 MessageBox.Show("Respaldo", "Respaldo No se puedo Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCargarRespaldo_Click(object sender, EventArgs e)
        {
            bool isHecho = new ClinicaPro.DB.RespaldoBD().CargarRespaldoUltimo();
            if (isHecho)
                MessageBox.Show("Respaldo", "Respaldo Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Respaldo", "Respaldo No se puedo Cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
