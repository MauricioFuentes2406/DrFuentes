using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias Añadidas
using ClinicaPro.General.Constantes;
using ClinicaPro.Entities;
using ClinicaPro.DB;

namespace Frm.Configuracion
{
    public partial class frmAlergias : Form
    {
        public int IdUsuario { get; set; }
        public int idAlergia { get; set; }

        const int IdVacia = -1;
        public frmAlergias()
        {
            InitializeComponent();
        }

        private void frmAlergias_Load(object sender, EventArgs e)
        {
            this.cbNombre.DataSource = ClinicaPro.DB.Consulta.Viesta_tiposAlergia_ComboBox.Listar();
            cbNombre.DisplayMember = "Tipo_Alergia";
            cargarGrid();
        }
        #region Metodos 
        private bool Validar()
        {
            ///<summary>
            ///  Valida los campos que no esten vacios ni incosistentes , los pone Color.AliceBlue
            ///  <value>String Detalles, usado para crear una cadena al final con detalles  </value>
            ///  <value>boolean hallazgo, usado como bandera, si encontro algo = true </value>
            ///  <return>hallazgo</return>
            /// </summary>          

            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (cbNombre.Text == String.Empty)
            {
                detalles += "Campo Nombre" + Mensajes.Campo_Requerido;
                this.cbNombre.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }

            if (txtEspecificacion.Text == String.Empty)
            {
                detalles += "Campo Especificacion" + Mensajes.Campo_Requerido;
                this.txtEspecificacion.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles,
                                    Mensajes.Upss_Falto_Algo,
                                        MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }
        private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      " Alergias ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private TipoAlergia TipoAlergia_ControlAClase()
        {
            TipoAlergia tipoAlergia = new TipoAlergia();
            tipoAlergia.Tipo_Alergia = cbNombre.Text.Trim();
            tipoAlergia.Especificacion = txtEspecificacion.Text.Trim();
            return tipoAlergia;
        }
          private void cargarGrid()
        {
           ClinicaPro.DB.Consulta.TipoAlergiaDB tipoAlergiaDb  = new ClinicaPro.DB.Consulta.TipoAlergiaDB();
           this.dgAlergia.DataSource = tipoAlergiaDb.Listar();
           this.dgAlergia.Columns["idAlergia"].Visible = false;
        }
          private void Limpiar()
          {
              this.idAlergia = -1;
              this.cbNombre.SelectedIndex = 0;
              this.txtEspecificacion.ResetText();
              cargarGrid();
              cbNombre.Focus();
          }
          private TipoAlergia getTipoAlergiaModificar()
          {
              if (dgAlergia.SelectedRows.Count == 1)
              {
                  this.idAlergia = (int)dgAlergia.CurrentRow.Cells["idAlergia"].Value;

                  TipoAlergia alergia = TipoAlergia_ControlAClase();
                  alergia.idAlergia = this.idAlergia;
                  return alergia;
              }
              else
              {
                  MensajeSeleccioneFila();
                  return null;
              }
          }
        private  void MensajeSeleccioneFila()
          {
              MessageBox.Show(Mensajes.Seleccione_Una_Fila, Mensajes.Upss_Falto_Algo,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        #endregion 
        #region Eventos
          private void btnAgregar_Click(object sender, EventArgs e)
          {
              if (!Validar())
              {                  
                      TipoAlergia droga = TipoAlergia_ControlAClase();
                      ClinicaPro.DB.Consulta.TipoAlergiaDB tipoAlergiaDb = new ClinicaPro.DB.Consulta.TipoAlergiaDB();

                      if (tipoAlergiaDb.Agregar_Modificar(droga, ClinicaPro.General.accion.Agregar) != IdVacia)
                      {
                          Limpiar();                          
                      }                                    
              }
          }
          private void btnActualizar_Click(object sender, EventArgs e)
          {
              if (!Validar())
              {
                  TipoAlergia alergia = getTipoAlergiaModificar(); 
                  ClinicaPro.DB.Consulta.TipoAlergiaDB tipoAlergiaDb = new ClinicaPro.DB.Consulta.TipoAlergiaDB();
                  if (tipoAlergiaDb.Agregar_Modificar(alergia, ClinicaPro.General.accion.Modificar) != IdVacia)
                  {
                      Limpiar();
                      MensajeDeActulizacion();
                  }
              }
          }
          private void btnEliminar_Click(object sender, EventArgs e)
          {
              if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar() == false)
                  return;
              if (dgAlergia.SelectedRows.Count == 1)
              {
                  if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                  {
                      this.idAlergia = (int)dgAlergia.SelectedRows[0].Cells["idAlergia"].Value;
                      ClinicaPro.DB.Consulta.TipoAlergiaDB TipoalergiaDb = new ClinicaPro.DB.Consulta.TipoAlergiaDB();
                      if (TipoalergiaDb.Eliminar(this.idAlergia, this.IdUsuario))
                      {
                          Limpiar();
                          MensajeDeActulizacion();
                      }
                  }
              }
              else
              {
                  MensajeSeleccioneFila();                  
              }
          }
          private void btnRefresh_Click(object sender, EventArgs e)
          {
              Limpiar();
          }
          private void dgAlergia_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
          {
              this.txtEspecificacion.Text = (string)dgAlergia.CurrentRow.Cells["Especificacion"].Value;
              this.cbNombre.Text = (string)dgAlergia.SelectedRows[0].Cells["Tipo_Alergia"].Value;
          }
          #endregion           
    }
}
