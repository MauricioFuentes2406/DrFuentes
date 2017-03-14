using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaPro.Laboratorio
{
    public partial class LaboratorioGeneral : Form
    {
        private int _idTipoUsuario;
        public LaboratorioGeneral( int IdTipoUsuario)
        {
            InitializeComponent();
            this._idTipoUsuario = IdTipoUsuario;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Laboratorio.MantenimientoExa().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Laboratorio.frmTipoExamen().Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Clientes.MantenimientoCliente(_idTipoUsuario).Show(this);
        }

        private void Laboratorio_Load(object sender, EventArgs e)
        {

        }
        private void button10_Click(object sender, EventArgs e)
        {            
            new ClinicaPro.IngresoGastos.frmVentanaInicial(_idTipoUsuario).ShowDialog(this);
        }
    }
}
