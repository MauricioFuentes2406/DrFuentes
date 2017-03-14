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
using ClinicaPro.DB.Reportes;
namespace ClinicaPro.Reportes
{
    public partial class frmIngresoEgreso : Form
    {
        public int IdTipoUsuario { get; set; }

        public frmIngresoEgreso(int TipoUsuario)
        {
            this.IdTipoUsuario = TipoUsuario;
            InitializeComponent();
        }

        private void frmIngresoEgreso_Load(object sender, EventArgs e)
        {            
            GastoIngreoAnoActual();
            GastoIngresoTotal();
            GastosCategorias();
        }
        private void GastoIngreoAnoActual()
        {
            var listIngreso = SPReportes.IngresoAnoActual(IdTipoUsuario);
            var listGasto = SPReportes.GastoAnoActual(IdTipoUsuario);

            this.chartCobroAnoActual.Series[0].Points.DataBind(listIngreso, "Mes", "Cantidad", "");
            this.chartCobroAnoActual.Series[1].Points.DataBind(listGasto, "Mes", "Cantidad", "");
            this.chartCobroAnoActual.Legends[0].Title = "Año " + DateTime.Today.Year;
        }
        private void GastoIngresoTotal()
        {
            var listIngreso = SPReportes.IngresoTotal(IdTipoUsuario);
            var listGasto = SPReportes.GastoTotal(IdTipoUsuario);


            this.charIngresoEgresoTotal.Series[0].Points.DataBind(listIngreso, "Mes", "Cantidad", "");
            this.charIngresoEgresoTotal.Series[1].Points.DataBind(listGasto, "Mes", "Cantidad", "");
        }
        private void GastosCategorias()
        {
            var list = SPReportes.GastosCategorias(IdTipoUsuario);
            this.chartCategoriasGasto.Series[0].Points.DataBind(list, "Categoria", "Cantidad", "");
        }
        //GastosCAtegoria
        //for (int index = 0; index < list.Count; index++)
        //{
        //    this.chartCategoriasGasto.Series[0].LegendText
        //}

        //foreach (var item in chartCategoriasGasto.Series[0].Points)
        //{
        //    MessageBox.Show(item.Label.ToString() + " <= Label  , AxisLabe; = " + item.AxisLabel.ToString());
        //}       
    }
}
