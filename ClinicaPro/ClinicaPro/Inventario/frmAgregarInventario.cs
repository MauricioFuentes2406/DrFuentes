using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias añadidas
using ClinicaPro.DB.Inventario;
using ClinicaPro.Entities;
using ClinicaPro.General.Constantes;
using ClinicaPro.General;

namespace ClinicaPro.Inventario
{
    public partial class frmAgregarInventario : Form
    {

        private int _IdArticulo;        
        public frmAgregarInventario(int idArticulo)
        {
            InitializeComponent();
            this._IdArticulo = idArticulo;
        }
        private void frmAgregarInventario_Load(object sender, EventArgs e)
        {
            LLenarCombos();
            if(_IdArticulo > 0)
            {
                Inventario_Clase_A_Controles();
            }
        }
    
        private void LLenarCombos()
        {
            llenarComboEstado();
            llenarComboTipo();
        }
        private void llenarComboTipo()
        {
            var list = TipoUnidadDB.Listar();
            new ClinicaPro.BL.ComboBoxBL<InventarioTipoUnidad>().fuenteBaseDatos(cbTipoUnidad, list, comboNombreIDs.TipoUnidad);
        }
        private void llenarComboEstado()
        {
            var list = EstadoDB.Listar();
            new ClinicaPro.BL.ComboBoxBL<InventarioEstado>().fuenteBaseDatos(cbEstado, list, comboNombreIDs.EstadoInventario);
        }
        private InventarioMedicina Inventario_Controles_A_Clase()
        {
            InventarioMedicina inv = new InventarioMedicina();
            inv.CantidadActual = (int)numCantidad.Value;
            inv.CantidadAlerta = (int)numCantidadAlerta.Value;            
            inv.Nombre = this.txtNombre.Text.Trim();
            inv.InventarioEstado = (InventarioEstado)cbEstado.SelectedItem;
            inv.InventarioTipoUnidad = (InventarioTipoUnidad)cbTipoUnidad.SelectedItem;                      
            inv.Precio =(int) this.numPrecio.Value;
            inv.Presentacion = txtPresentacion.Text.Trim();
            inv.IdArticulo = this._IdArticulo;
            return inv;
        }
            private void Inventario_Clase_A_Controles()
        {
            var Entidad = InventarioDB.getArticulo(this._IdArticulo);
                if (Entidad != null)
                {
                    this.numCantidad.Value = Entidad.CantidadActual;
                    this.numCantidadAlerta.Value =Entidad.CantidadAlerta;
                    this.cbEstado.SelectedValue = Entidad.InventarioEstado.IdEstado;
                    this.cbTipoUnidad.SelectedValue = Entidad.InventarioTipoUnidad.IdTipoUnidad;
                    this.txtNombre.Text = Entidad.Nombre;
                    this.numPrecio.Value = Entidad.Precio;
                    this.txtPresentacion.Text = Entidad.Presentacion;                                        
                }
        }
        private void Limpiar()
        {
            this.txtNombre.ResetText();
            cbEstado.SelectedIndex= 0;
            cbTipoUnidad.SelectedIndex =0;
            this.numCantidad.Value =0;
            numPrecio.Value =0;
            this.numCantidadAlerta.Value =0;            
            this._IdArticulo =-1;
        }
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
            if (numPrecio .Value== 0)
            {
                detalles += "Campo Precio" + Mensajes.Numero_Mayor_Cero;
                this.numPrecio.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if(cbTipoUnidad.DataSource == null)
            {
                detalles += "Campo Tipo Unidad" + Mensajes.Campo_Requerido;
                this.cbTipoUnidad.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (cbEstado.DataSource == null)
            {
                detalles += "Campo Estado" + Mensajes.Campo_Requerido;
                this.cbEstado.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }

            if (hallazgo)
            {
                MessageBox.Show(detalles, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }        
        private void btnAddTipoUnidad_Click(object sender, EventArgs e)
        {
            var frmTipo = new ClinicaPro.Inventario.frmTipoUnidad();
            frmTipo.ShowDialog(this);
            if (frmTipo.isSaved)
                llenarComboTipo();            
        }
        private void btnAddEstado_Click(object sender, EventArgs e)
        {
            var frmEstado = new ClinicaPro.Inventario.frmEstado();
            frmEstado.Show(this);
            if (frmEstado.isSaved)
                llenarComboEstado();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                int result;
                if (this._IdArticulo < 1)                
                    result= InventarioDB.Agregar(Inventario_Controles_A_Clase());                   
                   else               
                         result = InventarioDB.Modificar(Inventario_Controles_A_Clase());
                if (result > 0)
                {
                    ClinicaPro.BL.Mensaje.MensajeGuardadoEnDB("Articulo Inventario");
                    Limpiar();
                }
            }
        }
    }
}
