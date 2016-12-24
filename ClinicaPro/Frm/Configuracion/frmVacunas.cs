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
using ClinicaPro.DB.Consulta;
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;


namespace Frm.Configuracion
{
    public partial class frmVacunas : Form
    {
        //Atributos
        public int IdUsuario { get; set; }
        public int IdVacunas { get; set; }
        public frmVacunas()
        {
            InitializeComponent();
            this.IdVacunas = -1;
        }

        private void frmVacunas_Load(object sender, EventArgs e)
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
                                      " Vacunas ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private void cargarGrid()
        {
            VacunasDB vacunaDB= new VacunasDB();
            this.dgVacunas.DataSource = vacunaDB.Listar();
            dgVacunas.Columns[comboNombreIDs.vacunas].Visible = false;
        }
        private void Limpiar()
        {
            this.IdVacunas = -1;
            this.txtNombre.ResetText();
            cargarGrid();
            txtNombre.Focus();            
        }
        private Vacunas Vacuna_ControlAClase()
        {
            Vacunas vacuna = new Vacunas();
            vacuna.Nombre = txtNombre.Text.Trim();
            return vacuna;
        }
        #endregion
        #region Eventos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                Vacunas vacuna = Vacuna_ControlAClase();
                VacunasDB vacunaDB = new VacunasDB();
                if (vacunaDB.Agregar_Modificar(vacuna, ClinicaPro.General.accion.Agregar) != 0)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }            
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgVacunas.SelectedRows.Count == 1)
            {
                this.IdVacunas = (int)dgVacunas.CurrentRow.Cells[comboNombreIDs.vacunas].Value;
            }
            VacunasDB vacunaDB = new VacunasDB();                        
            if (vacunaDB.Eliminar(this.IdVacunas, this.IdUsuario))
            {
                Limpiar();
                MensajeDeActulizacion();
            }            
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                if (dgVacunas.SelectedRows.Count == 1)
                {
                    this.IdVacunas = (int)dgVacunas.CurrentRow.Cells[comboNombreIDs.vacunas].Value;
                }
                Vacunas vacuna = Vacuna_ControlAClase();
                vacuna.idVacunas = this.IdVacunas;
                VacunasDB vacunaDB = new VacunasDB();
                vacunaDB.Agregar_Modificar(vacuna, ClinicaPro.General.accion.Modificar);
                Limpiar();
                if ( vacunaDB.Agregar_Modificar(vacuna, ClinicaPro.General.accion.Modificar) != 0)
                {
                    Limpiar();
                    MensajeDeActulizacion();
                }            
            }
        }
        #endregion
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();            
        }
    }
}
