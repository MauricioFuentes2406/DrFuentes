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
using ClinicaPro.DB.Consulta;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;

namespace Frm.Configuracion
{
    public partial class frmMaterialesCasa : Form
    {
        public int IdUsuario { get; set; }
        public byte IdMaterial { get; set; }
        public frmMaterialesCasa()
        {
            InitializeComponent();
            this.IdMaterial = 0;
        }

        private void frmMaterialesCasa_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        #region Metodos
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
                                      " Materiales Casa ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private void cargarGrid()
        {
            EstadoViviendaMaterialesDB ViviendaMaterialesDB = new EstadoViviendaMaterialesDB();
            this.dgMateriales.DataSource = ViviendaMaterialesDB.Listar();
            dgMateriales.Columns["IdMaterial"].Visible = false;
        }
        private void Limpiar()
        {
            this.IdMaterial = 0;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
        }
        private ConsultaEstadoViviendaMateriale Material_ControlAClase()
        {
            ConsultaEstadoViviendaMateriale material = new ConsultaEstadoViviendaMateriale();
            material.Nombre = txtNombre.Text.Trim();
            return material;
        }
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid(); 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                ConsultaEstadoViviendaMateriale material = Material_ControlAClase();
                EstadoViviendaMaterialesDB MaterialesDB = new EstadoViviendaMaterialesDB();
                if (MaterialesDB.Agregar_Modificar(material, ClinicaPro.General.accion.Agregar) != 0)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
         
            if (!Validar())
            {
                if (this.dgMateriales.SelectedRows.Count == 1)
                {
                    this.IdMaterial = (byte)dgMateriales.CurrentRow.Cells["IdMaterial"].Value;
                }
                ConsultaEstadoViviendaMateriale material = Material_ControlAClase();
                material.IdMaterial = this.IdMaterial;
                EstadoViviendaMaterialesDB MaterialesDB = new EstadoViviendaMaterialesDB();               
                if (MaterialesDB.Agregar_Modificar(material, ClinicaPro.General.accion.Modificar) != 0)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgMateriales.SelectedRows.Count == 1)
            {

                this.IdMaterial = (byte)dgMateriales.CurrentRow.Cells["IdMaterial"].Value;

                EstadoViviendaMaterialesDB MaterialesDB = new EstadoViviendaMaterialesDB();
                if (MaterialesDB.Eliminar(this.IdMaterial, this.IdUsuario))
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }else
                {
                    MessageBox.Show(Mensajes.Seleccione_Una_Fila, Mensajes.Upss_Falto_Algo,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #region Eventos

        #endregion
    }

}
