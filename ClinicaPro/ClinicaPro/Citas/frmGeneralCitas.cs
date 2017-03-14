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
using ClinicaPro.DB.Cita;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;

namespace ClinicaPro.Citas
{
    public partial class frmGeneralCitas : Form
    {  //Atributos
        private int _IdCita { get; set; }
        private int _IdCliente { get; set; }
        private int _tipoUsuario;
        /// <summary>
        /// = -1
        /// </summary>
        const int IdVacia = -1;

        public frmGeneralCitas(int idTipoUsuario)
        {
            
            InitializeComponent();
            this._tipoUsuario = idTipoUsuario;
        }
        #region Metodos
        private void cargarGrid()
        {
            this._IdCita = -1;
            if (chkHoy.Checked)
            {
                CitasDB.ListarDia(this.dgCitas);
            }else
            {
                CitasDB.Listar(this.dgCitas);
            }
          this.dgCitas.Columns[0].Visible = false;
          this.dgCitas.Columns["IdCliente"].Visible = false;
        }
        private void MensajeDeActulizacion()
        {
              MessageBox.Show(Mensajes.Agregar_Modificar,
                              " Drogas ",
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
            using ( frmAgregarCita addcita = new frmAgregarCita(_tipoUsuario))
            {
                addcita.ShowDialog();
            }
            cargarGrid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgCitas.SelectedRows.Count == 1)
            {
                this._IdCita = (int)dgCitas.SelectedRows[0].Cells["IdCita"].Value;
                using ( frmAgregarCita frm = new frmAgregarCita(_IdCita,_IdCliente,_tipoUsuario))
                {
                    frm.ShowDialog();
                }
                cargarGrid();
            }                 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgCitas.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {                  
                    if (CitasDB.Eliminar(this._IdCita))
                    {                       
                        MensajeDeActulizacion();
                        cargarGrid();
                    }
                }
            }
            else
            {
                seleccioneUnaFila();
            }
        }

        private void frmGeneralCitas_Load(object sender, EventArgs e)
        {
            cargarGrid();
            Seguridad();
        }
        private void dgCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this._IdCita = (int)this.dgCitas.CurrentRow.Cells[0].Value;
            this._IdCliente = (int)this.dgCitas.CurrentRow.Cells[1].Value;

           if ( this.dgCitas.CurrentCell.ColumnIndex == 7 )
           {
               bool sepresento = (bool)this.dgCitas.CurrentCell.Value;
               if (sepresento)
               {
                   CitasDB.SePresento(this._IdCita, false);
               }
               else
               { CitasDB.SePresento(this._IdCita, true); }
               cargarGrid();
           }
        }
        #endregion      
        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (dgCitas.SelectedRows.Count == 1)
            {
                int IdCita = (int)this.dgCitas.SelectedRows[0].Cells[0].Value;
                var correo = CitasDB.getCorreo(IdCita);
                if (correo != null)
                {                   
                       if(ClinicaPro.BL.Correo.Enviar(correo, true))
                            MessageBox.Show(Mensajes.CorreoEnviado, "Éxito ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(Mensajes.NotieneCorreo, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                                    
                    else
                        MessageBox.Show(Mensajes.No_Se_Encontro_Ningun_Registro, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                seleccioneUnaFila();
        }
        private void seleccioneUnaFila ()
        {
            MessageBox.Show(Mensajes.Seleccione_Una_Fila, Mensajes.Upss_Falto_Algo,
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void chkHoy_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkHoy.Checked)
            {
                this.chkHoy.Image = ClinicaPro.Properties.Resources.calendarColor40;
                
            }else
            {
                this.chkHoy.Image= ClinicaPro.Properties.Resources.calendarBlack;
            }
            cargarGrid();
        }
        private  void Seguridad ()
        {
            if(this._tipoUsuario != TipoUsuarios.CristianRoot)
            {
                this.btnEliminar.Enabled = false;                
            }
        }
    }
}
