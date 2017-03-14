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

namespace ClinicaPro.IngresoGastos
{
    public partial class frmCategoriaGasto : Form
    {  //Atributos
        public int IdTipoUsuario { get; set; }
        public byte IdCategoriaGasto { get; set; }
        /// <summary>
        /// = 0
        /// </summary>
        const int IdVacia = 0;
        public frmCategoriaGasto()
        {
            InitializeComponent();
        }
        private void frmCategoriaGasto_Load(object sender, EventArgs e)
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
                                      "Categoria Gasto ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private void cargarGrid()
        {
            CategoriaGastoDB fuenteDb = new CategoriaGastoDB();
            this.dgFuente.DataSource = fuenteDb.Listar();
            dgFuente.Columns[comboNombreIDs.CategoriasGasto].Visible = false;
        }
        private void Limpiar()
        {
            this.IdCategoriaGasto = IdVacia;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
        }
        private CategoriasGasto FuenteIngreso_ControlAClase()
        {
            CategoriasGasto cgasto = new CategoriasGasto();
            cgasto.Nombre = txtNombre.Text.Trim();
            return cgasto;
        }
        public frmCategoriaGasto(int idTipousuario)
        {
            InitializeComponent();
            this.IdTipoUsuario = idTipousuario;
            this.IdCategoriaGasto = IdVacia;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                CategoriasGasto categoria = FuenteIngreso_ControlAClase();
                CategoriaGastoDB categoriaGastoDB = new CategoriaGastoDB();
                if (categoriaGastoDB.Agregar_Modificar(categoria, ClinicaPro.General.accion.Agregar) != IdVacia)
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
                    this.IdCategoriaGasto = (byte)dgFuente.CurrentRow.Cells[comboNombreIDs.CategoriasGasto].Value;
                }
                CategoriasGasto categoria = FuenteIngreso_ControlAClase();
                categoria.IdCategoriaGasto = this.IdCategoriaGasto;
                CategoriaGastoDB categoriaGastoDB = new CategoriaGastoDB();
                if (categoriaGastoDB.Agregar_Modificar(categoria, ClinicaPro.General.accion.Modificar) != IdVacia)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }else
                {
                    MessageBox.Show(Mensajes.No_Se_Actualizo+"\n"+Mensajes.Refresh,Mensajes.AlgoPaso,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgFuente.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    this.IdCategoriaGasto = (byte)dgFuente.CurrentRow.Cells[comboNombreIDs.CategoriasGasto].Value;
                    CategoriaGastoDB categoriaGastoDB = new CategoriaGastoDB();
                    if (categoriaGastoDB.Eliminar(this.IdCategoriaGasto, this.IdTipoUsuario))
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
