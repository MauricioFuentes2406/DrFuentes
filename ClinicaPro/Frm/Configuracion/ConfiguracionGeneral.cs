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
            new Frm.Configuracion.frmDrogas().ShowDialog();            
        }        
        private void btnVacuna_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmVacunas().ShowDialog();
        }

        private void btnRespuestaGenerales_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmRespuestaGenerales().ShowDialog();
        }

        private void btnFamiliar_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmFamiliar().ShowDialog();
        }

        private void btnMaterialesCasa_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmMaterialesCasa().ShowDialog();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            new Frm.Configuracion.frmServicios().ShowDialog();
        }
        private void btnDiccionario_Click(object sender, EventArgs e)
        {
            new frmDiccionario().Show();
        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {
            new Configuracion.frmAlergias().ShowDialog();
        }              
    }
}
