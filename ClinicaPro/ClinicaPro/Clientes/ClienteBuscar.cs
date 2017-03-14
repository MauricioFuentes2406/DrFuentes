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
using ClinicaPro.DB.Cliente.Vistas;

namespace ClinicaPro.Clientes
{
    public partial class ClienteBuscar : Form
    {
        // Atributos         
        public List<VistaCliente>  lista_filtrada;
        public ClienteBuscar()
        {
            InitializeComponent();
            this.lista_filtrada = VCliente.Listar();
        }
        public ClienteBuscar(List<VistaCliente> listaSource)
        {
            InitializeComponent();
            this.lista_filtrada = listaSource;
        }
        public List<int> getIdClientesDeFiltros()
        {
            return (from n in lista_filtrada
                    select n.IdCliente).ToList();
        }
        public void Cargar_TipoDeSangre()
        {
            this.cbTipoSangre.DataSource = ClinicaPro.General.Enumerados.ClienteEnums.TipoDeSangre;
            cbTipoSangre.SelectedIndex = -1;
        }
        private void ClienteBuscar_Load(object sender, EventArgs e)
        {
            ActivarAutoCompletetxtCiudad();
            Cargar_TipoDeSangre();
        }
        private void btnEViviendaDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cedulaChek())
                {
                    buscarCedula();
                }
                else if (nombreChek())
                {
                    buscarNombre();
                }
                else if (apellidosChek())
                {
                    buscarApellido();
                }
                else if (ciudadChek())
                {
                    buscarCiudad();
                }
                else if (idClienteChek())
                {
                    buscarIdCliente();
                }    
                else if (rangoEdadChek() )
                {
                    buscarRangoEdad();
                }
                else if (tipoSangreChek() )
                {
                    buscarTipoSangre();
                }
            }
                catch(NullReferenceException nullException)
                    {
                        ClinicaPro.BL.manejaExcepcionesDB.manejaNullReference(nullException);                        
                    }
                    catch (Exception ex)
                    {
              
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
                               where EntidadLocal.Cedula != null &&
                                EntidadLocal.Cedula.Contains(txtCedula.Text)
                                 select EntidadLocal).ToList();
        }        
        private void buscarNombre()
        {            
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Nombre.ToLower().Contains(txtNombre.Text.ToLower())
                              select EntidadLocal).ToList();
        }
        private void buscarApellido()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Apellido1.ToLower().Contains(txtApellido1.Text.ToLower()) 
                                 || EntidadLocal.Apellido2.ToLower().Contains(txtApellido1.Text.ToLower())
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
        private void buscarRangoEdad()
        {
              lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.Edad >= txtEdadMinima.Value &&
                                    EntidadLocal.Edad <= txtEdadMaxima.Value 
                              select EntidadLocal).ToList();
        }
        private void buscarTipoSangre()
        {
            lista_filtrada = (from EntidadLocal in lista_filtrada
                              where EntidadLocal.TipoSangre == this.cbTipoSangre.Text                                    
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
        private bool tipoSangreChek()
        {
            if (this.cbTipoSangre.SelectedIndex != -1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Revisa que Edad Minima y Edad Maxima sean mayores a Cero
        /// </summary>
        /// <returns></returns>
        private bool rangoEdadChek()
        {
            if (txtEdadMinima.Value == 0 && txtEdadMaxima.Value == 0)
                return false;
            return true;
        }
        #endregion
    }
}
