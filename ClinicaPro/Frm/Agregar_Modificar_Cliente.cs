
namespace Frm
{
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
    using ClinicaPro.General.Enumerados;
    using ClinicaPro.DB.Cliente;
    using ClinicaPro.General.Constantes;
    using ClinicaPro.Entities;
    

    public partial class Agregar_Modificar_Cliente : Form
    {     
        //Atributos
        public  int idCliente { get; set; }
        public int idTipoUsuario { get; set; }
        public DialogResult abrirConsulta { get; set; }  // Ok - abre frmAgregarConsulta         
         
        /// <summary>
        /// Instancia Cliente, cuado se actualizar recupera los Datos
        /// </summary>
        public Cliente paraActualizar;     

        public Agregar_Modificar_Cliente()  //Constructor
        {
            this.idCliente = -1;
            idTipoUsuario = -1;
            abrirConsulta = DialogResult.No;  // Define si abrir inmediatamente el FrmAgregarConsulta por defecto No
            InitializeComponent();
        }

#region Eventos
        private void AgregarCliente_Load(object sender, EventArgs e)
        {           
               Cargar_Todos_Combo();
               if (paraActualizar != null)
               {
                   copiarDatosActualizar();  //LLena los controles con los datos del CLiente
               }
               ActivarAutoCompletetxtCiudad();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
           
            Boolean isModificar = ClinicaPro.General.accion.Agregar;
           
            ClinicaPro.Entities.Cliente cliente = new ClinicaPro.Entities.Cliente();

            if (Validar()) { return; }
           
            cliente.Nombre = this.txtNombre.Text.Trim();
            cliente.Edad = (byte)this.txtEdad.Value;
            if (rbHombre.Checked) { cliente.Sexo = "H"; } else { cliente.Sexo = "M"; }
            if (cbExtrajero.SelectedIndex == 0) { cliente.isExtranjero = false; } else { cliente.isExtranjero = true; }
            if (txtCelular.MaskCompleted) { cliente.Celular = int.Parse(txtCelular.Text); }
            if (txtCedula.MaskCompleted) { cliente.Cedula = txtCedula.Text.Trim(); }           
            cliente.Estado = (byte)cbEstadoCivil.SelectedValue;
            cliente.Apellido1 = txtPrimer_Apellido.Text.Trim();
            cliente.Apellido2 = txtSegundo_Apellido.Text.Trim();
            cliente.TipoSangre = cbTipoSangre.SelectedValue.ToString();
            cliente.Email = txtEmail.Text.Trim();
            cliente.Ciudad = txtCiudad.Text.Trim();

            if (paraActualizar != null) 
            {
              isModificar = ClinicaPro.General.accion.Modificar;
              cliente.IdCliente = this.idCliente; 
            }
            // Si es Agregar Pregunta si abrir Formulario 
            ClienteDB clienteAgregar = new ClienteDB();
            this.idCliente= clienteAgregar.Agregar_Modificar(cliente, isModificar);

            if (idCliente != -1)
               DesplegarMensajeDespuesGuardar(isModificar); 
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

///<summary>
///Cuando se preciona la tecla "enter" o la dirreción hacia "abajo", el windows Form enfoca el siguiente control 
///</summary>
#region NextControl_Con_Enter_KeyDown
        
        ///<value>Control p , fijarse que el tipo sea  igual  al control que hace la llamada </value>

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;                
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }                  
        private void txtPrimer_Apellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);

            }
        }
        private void txtSegundo_Apellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((MaskedTextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((MaskedTextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void cbExtrajero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((ComboBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void cbTipoSangre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((ComboBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txtCiudad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void cbEstadoCivil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((ComboBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txtEdad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((NumericUpDown)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }      

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            Control p;
            p = ((GroupBox)sender).Parent;
            p.SelectNextControl(ActiveControl, true, true, true, true);
        }

#endregion        
#endregion
#region Metodos
           private void DesplegarMensajeDespuesGuardar(bool isModificar)
        {
            if (isModificar== false)//SI es nuevo Progunta si desea abrir frmConsulta
            {
                this.abrirConsulta = MessageBox.Show(Mensajes.Agregar_Modificar + Mensajes.DeseaAbrirFRM_AgregarConsulta,
                                 "Agregar_Modificar CLiente",
                                   MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Information);
                if (abrirConsulta == DialogResult.OK)
                {
                    this.Close();  //MantenimientoCliente esta el codigo que abre Consulta
                }
                else
                {
                    Limpiar_Datos();
                }
            }
            else 
            {
                MessageBox.Show(Mensajes.Agregar_Modificar,
                                    "Agregar_Modificar CLiente",
                                      MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Information);
            }
        }
        public void Cargar_Todos_Combo()  // Se llama en el evento Load
        {
            Cargar_cbEstadoCivil();
            Cargar_TipoDeSangre();
            Cargar_Extrajero();
        }
        public void Cargar_cbEstadoCivil()
        {
                                             // Ver Referencia con f12
            this.cbEstadoCivil.DataSource = ClienteEnums.EstadoCivil;
            this.cbEstadoCivil.ValueMember = "valor";
            this.cbEstadoCivil.DisplayMember = "nombre";

        }
        public void Cargar_TipoDeSangre()
        {
            this.cbTipoSangre.DataSource = ClinicaPro.General.Enumerados.ClienteEnums.TipoDeSangre;
        }
        public void Cargar_Extrajero()
        {                                                                               //No o Si 
            this.cbExtrajero.DataSource = ClinicaPro.General.Enumerados.ClienteEnums.RespuestaBasica;
        }
        public Boolean Validar()
        {
            ///<summary>
            ///  Valida los campos que no esten vacios ni incosistentes , los pone Color.AliceBlue
            ///  <value>String Detalles, usado para crear una cadena al final con detalles  </value>
            ///  <value>boolean hallazgo, usado como bandera, si encontro algo = true </value>
            ///  <return>hallazgo</return>
            /// </summary>          

            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (txtNombre.Text == String.Empty)
            {
                detalles += "Campo Nombre" + Mensajes.Campo_Requerido;
                this.txtNombre.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if(txtPrimer_Apellido.Text == String.Empty)
            {
                detalles += "Campo PrimerApellido" + Mensajes.Campo_Requerido;
                this.txtPrimer_Apellido.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtSegundo_Apellido.Text == String.Empty)
            {
                detalles += "Campo Segundo Apellido" + Mensajes.Campo_Requerido;
                this.txtSegundo_Apellido.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if ( txtCiudad.Text == String.Empty)
            {
                detalles += "Ciudad " + Mensajes.Campo_Requerido;
                this.txtCiudad.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtCelular.Text.Length > 0 && txtCelular.MaskCompleted == false)
            {
                detalles += "Celular " + Mensajes.Campo_DatoIncompleto;
                this.txtCelular.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (this.txtEdad.Value == 0)
            {
                detalles += "Campo edad" + Mensajes.Numero_Mayor_Cero;
                this.txtEdad.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles,Mensajes.Upss_Falto_Algo ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }   
        public void Limpiar_Datos()  // Resetea todos los campos a sus valores por defecto
        {
          this.idCliente =-1;
          this.idTipoUsuario= -1;
          this.txtNombre.Text = String.Empty;
          this.txtPrimer_Apellido.Text = String.Empty;
          this.txtSegundo_Apellido.Text = String.Empty;
          this.txtCelular.Text = String.Empty;
          this.txtCedula.Text = String.Empty;
          this.txtCiudad.Text = String.Empty;
          this.txtEmail.Text = String.Empty;
          this.txtEdad.Value = 0;
          this.cbExtrajero.SelectedIndex = 0;
          this.cbTipoSangre.SelectedIndex = 0;
          this.cbEstadoCivil.SelectedIndex = 0;
          this.rbHombre.Select();
        }
        private void copiarDatosActualizar()
        {
            this.idCliente = paraActualizar.IdCliente;
            this.txtNombre.Text = paraActualizar.Nombre;
            this.txtPrimer_Apellido.Text = paraActualizar.Apellido1;
            this.txtSegundo_Apellido.Text = paraActualizar.Apellido2;
            if (txtCelular != null)
            { this.txtCelular.Text = paraActualizar.Celular.ToString(); }
            if (paraActualizar.Cedula != null)
            { this.txtCedula.Text = (string)paraActualizar.Cedula; }
            this.txtEdad.Value = paraActualizar.Edad;
            this.txtCiudad.Text = paraActualizar.Ciudad;
            this.txtEmail.Text = paraActualizar.Email;            
            this.cbTipoSangre.SelectedItem = paraActualizar.TipoSangre;


            if (paraActualizar.Estado != null) { cbEstadoCivil.SelectedValue = paraActualizar.Estado; }
            if (paraActualizar.isExtranjero) { this.cbExtrajero.SelectedItem = "Si"; }           
            if (paraActualizar.Sexo == "M") { this.rbMujer.Select(); }                      
        }        
        
        public String getNombreCompleto()
        {
            return txtNombre.Text + " " + txtPrimer_Apellido.Text + " " + txtSegundo_Apellido.Text;
        }
        private void ActivarAutoCompletetxtCiudad()
        {
            ClinicaPro.BL.AutoCompleteTextControl.Activar(txtCiudad, ClienteDB.ListarNombresCiudad());
        }
       
#endregion          
    }
}
