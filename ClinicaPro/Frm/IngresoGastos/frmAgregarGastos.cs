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
using ClinicaPro.Entities;
using ClinicaPro.DB;
using ClinicaPro.General.Constantes;
using ClinicaPro.BL;

namespace Frm.IngresoGastos
{
    public partial class frmAgregarGastos : Form
    {
//   ~~~~~~~~ Atributos
        private int _SelectedValue;
        private int _TipoUsuario;

         public frmAgregarGastos(List<FuenteIngreso> list , int TipoUsuario ,int  fuenteid )
        {
            InitializeComponent();
            constructorParametro(list , fuenteid);
            this._TipoUsuario = TipoUsuario;
        }
        public frmAgregarGastos( )
        {
            InitializeComponent();
        }
        private void frmAgregarGastos_Load(object sender, EventArgs e)
        {
            cargarCategoriasGastos();
        }        
        #region Metodos
        private void constructorParametro(List<FuenteIngreso> list , int fuenteid)
        {
            new ClinicaPro.BL.ComboBoxBL<FuenteIngreso>().fuenteBaseDatos(this.cbFuenteIngreso, list, comboNombreIDs.FuenteIngreso);
            if (fuenteid > 1 )
            {
                this.cbFuenteIngreso.SelectedValue = fuenteid;
            }
        }
        private void cargarCategoriasGastos()
        {
            var list = new ClinicaPro.DB.GastosIngresos.CategoriaGastoDB().Listar();
            new ComboBoxBL<CategoriasGasto>().fuenteBaseDatos(cbCategoria, list, comboNombreIDs.CategoriaGasto);
        }
        ///<summary>
        ///  Valida los campos que no esten vacios ni incosistentes , los pone Color.AliceBlue
        ///  <value>String Detalles, usado para crear una cadena al final con detalles  </value>
        ///  <value>boolean hallazgo, usado como bandera, si encontro algo = true </value>
        ///  <return>hallazgo</return>
        /// </summary>          
        public Boolean Validar()
        {
            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (this.numCantidad.Value == 0)
            {
                detalles += "Cantidad" + Mensajes.Numero_Mayor_Cero;
                this.numCantidad.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }
        private Gasto Gasto_Controles_A_Clase()
        {
            Gasto gasto = new Gasto();
            gasto.CantidadGasto = (int)numCantidad.Value;
            gasto.CategoriasGasto = (CategoriasGasto)this.cbCategoria.SelectedItem;
            gasto.DescripcionBreve = txtDescripcion.Text.Trim() ;
            gasto.FechaDeGasto = dtFecha.Value;
            gasto.FuenteIngreso = (FuenteIngreso)this.cbFuenteIngreso.SelectedItem;
            gasto.IdTipoUsuario = this._TipoUsuario;          
            
            return gasto;
        }
        private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      " Alergias ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        #endregion
        #region Eventos
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!Validar())
            {
                int result = new ClinicaPro.DB.GastosIngresos.GastosDB().Agregar_Modificar(Gasto_Controles_A_Clase(), ClinicaPro.General.accion.Agregar);
                if (result > 0)
                {
                    MensajeDeActulizacion();
                }
            }
        }
        private void frmAgregarGastos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        private void btnCalcu_Click(object sender, EventArgs e)
        {
            ClinicaPro.BL.SystemProces.AbrirCalculadoraWindows();
        }    
        #endregion

       
    }
}
