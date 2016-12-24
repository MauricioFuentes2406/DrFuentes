using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias añadidas
using ClinicaPro.DB;
using ClinicaPro.Entities;

namespace Frm
{
    public partial class ClienteBuscar : Form
    {
        // Atributos         
        public List<Cliente>  lista_filtrada;
        public ClienteBuscar()
        {
            InitializeComponent();
            ClinicaPro.DB.Cliente.ClienteDB clienteDb = new ClinicaPro.DB.Cliente.ClienteDB(); 
            this.lista_filtrada = clienteDb.Listar();
        }
        public ClienteBuscar(List<Cliente> listaSource)
        {
            InitializeComponent();
            this.lista_filtrada = listaSource;
        }
        public List<int> getIdClientesDeFiltros()
        {
            return (from n in lista_filtrada
                    select n.IdCliente).ToList();
        }
        private void ClienteBuscar_Load(object sender, EventArgs e)
        {
            ActivarAutoCompletetxtCiudad();
        }
        private void btnEViviendaDetalle_Click(object sender, EventArgs e)
        {
            if (cedulaChek() )
            {
                buscarCedula();
            }
            else if (nombreChek() ) 
            {
                buscarNombre();
            }
            else if ( apellidosChek() )
            {
                buscarApellido();
            }else if ( ciudadChek() )
            {
                buscarCiudad();
            }
            else if (idClienteChek())
            {
                buscarIdCliente();
            }           

            // Genero
            if (rbHombre.Checked)
            {
                buscarHombres();
            }
            else if (rbMujer.Checked)
            {
                buscarMujeres();
            }                       

            this.Hide();
        }
        private void buscarCedula()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Cedula.Contains(txtCedula.Text)
                              select EntidadLocal).ToList();
        }
        private void buscarNombre()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Nombre.Contains(txtNombre.Text)
                              select EntidadLocal).ToList();
        }
        private void buscarApellido()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Apellido1.Contains(txtApellido1.Text) || EntidadLocal.Apellido2.Contains(txtApellido1.Text)
                              select EntidadLocal).ToList();
        }
        private void buscarCiudad()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Ciudad.Contains(txtCiudad.Text)
                              select EntidadLocal).ToList();
        }
        private void buscarHombres()
        {
             lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Sexo == "H"
                              select EntidadLocal).ToList();
        }
        private void buscarMujeres()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Sexo == "M"
                              select EntidadLocal).ToList();
        }
        private void buscarIdCliente()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.IdCliente == (int)txtIdCliente.Value
                              select EntidadLocal).ToList();
        }
        private void ActivarAutoCompletetxtCiudad()
        {
            ClinicaPro.BL.AutoCompleteTextControl.Activar(txtCiudad, ClinicaPro.DB.Cliente.ClienteDB.ListarNombresCiudad());
        }
        #region chekControles
        /// <summary>
        ///  Revisa si los controles estan vacios
        ///   <remarks> todos los return deben ir acompañados de "!"  </remarks>
        /// </summary>
        /// <returns>True si hay contenido, Falso si esta vacio </returns>

        private bool cedulaChek()
        {       
            return !String.IsNullOrWhiteSpace(txtCedula.Text);            
        }
        private bool nombreChek()
        {
            return !String.IsNullOrWhiteSpace(txtNombre.Text);            
        }

        private bool apellidosChek()
        {
            return !String.IsNullOrEmpty(txtApellido1.Text);
        }
        private bool  ciudadChek()
        {
            return !String.IsNullOrEmpty(txtCiudad.Text);
        }
        private bool idClienteChek()
        {
            if (txtIdCliente.Value == 0)
                return false;
            else 
                return true;
        }        
        #endregion
    }
}
