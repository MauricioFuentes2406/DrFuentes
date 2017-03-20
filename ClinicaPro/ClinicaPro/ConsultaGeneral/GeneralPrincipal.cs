
namespace ClinicaPro.ConsultaGeneral
{
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
    using ClinicaPro.Properties;
    using ClinicaPro.DB.Notificaciones;

    public partial class GeneralPrincipal : Form
    {       
        public int IdTipoUsuario { get; set; }        
        /// <summary>
        /// Almacenas los Id de los seguimientos que se dejaran como isVisto en la BD
        /// </summary>
        private List<int> _IdSeguimientoRemove;
        public GeneralPrincipal(int idTipoUsuario)
        {
            this.IdTipoUsuario = idTipoUsuario;
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            ubicarPanel();
            SeguimientoFormatoLoad();
            cargarNotificaciones();
            this.btnCliente.Focus();
        }
        /// <summary>
        /// Cuenta el numero de seguimientos activos que hay , y cambia el color si hay registros
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
        #region Eventos

        private void btnReportes_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Reportes.frmReporteGeneral(this.IdTipoUsuario).Show(this);
        }
        private void btnMantemientoCliente_Click(object sender, EventArgs e)
        {
            ClinicaPro.Clientes.MantenimientoCliente Cl = new ClinicaPro.Clientes.MantenimientoCliente(this.IdTipoUsuario);
            Cl.Show();
        }
        private void btnCitas_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Citas.frmGeneralCitas(this.IdTipoUsuario).Show(this);
        }
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            MantenimientoConsulta frmMantenimientoConsulta = new MantenimientoConsulta();
            frmMantenimientoConsulta.Show();
        }
        private void btnExpediente_Click(object sender, EventArgs e)
        {
            new Expediente().Show();
        }
        private void btnIngresoEgreso_Click(object sender, EventArgs e)
        {
            new ClinicaPro.IngresoGastos.frmVentanaInicial(this.IdTipoUsuario).Show();
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Inventario.MantenimientoInventario(this.IdTipoUsuario).Show();
        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            using (ClinicaPro.Configuracion.ConfiguracionGeneral ventanaConfiguracionGeneral = new ClinicaPro.Configuracion.ConfiguracionGeneral())
            {
                ventanaConfiguracionGeneral.ShowDialog();
            }
        }
        /// <summary>
        /// En Seguimientos , si usuario  hace click en la  primera columna(check), lo elimina de la lista globlal _IdSeguimiento
        /// </summary>       
        private void dgSeguimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)  // Index  cero = DataGridViewImage 
                {
                    int IdSeguimiento = (int)this.dgSeguimientos.Rows[e.RowIndex].Cells["IdSeguimiento"].Value;
                    if (this.dgSeguimientos.CurrentRow.Cells[0].Tag == null)  
                    {
                        this.dgSeguimientos.CurrentRow.Cells[0].Value = Resources.successGreen24;
                        this.dgSeguimientos.CurrentRow.Cells[0].Tag = true;
                        this._IdSeguimientoRemove.Add(IdSeguimiento);
                    }
                    else
                    {
                        this.dgSeguimientos.CurrentRow.Cells[0].Value = Resources.success;
                        this.dgSeguimientos.CurrentRow.Cells[0].Tag = null; 
                        this._IdSeguimientoRemove.Remove(IdSeguimiento);
                    }
                }
            }
            catch (Exception )
            {
                return;
            }
        }
        private void GeneralPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Oculta el panel de Seguimiento
        /// </summary>                
        private void btnOcultarPanel_Click(object sender, EventArgs e)
        {
            RemoveSeguimientosDataGrid();
            this.panelSeguimiento.Visible = false;
        }
        private void btnSeguimientos_Click(object sender, EventArgs e)
        {
            if (this.panelSeguimiento.Visible)
            {
                RemoveSeguimientosDataGrid();
                this.panelSeguimiento.Visible = false;
            }
            else
            {
                this.panelSeguimiento.Visible = true;
                cargar_dgSeguimientos();
            }
        }    
        #endregion               
        #region Metodos
        private void cargar_dgSeguimientos()
        {
             BindingList<VistaSeguimiento> list  = new BindingList<VistaSeguimiento>( VSeguimientos.Listar() );
             this.dgSeguimientos.DataSource = list;
            OcultarColumnas();
        }
        private void SeguimientoFormatoClose()
        {
            int countSeguimientos = this.dgSeguimientos.Rows.Count;
            if (countSeguimientos == 0)
            {
                this.btnSeguimientos.BackColor = Color.White;
                this.btnSeguimientos.Text = "No Hay seguimientos hoy";
            }
            else
            {
                if (btnSeguimientos.BackColor != Color.AliceBlue)
                    this.btnSeguimientos.BackColor = Color.AliceBlue;
                this.btnSeguimientos.Text = String.Format("El número de seguimientos hoy:  {0}  ", countSeguimientos);
            }
        }
        /// <summary>
        /// Para el desarrollo , se cambio el lugar del panel de Seguimientos, esta funciona la pone en su lugar
        /// </summary>
        private void ubicarPanel()
        {
            this.panelSeguimiento.Location = new System.Drawing.Point(0, 24);
        }
        private void OcultarColumnas()
        {
            this.dgSeguimientos.Columns["IdSeguimiento"].Visible = false; // idSeguimient0
            this.dgSeguimientos.Columns["isVisto"].Visible = false;  // isVisto          
        }
        /// <summary>
        /// Quita los seguimientos que han sido marcados visto en el GRID, y se actulizan esos registros como Visto , no se borran de la BD 
        /// </summary>
        private void RemoveSeguimientosDataGrid()
        {
            if (_IdSeguimientoRemove == null) return;
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
                }
            }
        }
        #endregion                            
        #region Notificaciones
        /// <summary>
        /// Carga las notificaciones que existan para el día actual
        /// </summary>
     private void cargarNotificaciones ()
    {        
         int numeroCitas = ClinicaPro.DB.Cita.CitasDB.NumeroCitasHoy();
        ClinicaPro.BL.OrdenarNotificacionesBL.cargar(this.dgNotificaciones, NotificaionesDB.ListarHoy(), numeroCitas);        
    }
   private void btnAgregarNotificacion_Click_1(object sender, EventArgs e)
   {
       using (ClinicaPro.Notificacion.frmNotificacion frmNoti = new Notificacion.frmNotificacion())
       {
           frmNoti.ShowDialog();
       }
       this.dgNotificaciones.Columns.Clear();
       cargarNotificaciones();
   }
   private void btnEliminarNotificacion_Click(object sender, EventArgs e)
   {
       if (dgNotificaciones.SelectedRows.Count == 1)
       {
           int IdNotificacion = (int)dgNotificaciones.CurrentRow.Cells["Id"].Value;
           if (IdNotificacion == 0)
           {
               this.dgNotificaciones.Rows.Remove(dgNotificaciones.SelectedRows[0]);
               return;
           }
           bool result;                      
           result = ClinicaPro.DB.Notificaciones.NotificaionesDB.Eliminar(IdNotificacion);
           if (result)
           {
               cargarNotificaciones();
               MessageBox.Show("Se ha eliminado de la Base Datos");
           }
           else
               MessageBox.Show("Hubo un error");
       }
       else MessageBox.Show("Selecciona una sola Fila ");
   }
    #endregion     
    }
}
