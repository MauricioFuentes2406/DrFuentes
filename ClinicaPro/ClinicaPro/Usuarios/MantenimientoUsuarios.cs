using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias añadidas
using ClinicaPro.DB.Usuario;
using ClinicaPro.General.Constantes;

namespace ClinicaPro.Usuarios
{
    public partial class MantenimientoUsuarios : Form
    {

        private int _tipoUsuario;
        public MantenimientoUsuarios(int idTipoUsuario)
        {
            InitializeComponent();
            _tipoUsuario = idTipoUsuario;
        }
        private void btnAgregarModificar_Click(object sender, EventArgs e)
        {
            if (dgUsuarios.SelectedRows.Count != 1)
            {
                new AgregarUsuario(_tipoUsuario).Show();
            }else
            {
                int idUsuario = (int)this.dgUsuarios.CurrentRow.Cells[0].Value;              
                new AgregarUsuario(idUsuario,_tipoUsuario).Show();
            }
            cargarGrid();
        }
        private void MantenimientoUsuarios_Load(object sender, EventArgs e)
        {                       
                   cargarGrid();
                   if (_tipoUsuario == TipoUsuarios.CristianRoot)
                   {
                       this.btnAgregarModificar.Enabled = true;
                       this.btnDeshabilitar.Enabled = true;
                   }
        }
        private void cargarGrid()
        {
            if (_tipoUsuario == TipoUsuarios.CristianRoot)
            {
                new UsuarioDB().Vista(dgUsuarios);
                dgUsuarios.Columns[0].Visible = false;
            }
        }

        private void brnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (dgUsuarios.SelectedRows.Count == 1)
            {
                new UsuarioDB().Deshabilitar((int)dgUsuarios.CurrentRow.Cells[0].Value);
                MessageBox.Show("UsuarioDeshabilitado");
            }else
            {
                MessageBox.Show(Mensajes.Seleccione_Una_Fila,Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
            {
                if (this.dgUsuarios.SelectedRows.Count == 1)
                {
                    int IdUsuario = (int)this.dgUsuarios.SelectedRows[0].Cells[0].Value;
                     bool result;
                    result =  new UsuarioDB().Eliminar(0, IdUsuario);
                    if (result)
                    {
                        ClinicaPro.BL.Mensaje.MensajeGuardadoEnDB("Usuario");
                    }
                }else
                    MessageBox.Show(Mensajes.Seleccione_Una_Fila,Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
