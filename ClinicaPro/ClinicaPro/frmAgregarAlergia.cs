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
using ClinicaPro.General.Constantes;
using ClinicaPro.DB.Consulta;
using System.Data.Entity.Core;


namespace ClinicaPro
{
    public partial class AgregarAlergia : Form    // No actualiza
    {
        public bool isModificar { get; set; }
        public int idAlergia { get; set; }
        /// <summary>
        /// Tamaño maximo  varchar en la BD  dia 3-7-2017
        /// </summary>
        private int varcharLenghDB = 50; 
        public AgregarAlergia()
        {
            InitializeComponent();
            isModificar = false;
        }
        ///<summary>
        /// Guarcar Cliente  
        /// Logica: 
        ///  1. Crear parametro necesario  Boleano isModificar 
        ///  2. Validar los controles del formulario  - Falso continua, True termina
        ///  3. Crear Entidad Cliente, llenar los campos con los valores en los controles
        ///  4. Compara el valor de idCLiente , si es -1 Nuevo registro, distinto a -1 Modifica
        ///  5. LLama al controlador de ClienteDB  para que lo añada  a Base Datos            
        ///  6.Agregar returna el id , la propiedad idCliente de esta ventana adquiere el valor
        ///  7.Limpia los campos            
        ///  8.GuardarResultado guarda la respuesta del mensaje de Dialogo 
        ///  9.Si GuardarResultado es ok cierra esta ventana;
        /// 
        ///</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {           
            Boolean isModificar = false;

            ClinicaPro.Entities.TipoAlergia tipoAlergia = new ClinicaPro.Entities.TipoAlergia();

            if (Validar()) { return; }

            tipoAlergia.Tipo_Alergia = cbNombre.Text.Trim();
            tipoAlergia.Especificacion = txtEspecificacion.Text.Trim();

            if (isModificar) { tipoAlergia.idAlergia = this.idAlergia; }

            ClinicaPro.DB.Consulta.TipoAlergiaDB tipoAlergiaDB = new ClinicaPro.DB.Consulta.TipoAlergiaDB();
            int result = tipoAlergiaDB.Agregar_Modificar(tipoAlergia, isModificar);

            if (result > 1)
                MensajeActualizacion();

            Limpiar();
        }
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
            if (cbNombre.Text.Length > varcharLenghDB)
            {
                detalles += "Campo Nombre" + Mensajes.TamanoTextoMuyGrande;
                this.cbNombre.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtEspecificacion.Text == String.Empty)
            {
                detalles += "Campo Especificacion" + Mensajes.Campo_Requerido;
                this.txtEspecificacion.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtEspecificacion.Text.Length > varcharLenghDB)
            {
                detalles += "Campo Especificacion" + Mensajes.TamanoTextoMuyGrande;
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
        private void Limpiar()
        {
            try
            {
                this.cbNombre.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                cbNombre.SelectedText = string.Empty;                
            }
            
            this.txtEspecificacion.ResetText();
            this.idAlergia = -1;
            this.isModificar = false;
        }

        private void AgregarAlergia_Load(object sender, EventArgs e)
        {
            this.cbNombre.DataSource = ClinicaPro.DB.Consulta.Viesta_tiposAlergia_ComboBox.Listar();
            cbNombre.DisplayMember = "Tipo_Alergia";
            
        }
        private void txtEspecificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();            
            
        }
        private void MensajeActualizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                               "Agregar_Modificar Alergia",
                                                 MessageBoxButtons.OKCancel,
                                                   MessageBoxIcon.Information);
        }
    }

}
