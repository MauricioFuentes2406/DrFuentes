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
using ClinicaPro.General.Constantes;
using ClinicaPro.DB.Notificaciones;
using ClinicaPro.Entities;

namespace ClinicaPro.Notificacion
{
    public partial class frmNotificacion : Form
    {
        public frmNotificacion()
        {
            InitializeComponent();
        }
        private void frmNotificacion_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Valida los datos ,  returna true si hay un error
        /// </summary>
        /// <returns></returns>
        public Boolean Validar()
        {
            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (txtTitulo.Text == String.Empty)
            {
                detalles += "Campo Título" + Mensajes.Campo_Requerido;
                this.txtTitulo.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtDescripcion.Text == String.Empty)
            {
                detalles += "Campo Descripción" + Mensajes.Campo_Requerido;
                this.txtDescripcion.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }             
            if (hallazgo)
            {
                MessageBox.Show(detalles, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }   
        private  void Limpiar()
        {
            this.txtTitulo.ResetText();
            this.txtDescripcion.Text = "Sin Descripcion";
            this.dtFecha.Value = DateTime.Today;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                bool result;
                result = NotificaionesDB.Agregar(Notificacion_Control_A_Clase());
                if(result)
                {
                    MessageBox.Show(Mensajes.Agregar_Modificar,"Notifacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            }
        }
        private Notificaciones Notificacion_Control_A_Clase()
        {
            Notificaciones noti = new Notificaciones();
            noti.Titulo = txtTitulo.Text.Trim();
            noti.Descripcion = txtDescripcion.Text.Trim();
            noti.Fecha = dtFecha.Value;
            return noti;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
