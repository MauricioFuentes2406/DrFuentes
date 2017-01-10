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
using ClinicaPro.DB.Consulta;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;

namespace Frm.Configuracion
{
    public partial class frmDrogas : Form
    {
        //Atributos
        public int IdUsuario { get; set; }
        public int IdDrogas { get; set; }
        /// <summary>
        /// = -1
        /// </summary>
        const int IdVacia = -1;
        public frmDrogas()
        {
            InitializeComponent();
            IdDrogas = IdVacia;
        }

        private void frmDrogas_Load(object sender, EventArgs e)
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
                                      " Drogas ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private Drogas Droga_ControlAClase()
        {
            Drogas droga = new Drogas();
            droga.Nombre = txtNombre.Text.Trim();
            return droga;
        }
        private void cargarGrid()
        {
            DrogaDB drogaDB = new DrogaDB();
            this.dgDrogas.DataSource = drogaDB.Listar();
            dgDrogas.Columns[comboNombreIDs.drogas].Visible = false;
        }
        private void Limpiar()
        {
            this.IdDrogas = IdVacia;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();
        }
        #endregion
        #region Eventos
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                try
                {
                    Drogas droga = Droga_ControlAClase();
                    DrogaDB drogaDB = new DrogaDB();
                    if (drogaDB.Agregar_Modificar(droga, ClinicaPro.General.accion.Agregar) != IdVacia)
                    {
                        Limpiar();
                        MensajeDeActulizacion();
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                try
                {
                    if (dgDrogas.SelectedRows.Count == 1)
                    {
                        this.IdDrogas = (int)dgDrogas.CurrentRow.Cells[comboNombreIDs.drogas].Value;
                    }
                    Drogas droga = Droga_ControlAClase();
                    droga.idDrogas = this.IdDrogas;
                    DrogaDB drogaDB = new DrogaDB();
                    if (drogaDB.Agregar_Modificar(droga, ClinicaPro.General.accion.Modificar) != IdVacia)
                    {
                        Limpiar();
                        MensajeDeActulizacion();
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            if (dgDrogas.SelectedRows.Count == 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {                                  
                        this.IdDrogas = (int)dgDrogas.CurrentRow.Cells[comboNombreIDs.drogas].Value;
                        DrogaDB drogaDB = new DrogaDB();
                        if (drogaDB.Eliminar(this.IdDrogas, this.IdUsuario))
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
        #endregion
    }
}
