using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Librerias añadidas
using ClinicaPro.DB.Consulta;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;

namespace Frm.Configuracion
{
    public partial class frmRespuestaGenerales : Form
    {
        public int IdUsuario { get; set; }
        public byte IdRespuestaGeneral { get; set; }
        public frmRespuestaGenerales()
        {
            InitializeComponent();
        }
        private void frmRespuestaGenerales_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        #region Metodos
        private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      "Respuesta generales ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private void cargarGrid()
        {
            RespuestaGeneralesDB respuestaDB = new RespuestaGeneralesDB();
            this.dgRespuestasGenerales.DataSource = respuestaDB.Listar();
            dgRespuestasGenerales.Columns[comboNombreIDs.respuestaGenerales].Visible = false;
        }
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
        private Consulta_RespuestasGenerales resGeneral_ControlAClase()
        {            
            Consulta_RespuestasGenerales resGeneral = new Consulta_RespuestasGenerales();
            resGeneral.Nombre = txtNombre.Text.Trim();
            return resGeneral;
        }
        private void Limpiar()
        {
            this.IdRespuestaGeneral = 0;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
        }
        #endregion   

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                Consulta_RespuestasGenerales respuestaGeneral = resGeneral_ControlAClase();
                RespuestaGeneralesDB reespuestaGeneralDB = new RespuestaGeneralesDB();
                if (reespuestaGeneralDB.Agregar_Modificar(respuestaGeneral, ClinicaPro.General.accion.Agregar) != 0)
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
                
                if (dgRespuestasGenerales.SelectedRows.Count == 1)
                {
                    this.IdRespuestaGeneral = (byte)dgRespuestasGenerales.CurrentRow.Cells[comboNombreIDs.respuestaGenerales].Value;
                }
                Consulta_RespuestasGenerales respuestaGeneral = resGeneral_ControlAClase();
                respuestaGeneral.idRespuestaGeneral = this.IdRespuestaGeneral;
                RespuestaGeneralesDB reespuestaGeneralDB = new RespuestaGeneralesDB();
                if ( reespuestaGeneralDB.Agregar_Modificar(respuestaGeneral, ClinicaPro.General.accion.Modificar)!= 0 )
                { 
                Limpiar();
                MensajeDeActulizacion();
                }
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgRespuestasGenerales.SelectedRows.Count == 1)
            {
                this.IdRespuestaGeneral = (byte)dgRespuestasGenerales.CurrentRow.Cells[comboNombreIDs.respuestaGenerales].Value;
            }
            RespuestaGeneralesDB reespuestaGeneralDB = new RespuestaGeneralesDB();
            if (reespuestaGeneralDB.Eliminar(this.IdRespuestaGeneral, this.IdUsuario))
            {
                MensajeDeActulizacion();
                Limpiar();
            }                                      
        }
    }
}
