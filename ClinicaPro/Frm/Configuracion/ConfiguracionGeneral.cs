using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm
{
    public partial class ConfiguracionGeneral : Form
    {
        public ConfiguracionGeneral()
        {
            InitializeComponent();            
        }        
        private void ConfiguracionGeneral_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = SystemColors.ControlLightLight;
                }


            }
        }
        private void btnDrogas_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmDrogas().Show();            
        }        
        private void btnVacuna_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmVacunas().Show();
        }

        private void btnRespuestaGenerales_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmRespuestaGenerales().Show();
        }

        private void btnFamiliar_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmFamiliar().Show();
        }

        private void btnMaterialesCasa_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmMaterialesCasa().Show();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmServicios().Show();
        }
        private void btnDiccionario_Click(object sender, EventArgs e)
        {
            new frmBusquedas().Show();
        }              
    }
}
