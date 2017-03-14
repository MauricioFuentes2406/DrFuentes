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
using System.IO;
using ClinicaPro.Entities;
using ClinicaPro.DB;
using ClinicaPro.General;
using ClinicaPro.General.Constantes;
using System.Drawing.Imaging;

namespace ClinicaPro.Diccionario
{
    public partial class frmDiccionario : Form
    {
        /// <summary>
        /// <para IdItem> Se almanece valor de Id cuando se recupera un registro desde la BD</para>
        /// </summary>        
        int IdItem = -1;

        /// <summary>
        ///  Se almacena la direccion fisica de una Imagen
        /// </summary>
        private string filename { get; set; }  

        public frmDiccionario()
        {
            InitializeComponent();
        }

        private void frmBusquedas_Load(object sender, EventArgs e)
        {
            ActivarAutoCompletetxtNombre();
            this.pictureBoxImg.SizeMode = PictureBoxSizeMode.AutoSize;
            FilterOpenDialog();
        }
        #region Eventos
        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            DialogResult resultado = openFileDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                try
                {
                    pictureBoxImg.Load(openFileDialog1.FileName);
                    this.filename = openFileDialog1.FileName;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(this, Mensajes.ExtencionImagen, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                 
                }
                
            }
        }
        #endregion
        #region Metodos
        private Byte[] ImagenABitArray()
        {

            Byte[] bytecode= null;
            if (filename == null && pictureBoxImg.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBoxImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            else
            {   
                if(filename != null)
                bytecode = File.ReadAllBytes(filename);
            }

            return bytecode;
        }

        private void Clase_A_Controles(Busqueda Entidad)
        {
            if (Entidad.BusquedaImagenes != null)
            {
                recuperarIMG(Entidad.BusquedaImagenes.FirstOrDefault());
            }
            txtDescripcionAdicional.Text = Entidad.DescripcionAdicional;
            txtEnfermedadRelacionada.Text = Entidad.EnfermedadRelacionada;
            txtSintoma.Text = Entidad.EnfermedadRelacionada;
            txtTratamiento.Text = Entidad.Tratamiento;
        }
        private List<BusquedaImagene> creaInstanciaBusquedaImagen() // No añade Id, lo hace EF al agregar 
        {
            List<BusquedaImagene> lista = new List<BusquedaImagene>();
            BusquedaImagene busquedaImg = new BusquedaImagene();
            busquedaImg.Imagen = ImagenABitArray();
            if (busquedaImg.Imagen != null)
                 lista.Add(busquedaImg);
            return lista;
        }
        /// <summary>
        /// Crea una instacia Busqueda con los datos en los controles , 
        
        /// </summary>        
        /// 
        /// <returns></returns>
        private Busqueda Controles_A_Clase() 
        {
            Busqueda busqueda = new Busqueda();
            busqueda.BusquedaImagenes = creaInstanciaBusquedaImagen();
            busqueda.DescripcionAdicional = txtDescripcionAdicional.Text.Trim();
            busqueda.EnfermedadRelacionada = txtEnfermedadRelacionada.Text.Trim();
            busqueda.Nombre = txtNombre.Text.ToLower().Trim();
            busqueda.Síntoma = txtSintoma.Text.Trim();
            busqueda.Tratamiento = txtTratamiento.Text.Trim();
            if (accion.Modificar)
            {
                busqueda.IdItem = this.IdItem;
            }
            return busqueda;
        }
        private void recuperarIMG(BusquedaImagene busquedaImagenes)
        {
            try
            {
                if (busquedaImagenes == null) return;
                if (busquedaImagenes.Imagen == null) return;
                Image image = null;
                MemoryStream ms = new MemoryStream(busquedaImagenes.Imagen);
                {
                    image = Image.FromStream(ms);
                }
                pictureBoxImg.Image = image;
            }             
            catch (Exception )
            {
                MessageBox.Show(this, Mensajes.ErrorCargarImagen, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
            
        }
        /// <summary>
        /// Valida los datos que hay en los controles 
        /// </summary>
        /// <returns> Falso si todo esta esta bien, true si hay algun error</returns>
        private bool Validar()
        {
            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (String.IsNullOrWhiteSpace(txtNombre.Text))
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
        private void ActivarAutoCompletetxtNombre()
        {
            ClinicaPro.BL.AutoCompleteTextControl.Activar(txtNombre, BusquedaDB.ListarNombres());            
        }
        private void DesactivarAutoCompletetxtNombre()
        {
            ClinicaPro.BL.AutoCompleteTextControl.DesActivar(txtNombre);          
        }
        private void LimpiarControles()
        {
            txtNombre.Text = String.Empty;
            DesactivarAutoCompletetxtNombre();
            txtDescripcionAdicional.Text = String.Empty;
            txtEnfermedadRelacionada.Text = String.Empty;
            txtSintoma.Text = String.Empty;
            txtTratamiento.Text = String.Empty;
            pictureBoxImg.Image = null;
        }
        private void Agregar_Modificar(bool isModificar)
        {
            ClinicaPro.DB.BusquedaDB busquedaDB = new BusquedaDB();
            int a = busquedaDB.Agregar_Modificar(Controles_A_Clase(), isModificar);
            if (a >= 1)
            {
                MessageBox.Show(ClinicaPro.General.Constantes.Mensajes.Agregar_Modificar);
            }
        }
        private void FilterOpenDialog()
        {
            ClinicaPro.BL.manejaImagenes.ConfigurarFileDialogFilter(openFileDialog1);
        }
        #endregion
        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar() && chkActivarGuardar.Checked)
            {
                return;
            }
            else
            {
                if (IdItem == -1)
                {
                    Agregar_Modificar(accion.Agregar);                    
                } if (IdItem > 0)
                {
                    Agregar_Modificar(accion.Modificar);
                }
                LimpiarControles();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                return;
            }
            else
            {
                Busqueda entidad;
                ClinicaPro.DB.BusquedaDB busquedaDB = new BusquedaDB();
                entidad = busquedaDB.busquedaPorNombre(txtNombre.Text.ToLower().Trim());
                IdItem = entidad.IdItem;
                if (entidad != null)
                {
                    Clase_A_Controles(entidad);
                }
                else
                {
                    MessageBox.Show("Intente escribrir un nuevo nombre", Mensajes.No_Se_Encontro_Ningun_Registro, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Text = String.Empty;
                    this.txtNombre.Focus();
                }
            }
        }
        private void chkActivarBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkActivarGuardar.Checked)
            {
                ActivarAutoCompletetxtNombre();
                txtNombre.Focus();

            }
            else
            {
                DesactivarAutoCompletetxtNombre();
            }
        }
        #endregion        
        private void btnBusquedaAvanzada(object sender, EventArgs e)
        {
            new Diccionario.frmBusquedaAvanzada().Show();
        }
    }
}
