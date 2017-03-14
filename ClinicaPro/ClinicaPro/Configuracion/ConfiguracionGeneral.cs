using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaPro.Configuracion
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
            new ClinicaPro.Configuracion.frmDrogas().ShowDialog(this);            
        }        
        private void btnVacuna_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Configuracion.frmVacunas().ShowDialog(this);
        }

        private void btnRespuestaGenerales_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Configuracion.frmRespuestaGenerales().ShowDialog(this);
        }

        private void btnFamiliar_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Configuracion.frmFamiliar().ShowDialog(this);
        }

        private void btnMaterialesCasa_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Configuracion.frmMaterialesCasa().ShowDialog(this);
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Configuracion.frmServicios().ShowDialog();
        }
        private void btnDiccionario_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Diccionario.frmDiccionario().Show();
        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {
            new Configuracion.frmAlergias().ShowDialog();
        }              
    }
}
