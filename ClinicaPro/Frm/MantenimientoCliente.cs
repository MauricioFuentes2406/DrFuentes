
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

    //Librerias Añadidas
    using ClinicaPro.DB;
    using ClinicaPro.Entities;
    using ClinicaPro.General.Constantes;

    public partial class MantenimientoCliente : Form
    {
        //        ~~~~~~~~~~~~~~~~~~ Atributos  ~~~~~~~~~~~~~~~~~~~~~~~~
        public int idCliente { get; set; }
        private String _nombre;
        public int idTipoUsario { get; set; }


        //        ~~~~~~~~~~~~~~~~~~ Constructor  ~~~~~~~~~~~~~~~~~~~~~~~~      
        public MantenimientoCliente(int idTipoUsuario)
        {
            idTipoUsario = idTipoUsuario;
            idCliente = -1;
            InitializeComponent();
        }
        #region Eventos
        private void MantenimientoCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
            if (this.idTipoUsario != TipoUsuarios.CristianRoot && this.idTipoUsario != TipoUsuarios.General)
            { 
                btnAgregarConsulta.Visible = false;
                this.btnEliminar.Enabled = false;
                this.btnModificar.Enabled = false;
            }
        }        
        private void btnAgregar_Click(object sender, EventArgs e)  //Agrega CLiente
        {
            ///<summary>
            /// Directiva using , se asegurar de liberar los recursos de los DialogForm
            /// <seealso cref="http://dotnetfacts.blogspot.com/2008/03/things-you-must-dispose.html"/>    
            ///</summary>

            DialogResult abrirConsulta;
            using (Agregar_Modificar_Cliente agregarClienteFrm = new Agregar_Modificar_Cliente())
            {
                agregarClienteFrm.ShowDialog();
                this.idCliente = agregarClienteFrm.idCliente;
                abrirConsulta = agregarClienteFrm.abrirConsulta;
                _nombre = agregarClienteFrm.getNombreCompleto();
            }
            if (abrirConsulta == DialogResult.OK)
            {

                using (AgregarConsulta agregarConsultaFrm = new AgregarConsulta(idCliente, getNombreCompleto()))
                {
                    this.Close();
                    agregarConsultaFrm.ShowDialog();
                }
            }
            else
            {
                CargarDatos();
            }
        }
        private void btnAgregarConsulta_Click(object sender, EventArgs e)
        {
            if (dgClientes.SelectedRows.Count == 1)
            {
                using (AgregarConsulta agregarConsultaFrm = new AgregarConsulta(idCliente, getNombreCompleto()))
                {
                    this.Close();
                    agregarConsultaFrm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(Mensajes.Seleccione_Una_Fila, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dgClientes.SelectedRows.Count >= 1)
            {
                Cliente auxiliar = Modificar_DeFila_A_Clase(this.dgClientes.CurrentRow);

                using (Agregar_Modificar_Cliente agregarClienteFrm = new Agregar_Modificar_Cliente())
                {
                    agregarClienteFrm.paraActualizar = auxiliar;
                    agregarClienteFrm.ShowDialog();

                }
                CargarDatos();
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgClientes.SelectedRows.Count >= 1)
            {
                if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
                {
                    new ClinicaPro.DB.Cliente.ClienteDB().Eliminar(this.idCliente, this.idTipoUsario);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show(Mensajes.Seleccione_Una_Fila, "Para Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void dgClientes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) //Sirve para?
        {
            this.idCliente = (int)this.dgClientes.CurrentRow.Cells["idCliente"].Value;
            this._nombre = concatenarNombreCompletoGrid(dgClientes.CurrentRow);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (ClienteBuscar buscarClienteFrm = new ClienteBuscar(dgClientes.DataSource as List<Cliente>))
            {
                buscarClienteFrm.ShowDialog();
                dgClientes.DataSource = buscarClienteFrm.lista_filtrada;
            }
        }
        #endregion

        #region Metodos
        private String concatenarNombreCompletoGrid(DataGridViewRow currentRoW)
        {
            String auxiliar = String.Empty;
            auxiliar = (String)this.dgClientes.CurrentRow.Cells["Nombre"].Value;
            auxiliar += " " + (String)this.dgClientes.CurrentRow.Cells["Apellido1"].Value;
            auxiliar += " " + (String)this.dgClientes.CurrentRow.Cells["Apellido2"].Value;
            return auxiliar;
        }
        private void CargarDatos()
        {
            try
            {
                ClinicaPro.DB.Cliente.ClienteDB clienteDB = new ClinicaPro.DB.Cliente.ClienteDB();
                this.dgClientes.DataSource = clienteDB.Listar();
            }
            catch (Exception)
            {

            }
        }

        private Cliente Modificar_DeFila_A_Clase(DataGridViewRow filaActual)
        {
            Cliente auxiliar = new Cliente();

            auxiliar.IdCliente = (int)filaActual.Cells["idCliente"].Value;
            auxiliar.Nombre = filaActual.Cells["Nombre"].Value.ToString();
            auxiliar.Apellido1 = filaActual.Cells["Apellido1"].Value.ToString();
            auxiliar.Apellido2 = filaActual.Cells["Apellido2"].Value.ToString();

            auxiliar.Edad = (byte)filaActual.Cells["Edad"].Value;
            auxiliar.Sexo = filaActual.Cells["Sexo"].Value.ToString();
            auxiliar.Ciudad = filaActual.Cells["Ciudad"].Value.ToString();
            auxiliar.isExtranjero = (bool)filaActual.Cells["isExtranjero"].Value;

            /// Campos Que pueden venir NULL, condicion verifica para que no halla un error
            if (filaActual.Cells["TipoSangre"].Value != null)
            { auxiliar.TipoSangre = filaActual.Cells["TipoSangre"].Value.ToString(); }
            if (filaActual.Cells["Estado"].Value != null)
            { auxiliar.Estado = (byte)filaActual.Cells["Estado"].Value; }
            if (filaActual.Cells["Cedula"].Value != null)
            { auxiliar.Cedula = filaActual.Cells["Cedula"].Value.ToString(); }
            if (filaActual.Cells["Celular"].Value != null)
            { auxiliar.Celular = (int)filaActual.Cells["Celular"].Value; }
            if (filaActual.Cells["Email"].Value != null)
            { auxiliar.Email = filaActual.Cells["Email"].Value.ToString(); }
            return auxiliar;
        }
        public String getNombreCompleto()
        {
            return _nombre;
        }

        #endregion




    }

}
