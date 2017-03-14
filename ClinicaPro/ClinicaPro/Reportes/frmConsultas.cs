using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias Añadias
//using ClinicaPro.DB.Consulta.Vistas;
using ClinicaPro.DB.Reportes;
namespace ClinicaPro.Reportes
{
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            try
            {
                this.chartAnoActual.DataSource = SPReportes.ConsultasAnoActual();
                this.chartAnoActual.Legends[0].Title = "Año: " + DateTime.Today.Year;
                otro();
                HombresyMujeres();
                CobroAnoTodo();
                CobroAnoActual();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void otro()
        {            
                this.chartTodosLosAños.DataSource = SPReportes.ConsultasAnoTotal();
                this.chartTodosLosAños.Legends[0].Title = "Todos los años";
        }

        private  void HombresyMujeres()
        {           
                var list = SPReportes.ConsultaSexo();
                var listHombres = list.Where(EntidadLocal => EntidadLocal.Sexo == "H");
                var listMujeres = list.Where(EntidadLocal => EntidadLocal.Sexo == "M");

                this.chrtSexo.Series[0].Points.DataBind(listHombres, "Mes", "Cantidad", "");
                this.chrtSexo.Series[1].Points.DataBind(listMujeres, "Mes", "Cantidad", "");                    
        }
        private void CobroAnoActual()
        {
            this.chartGananciaAnoActual.DataSource = SPReportes.ConsultaCobroAno();
            this.chartGananciaAnoActual.Legends[0].Title = "Año: " + DateTime.Today.Year;
        }
        private void CobroAnoTodo()
        {
            this.chartGananciaTodo.DataSource = SPReportes.ConsultaCobroTotal();
            this.chartGananciaTodo.Legends[0].Title = "Todos los años";
        }


    }
}
