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
    public partial class frmCategoriaIngreso : Form
    {
        //Atributos
        public int IdTipoUsuario { get; set; }
        public byte IdCategoriaIngreso { get; set; }
        /// <summary>
        /// = -1
        /// </summary>
        const int IdVacia = 0;
        public frmCategoriaIngreso()
        {
            InitializeComponent();
        }
        public frmCategoriaIngreso(int idTipousuario)
        {
            InitializeComponent();
            this.IdTipoUsuario = idTipousuario;
            this.IdCategoriaIngreso = IdVacia;
        }
        private void frmCategoriaIngreso_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
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
        private void cargarGrid()
        {
            CategoriaIngresoDB fuenteDb = new CategoriaIngresoDB();
            this.dgFuente.DataSource = fuenteDb.Listar();
            dgFuente.Columns[comboNombreIDs.CategoriaIngreso].Visible = false;            
        }
        private void Limpiar()
        {
            this.IdCategoriaIngreso = IdVacia;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
        }
        private CategoriaIngreso CategoriaIngreso_ControlAClase()
        {
            CategoriaIngreso ingreso = new CategoriaIngreso();
            ingreso.Nombre = txtNombre.Text.Trim();            
            return ingreso;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                CategoriaIngreso fuente = CategoriaIngreso_ControlAClase();
                CategoriaIngresoDB fuenteIngresoDB = new CategoriaIngresoDB();
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
                    this.IdCategoriaIngreso = (byte)dgFuente.CurrentRow.Cells[comboNombreIDs.CategoriaIngreso].Value;
                }
                CategoriaIngreso fuente = CategoriaIngreso_ControlAClase();
                fuente.IdCategoriaIngreso = this.IdCategoriaIngreso;
                CategoriaIngresoDB fuenteIngresoDB = new CategoriaIngresoDB();
                if (fuenteIngresoDB.Agregar_Modificar(fuente, ClinicaPro.General.accion.Modificar) != IdVacia)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
                else
                {
                    MessageBox.Show(Mensajes.No_Se_Actualizo + "\n" + Mensajes.Refresh, Mensajes.AlgoPaso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgFuente.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    this.IdCategoriaIngreso = (byte)dgFuente.CurrentRow.Cells[comboNombreIDs.CategoriaIngreso].Value;
                    CategoriaIngresoDB fuenteIngresoDB = new CategoriaIngresoDB();
                    if (fuenteIngresoDB.Eliminar(this.IdCategoriaIngreso, this.IdTipoUsuario))
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
