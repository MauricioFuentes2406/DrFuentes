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
using ClinicaPro.General;
using ClinicaPro.DB.Cliente;

namespace ClinicaPro.ConsultaGeneral
{
    public partial class frmEscogerCliente : Form
    {
        public int IdCliente { get; set; }
        public string nombreCliente { get; set; }
        public frmEscogerCliente()
        {
            InitializeComponent();
        }
        private void setValores(ClienteDB.NombresYIDs cliente )
        {
            this.IdCliente = cliente.IdCliente;
            this.nombreCliente = cliente.Nombre;         
        }
        private void frmEscogerCliente_Load(object sender, EventArgs e)
        {
            cargarClientes();
            if (cbNombre.Items.Count > 0)
            {
                var cliente = (ClienteDB.NombresYIDs)this.cbNombre.Items[0];
                if (cliente != null)
                {
                    setValores(cliente);
                    this.numNumeroCliente.Value = IdCliente;
                }
            }
        }
        private void cargarClientes()
        {
            var list = new ClinicaPro.DB.Cliente.ClienteDB().ListarNombreyID();
            new BL.ComboBoxBL<ClienteDB.NombresYIDs>().fuenteBaseDatos(this.cbNombre, list, General.Constantes.comboNombreIDs.Cliente);
            
        }
        private void cbNombre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var cliente = (ClienteDB.NombresYIDs)this.cbNombre.SelectedItem;
                if (cliente != null)
                {
                    setValores(cliente);
                    this.numNumeroCliente.Value = IdCliente;
                }
            }
            catch (Exception ex)
            {
                                
            }
        }   
    private class auxiar
    {
        public string IdCliente { get; set; }
        public string nombreCliente { get; set; }
        private auxiar()
        {
            IdCliente = string.Empty;
            nombreCliente = string.Empty;
        }
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            var cliente = (ClienteDB.NombresYIDs)this.cbNombre.SelectedItem;
            if (cliente != null)
            {
                setValores(cliente);
            }
        }
        catch (Exception ex)
        {

        }
    }            
    }
}
