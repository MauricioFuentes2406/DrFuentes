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

namespace Frm
{
    public partial class frmBusquedas : Form
    {
        /// <summary>
        /// <para IdItem> Se almanece valor de Id cuando se recupera un registro desde la BD</para>
        /// </summary>        
        int IdItem = -1;

        /// <summary>
        ///  Se almacena la direccion fisica de una Imagen
        /// </summary>
        private string filename { get; set; }  

        public frmBusquedas()
        {
            InitializeComponent();
        }

        private void frmBusquedas_Load(object sender, EventArgs e)
        {

        }
        #region Eventos
        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            DialogResult resultado = openFileDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBoxImg.Load(openFileDialog1.FileName);
                this.filename = openFileDialog1.FileName;
            }
        }
        #endregion
        #region Metodos
        private Byte[] ImagenABitArray()
        {

            Byte[] bytecode;
            if (filename == null && pictureBoxImg.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBoxImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            else
            {
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
            Image image = null;
            MemoryStream ms = new MemoryStream(busquedaImagenes.Imagen);
            {
                image = Image.FromStream(ms);
            }
            pictureBoxImg.Image = image;
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
        #endregion
        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
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
            if (chkActivarBusqueda.Checked)
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
        #region KeyDown
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txtSintoma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtTratamiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtEnfermedadRelacionada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtDescripcionAdicional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter || e.KeyValue == (int)Keys.Down)
            {
                Control p;
                p = ((TextBox)sender).Parent;
                p.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            new Diccionario.frmBusquedaAvanzada().Show();
        }
    }
}
