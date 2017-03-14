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
using ClinicaPro.DB.Inventario;
using ClinicaPro.Entities;
using ClinicaPro.General.Constantes;
using ClinicaPro.General;

namespace ClinicaPro.Inventario
{
    public partial class frmEstado : Form
    {
        /// <summary>
        /// Si guardo con exito, retorna TRUE , actualiza CB 
        /// </summary>
        public bool isSaved { get; set; }
        public frmEstado()
        {
            InitializeComponent();
            isSaved = false;
        }
        private void frmEstado_Load(object sender, EventArgs e)
        {

        }
        private InventarioEstado Estado_Controles_A_Clase()
        {
            InventarioEstado estado = new InventarioEstado();
            estado.Nombre = this.txtNombre.Text.Trim();
            return estado;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!Validar())
            {
                int result;
                result = EstadoDB.Agregar_Modificar(Estado_Controles_A_Clase(), accion.Agregar);
                if (result > 0)
                {
                    ClinicaPro.BL.Mensaje.MensajeGuardadoEnDB("Estado Inventario");
                    txtNombre.ResetText();
                    isSaved = true;
                }
            }
        }
        /// <summary>
        /// Validar los datos de los controles
        /// </summary>
        /// <returns>true si hay algo mal</returns>
        public Boolean Validar()
        {
            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (String.IsNullOrWhiteSpace(txtNombre.Text))
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
    }
}
