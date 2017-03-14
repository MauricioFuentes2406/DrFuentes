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
using ClinicaPro.DB;
using ClinicaPro.Entities;
using ClinicaPro.General.Constantes;

namespace Frm.IngresoGastos
{
    public partial class frmVentanaInicial : Form
    {
        //~~~~~            Atributos GLobales
        public int idTipoUsuario { get; set; }

        private int _IngresoMensual = 0;
        private int _GastoMensual = 0;
        private int _ConsultasMensual;
        /// <summary>
        /// Value = 0
        /// </summary>
        private const int  FuenteIngreso_Todos = 0;              
        public frmVentanaInicial(int idtipousuario)
        {
            this.idTipoUsuario = idtipousuario;    // OJO ACA HAY Q ARREGLARLO DESPUES Q CAMBIE A PARAMETRO
            InitializeComponent();
        }
        private void frmVentanaInicial_Load(object sender, EventArgs e)
        {
           this._ConsultasMensual = new ClinicaPro.DB.Consulta.ConsultaDB().SumarConsultaMesActual();
           FechaHoyLabel();
            CargarFuenteIngreso();
            Calculos();
            ultimos10Movimientos();
        }
#region Metodos
        private void Calculos()
        {
            getIngresos();
            getGastos();
            getSaldo();
        }
        private void CargarFuenteIngreso ()
        {
            var list = new ClinicaPro.DB.GastosIngresos.FuenteIngresoDB().ListarPorTipoUsuario(this.idTipoUsuario);
            addComboBoxFuenteIngreso_TODOS(list);
            this.cbFuenteIngreso.DisplayMember = "Nombre";
            this.cbFuenteIngreso.ValueMember = comboNombreIDs.FuenteIngreso; 
            this.cbFuenteIngreso.DataSource = list;
            this.cbFuenteIngreso.SelectedValue = 0;
        }
        private void FechaHoyLabel()
        
        {
            this.labelFecha.Text = DateTime.Now.ToLongDateString();                    
        }
        private void addComboBoxFuenteIngreso_TODOS(List<FuenteIngreso> list)
        {
            FuenteIngreso fuente = new FuenteIngreso();
            fuente.IdFuenteIngreso = 0;         
            fuente.Nombre = "Todos";
            list.Add(fuente);           
        }           
        private void getGastos()
        {
            if (isFuenteIngresoTodos() )
            this._GastoMensual = new ClinicaPro.DB.GastosIngresos.GastosDB().SumarGastoMesActual(this.idTipoUsuario);
            else
            {
                _GastoMensual = new ClinicaPro.DB.GastosIngresos.GastosDB().SumarGastoMesActual(this.idTipoUsuario, cbFuenteIngresoSelectedItem() ); 
            }
            this.txtGastos.Text = _GastoMensual.ToString();
        }
        private void getIngresos()
        {
            if (isFuenteIngresoTodos() )
            _IngresoMensual = new ClinicaPro.DB.GastosIngresos.IngresoDB().SumarIngresoMesActual(this.idTipoUsuario); 
            else
             { 
                this._IngresoMensual = new ClinicaPro.DB.GastosIngresos.IngresoDB().SumarIngresoMesActual(this.idTipoUsuario , cbFuenteIngresoSelectedItem() );
            }
            this.txtIngresos.Text = _IngresoMensual.ToString();
        }
        private void getSaldo()
        {
            int saldo = ClinicaPro.BL.Calculos.Saldo(this._IngresoMensual, this._GastoMensual);
            ColorSaldo(saldo);
            txtSaldo.Text = saldo.ToString();
        }
        private void ColorSaldo(int saldo)
        {
            if (saldo > 0)
            {
                this.txtSaldo.ForeColor = Color.ForestGreen;
            }
            else if (saldo < 0)
                this.txtSaldo.ForeColor = Color.Maroon;                
        }
        private void SumarIngresoConsulta()
        {
            this._IngresoMensual += new ClinicaPro.DB.Consulta.ConsultaDB().SumarConsultaMesActual();
            this.txtIngresos.Text = _IngresoMensual.ToString(); 
            getSaldo();
        }       
        private FuenteIngreso cbFuenteIngresoSelectedItem ()
        {
            return this.cbFuenteIngreso.SelectedItem as FuenteIngreso;
        }
        private bool isFuenteIngresoTodos()
        {
            if ((int)cbFuenteIngreso.SelectedValue == FuenteIngreso_Todos)
                return true;
            else return false;            
        }
        private List<FuenteIngreso> enviarFuenteIngreso()
        {
            var list = this.cbFuenteIngreso.DataSource as List<FuenteIngreso>;
            var aux = list.Find(x => x.IdFuenteIngreso == FuenteIngreso_Todos);
            list.Remove(aux);
            return list;
        }
        /// <summary>
        /// Despues de Abrir Ventana de Agregar Gasto
        /// </summary>
        private void ActulizarGasto()
        {
            CargarFuenteIngreso();
            getGastos();
            getSaldo();
        }
        /// <summary>
        /// Despues de Abrir Ventana de Agregar Ingreso
        /// </summary>
        private void ActulizarIngreso()
        {
            CargarFuenteIngreso();
            getIngresos();
            getSaldo();
        }
        private int fuenteid()
        {
            try
            {
                return (int)this.cbFuenteIngreso.SelectedValue;
            }
            catch (Exception)
            {                
                return 0;
            }
         
        }
        
