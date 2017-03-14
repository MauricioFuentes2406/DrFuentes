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

namespace ClinicaPro.IngresoGastos
{
    public partial class frmAgregarIngreso : Form
    {
        //   ~~~~~~~~ Atributos
        private int _SelectedValue;
        private int _TipoUsuario;
        private bool isModificar ;
        private int _Idingreso;
        public frmAgregarIngreso(List<FuenteIngreso> list, int TipoUsuario, int fuenteid)
        {
            InitializeComponent();
            constructorParametro(list,fuenteid);
            this._TipoUsuario = TipoUsuario;
        }
        public frmAgregarIngreso(int idIngreso, int TipoUsuario)
        {
            InitializeComponent();
            this._TipoUsuario = TipoUsuario;
            isModificar = true;
            this._Idingreso = idIngreso;     
        }
        public frmAgregarIngreso()
        {
            InitializeComponent();
        }
        private void frmAgregarIngreso_Load(object sender, EventArgs e)
        {
            cargarCategoriasIngreso();
            if (isModificar)
            {
                var oso = new ClinicaPro.DB.GastosIngresos.FuenteIngresoDB().ListarPorTipoUsuario(this._TipoUsuario);
                new ComboBoxBL<FuenteIngreso>().fuenteBaseDatos(cbFuenteIngreso, oso, comboNombreIDs.FuenteIngreso);
                RecuperarBD();
            }
        }
        #region Metodos
        private void RecuperarBD()
        {
            if (this._Idingreso > 0)
            {
                ClinicaPro.Entities.Ingreso Entidad = new ClinicaPro.DB.GastosIngresos.IngresoDB().GetIngreso(this._Idingreso);
                if (Entidad != null)
                {
                    numCantidad.Value = Entidad.CantidadIngreso;                   
                    txtDescripcion.Text = Entidad.DescripcionBreve;
                    dtFecha.Value = Entidad.FechaDeIngreso;
                    try
                    {
                        cbCategoria.SelectedValue = Entidad.CategoriaIngreso.IdCategoriaIngreso;
                        cbFuenteIngreso.SelectedValue = Entidad.FuenteIngreso.IdFuenteIngreso;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString());
                        throw;
                    }

                }
            }
        }
        private void constructorParametro(List<FuenteIngreso> list ,  int fuenteid)
        {
            new ClinicaPro.BL.ComboBoxBL<FuenteIngreso>().fuenteBaseDatos(this.cbFuenteIngreso, list, comboNombreIDs.FuenteIngreso);
            if (fuenteid > 1)
            {
                this.cbFuenteIngreso.SelectedValue = fuenteid;
            }
        }
        private void cargarCategoriasIngreso()
        {
            var list = new ClinicaPro.DB.GastosIngresos.CategoriaIngresoDB().Listar();
            new ComboBoxBL<CategoriaIngreso>().fuenteBaseDatos(cbCategoria, list, comboNombreIDs.CategoriaIngreso);
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
        private Ingreso Ingreso_Controles_A_Clase()
        {
            Ingreso ingreso = new Ingreso();
            ingreso.CantidadIngreso = (int)numCantidad.Value;
            ingreso.CategoriaIngreso = (CategoriaIngreso)this.cbCategoria.SelectedItem;
            ingreso.DescripcionBreve = txtDescripcion.Text.Trim();
            ingreso.FechaDeIngreso = dtFecha.Value;
            ingreso.FuenteIngreso = (FuenteIngreso)this.cbFuenteIngreso.SelectedItem;
            ingreso.IdTipoUsuario = this._TipoUsuario;
            if (this._Idingreso > 0)
            {
                ingreso.IdIngreso = this._Idingreso;
            }
            return ingreso;
        }
        private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      " Ingresos ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        #endregion
        #region Eventos
        private void btnCalcu_Click(object sender, EventArgs e)
        {
            ClinicaPro.BL.SystemProces.AbrirCalculadoraWindows();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                if (_Idingreso < 1)
                {
                    int result = new ClinicaPro.DB.GastosIngresos.IngresoDB().Agregar_Modificar(Ingreso_Controles_A_Clase(), ClinicaPro.General.accion.Agregar);

                    if (result > 0)
                    {
                        MensajeDeActulizacion();
                        this._Idingreso = result;
                    }
                }else
                {
                    int result = new ClinicaPro.DB.GastosIngresos.IngresoDB().Agregar_Modificar(Ingreso_Controles_A_Clase(), ClinicaPro.General.accion.Modificar);
                    if (result > 0)
                    {
                        MensajeDeActulizacion();
                    }
                }
            }
        }
        private void frmAgregarIngreso_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        #region keyDown
        private void numCantidad_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((NumericUpDown)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void cbFuenteIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((ComboBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void cbCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((ComboBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void dtFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((DateTimePicker)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        #endregion                
        #endregion     
       
    }
}
