using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Librerias Añadidas
using ClinicaPro.DB.GastosIngresos;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;
namespace Frm.IngresoGastos
{
    public partial class frmFuenteIngreso : Form
    {
        //Atributos
        public int IdTipoUsuario { get; set; }
        public int IdFuenteIngreso { get; set; }
        /// <summary>
        /// = -1
        /// </summary>
        const int IdVacia = -1;
        private frmFuenteIngreso()
        {
            InitializeComponent();
        }
        public frmFuenteIngreso(int idTipousuario)
        {
            InitializeComponent();
            this.IdTipoUsuario = idTipousuario;
            this.IdFuenteIngreso = IdVacia;
        }
        private void frmCategoriaIngreso_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        ///<summary>
        ///  Valida los campos que no esten vacios ni incosistentes , los pone Color.AliceBlue
        ///  <value>String Detalles, usado para crear una cadena al final con detalles  </value>
        ///  <value>boolean hallazgo, usado como bandera, si encontro algo = true </value>
        ///  <return>hallazgo</return>
        /// </summary>   
        private Boolean Validar()
        {
            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (txtNombre.Text == String.Empty)
            {
                detalles += "Campo Nombre" + Mensajes.Campo_Requerido;
                this.txtNombre.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }
        private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      " Fuente Ingreso ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private FuenteIngreso FuenteIngreso_ControlAClase()
        {
            FuenteIngreso ingreso = new FuenteIngreso();
            ingreso.Nombre = txtNombre.Text.Trim();
            TipoUsuario user = new TipoUsuario();
            user.IdTipoUsuario = this.IdTipoUsuario;
            ingreso.TipoUsuario = user;
            return ingreso;
        }
        private void cargarGrid()
        {
            FuenteIngresoDB fuenteDb = new FuenteIngresoDB();
            this.dgFuente.DataSource = fuenteDb.ListarPorTipoUsuario(this.IdTipoUsuario);
            dgFuente.Columns[comboNombreIDs.FuenteIngreso].Visible = false;
            dgFuente.Columns["TipoUsuario"].Visible = false;
        }
        private void Limpiar()
        {
            this.IdFuenteIngreso = IdVacia;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {                
                    FuenteIngreso fuente = FuenteIngreso_ControlAClase();
                    FuenteIngresoDB fuenteIngresoDB = new FuenteIngresoDB();
                    if (fuenteIngresoDB.Agregar_Modificar(fuente, ClinicaPro.General.accion.Agregar) != IdVacia)
                    {
                        Limpiar();                        
                    }                              
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                if (dgFuente.SelectedRows.Count == 1)
                {
                    this.IdFuenteIngreso = (int)dgFuente.CurrentRow.Cells[comboNombreIDs.FuenteIngreso].Value;
                }
                FuenteIngreso fuente = FuenteIngreso_ControlAClase();
                fuente.IdFuenteIngreso = this.IdFuenteIngreso;
                FuenteIngresoDB fuenteIngresoDB = new FuenteIngresoDB();
                if (fuenteIngresoDB.Agregar_Modificar(fuente, ClinicaPro.General.accion.Modificar) != IdVacia)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgFuente.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    this.IdFuenteIngreso = (int)dgFuente.CurrentRow.Cells[comboNombreIDs.FuenteIngreso].Value;
                    FuenteIngresoDB fuenteIngresoDB = new FuenteIngresoDB();
                    if (fuenteIngresoDB.Eliminar(this.IdFuenteIngreso, this.IdTipoUsuario))
                    {
                        Limpiar();
                        MensajeDeActulizacion();
                    }
                }
            }
            else
            {
                MessageBox.Show(Mensajes.Seleccione_Una_Fila, Mensajes.Upss_Falto_Algo,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }       
    }
}