        private void AlternarColoresEnGrid()
        {           
            this.dgUltimos10.Columns[0].DefaultCellStyle.ForeColor = Color.ForestGreen;
            foreach (DataGridViewRow fila in dgUltimos10.Rows)
            {
                string valor = (string)fila.Cells["Cantidad"].Value; 
              if( valor != null)
              {
                  if (valor.Contains("+") )                  
                      fila.Cells["Cantidad"].Style.ForeColor = Color.ForestGreen;
                  else
                      fila.Cells["Cantidad"].Style.ForeColor = Color.Maroon;
              }
            }
        }
        private void OcultaColumnsIdGrid()
        {
            this.dgUltimos10.Columns[0].Visible = false;
            this.dgUltimos10.Columns[1].Visible = false;
        }
        private void ultimos10Movimientos()
        {
            llenarGrid();
            OcultaColumnsIdGrid();
            AlternarColoresEnGrid();
        }
        private void llenarGrid()
        {
            this.dgUltimos10.DataSource = new ClinicaPro.DB.GastosIngresos.IngresoDB().ListarUltimos10(this.idTipoUsuario);
        }
        #endregion
#region Eventos
        private void chkConsultasDelmes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConsultasDelmes.Checked)
            {
                this.SumarIngresoConsulta();
            }
            else Calculos();
        }
        private void btnGastos_Click(object sender, EventArgs e)
        {            
            new frmAgregarGastos(enviarFuenteIngreso(), this.idTipoUsuario,fuenteid()).ShowDialog(this);                        
            ActulizarGasto();
            ultimos10Movimientos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            new frmAgregarIngreso(enviarFuenteIngreso(), this.idTipoUsuario, fuenteid()).ShowDialog(this);           
            ActulizarIngreso();
            ultimos10Movimientos();
        }
        private void cbFuenteIngreso_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Calculos();
        }     
        #endregion       

        private void btnListaMovimientos_Click(object sender, EventArgs e)
        {
            new frmListaMovimientos(this.idTipoUsuario).ShowDialog(this);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            new frmFuenteIngreso(this.idTipoUsuario).ShowDialog(this);
        }

        private void btnCategoriaIngreso_Click(object sender, EventArgs e)
        {
            new frmCategoriaIngreso(this.idTipoUsuario).ShowDialog(this);
        }

        private void btnCategoriasGasto_Click(object sender, EventArgs e)
        {
            new frmCategoriaGasto(this.idTipoUsuario).ShowDialog(this);
        }        
    }
}
