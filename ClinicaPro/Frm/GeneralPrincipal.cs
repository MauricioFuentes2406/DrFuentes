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
using ClinicaPro.DB.Consulta.Vistas;
using ClinicaPro.Entities;
using Frm.Properties;

namespace Frm
{
    public partial class GeneralPrincipal : Form
    {
        public int idCliente { get; set; }
        public String nombreCompleto { get; set; }
        private List<int> _IdSeguimientoRemove;
        public GeneralPrincipal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ubicarPanel();
            SeguimientoFormatoLoad();
        }
        /// <summary>
        /// Cuenta el numero de registros desde la BaseDatos
        /// </summary>
        private void  SeguimientoFormatoLoad()
        {
            int countSeguimientos = VSeguimientos.Count_HoyYNoVistos();
            if(countSeguimientos > 0)
            {
                _IdSeguimientoRemove = new List<int>();
                this.btnSeguimientos.BackColor = Color.AliceBlue;
                this.btnSeguimientos.Text = String.Format("El número de seguimientos hoy:  {0}  ",countSeguimientos);
            }
        }
        /// <summary>
        /// Cuenta las filas que tiene DgSeguimientos
        /// </summary>
        private void SeguimientoFormatoClose()
        {
            int countSeguimientos = this.dgSeguimientos.Rows.Count;
            if (countSeguimientos == 0)
            {
                this.btnSeguimientos.BackColor = Color.White;
                this.btnSeguimientos.Text = "No Hay seguimientos hoy";
            }else
            {
                if (btnSeguimientos.BackColor != Color.AliceBlue)
                    this.btnSeguimientos.BackColor = Color.AliceBlue;
                this.btnSeguimientos.Text = String.Format("El número de seguimientos hoy:  {0}  ", countSeguimientos);
            }
        }
        private void ubicarPanel()
        {
            this.panelSeguimiento.Location = new System.Drawing.Point(0, 24);
        }
  
        private void button7_Click(object sender, EventArgs e)
        {
            MantenimientoCliente Cl = new MantenimientoCliente();
            Cl.Show();         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MantenimientoConsulta frmMantenimientoConsulta = new MantenimientoConsulta();
            frmMantenimientoConsulta.Show();

          //  AgregarConsulta Co = new AgregarConsulta(idCliente);  // Falta anadir parametro idCLiente
           // Co.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Expediente().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Frm.IngresoGastos.frmVentanaInicial().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new MantenimientoInventario().Show();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
           using(  ConfiguracionGeneral ventanaConfiguracionGeneral = new ConfiguracionGeneral())
           {
               ventanaConfiguracionGeneral.ShowDialog();
           }

        }

        private void dgSeguimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {                   
                    int IdSeguimiento = (int)this.dgSeguimientos.Rows[e.RowIndex].Cells["IdSeguimiento"].Value;
                    if (this.dgSeguimientos.CurrentRow.Cells[0].Tag == null)
                    {                                                    
                        this.dgSeguimientos.CurrentRow.Cells[0].Value= Resources.successGreen24;
                        this.dgSeguimientos.CurrentRow.Cells[0].Tag = true;
                        this._IdSeguimientoRemove.Add(IdSeguimiento);
                    }else
                    {
                        this.dgSeguimientos.CurrentRow.Cells[0].Value = Resources.successGray;
                        this.dgSeguimientos.CurrentRow.Cells[0].Tag = null;
                        this._IdSeguimientoRemove.Remove(IdSeguimiento);
                    }                         
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }                      
        }
        private void GeneralPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btnOcultarPanel_Click(object sender, EventArgs e)
        {
            RemoveSeguimientos();
            this.panelSeguimiento.Visible = false;            
        }

        private void btnSeguimientos_Click(object sender, EventArgs e)
        {
            if (this.panelSeguimiento.Visible)
            {
                RemoveSeguimientos();
                this.panelSeguimiento.Visible = false;               
            }
            else
            {
                this.panelSeguimiento.Visible = true;
                cargar_dgSeguimientos();
            }           
        }
       
        #region Metodos
        private void cargar_dgSeguimientos()
        {
             BindingList<VistaSeguimiento> list  = new BindingList<VistaSeguimiento>( VSeguimientos.Listar() );
             this.dgSeguimientos.DataSource = list;
            OcultarColumnas();
        }
        private void OcultarColumnas()
        {
            this.dgSeguimientos.Columns["IdSeguimiento"].Visible = false; // idSeguimient0
            this.dgSeguimientos.Columns["isVisto"].Visible = false;  // isVisto          
        }
        #endregion                 
        private void RemoveSeguimientos()
        {
            if (_IdSeguimientoRemove.Count > 0)
            {
                try
                {
                    foreach (DataGridViewRow filas in dgSeguimientos.Rows)
                    {
                        if (filas.Cells[0].Tag != null)
                        {
                            dgSeguimientos.Rows.RemoveAt(filas.Index);
                        }
                    }
                    foreach (var item in _IdSeguimientoRemove)
                    {
                        ClinicaPro.DB.Consulta.SeguimientoDB.isVisto_SetTrue(item);                       
                    }
                    SeguimientoFormatoClose();
                }
                catch (Exception)
                {
                    
                    throw;
                }
               
            }
           
        }
    }
}
