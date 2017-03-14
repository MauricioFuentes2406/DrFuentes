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
using ClinicaPro.Entities;
using ClinicaPro.General.Constantes;
namespace Frm
{
    public partial class Expediente : Form
    {
        public int idCliente { get; set; }
        /// <summary>
        /// Variable global que enlista los IdConsulta relaciones con con un cliente o criterio de busqueda espécifico
        /// </summary>
        private List<int> _ListaIdConsultas;
        private const String Nombre = "Nombre";
        private const String Numero_Consulta = "Número_Consulta";
        private const String columnIdCliente = "IdCliente";

        public Expediente()
        {
            _ListaIdConsultas = new List<int>();
            InitializeComponent();
        }

        private void Expediente_Load(object sender, EventArgs e)
        {            
            llenarConsulta_NoFiltro();
        }

        #region Metodos
        /// <summary>
        /// Utiliza la vista VConsultaCliente para llenar el gridConsulta, ordena del más reciente al más antiguo
        /// </summary>
        private void llenarConsulta_NoFiltro()
        {
            this.dgConsulta.DataSource = ClinicaPro.DB.Consulta.Vistas.VConsulta.Listar();
            dgConsulta.Columns[columnIdCliente].Visible = false;
        }
        private void obtenerIdConsultasdeCliente(int argIdCliente)
        {
            var lista = this.dgConsulta.DataSource as List<VistaConsulta>;
            _ListaIdConsultas = (from n in lista
                                 where n.IdCliente == argIdCliente
                                 select n.Número_Consulta).ToList();

        }     
        private void llenarFiltroxCliente()
        {
            if (_ListaIdConsultas != null)
            {
                foreach (int idConsulta in _ListaIdConsultas)
                {
                    llenarconVerDetalle(idConsulta);
                }
            }
        }
        private void setNombreNumeroClienteDisplayControl()
        {
            this.txtNombre.Text = this.dgConsulta.CurrentRow.Cells[Nombre].Value.ToString();
            this.txtNumeroCliente.Value = (int)this.dgConsulta.CurrentRow.Cells[columnIdCliente].Value;
        }
        private void llenarconVerDetalle(int idConsulta)
        {
            // Exploracion Fisica
            ClinicaPro.DB.Consulta.Expediente.controladorExpedienteDB controladorExpediente = new ClinicaPro.DB.Consulta.Expediente.controladorExpedienteDB();

            controladorExpediente.addVExploracionFisica(idConsulta);
            this.dgExFisica_General.DataSource = controladorExpediente.get_ListExploracionFisica();
          

            controladorExpediente.addVEstadoVivienda(idConsulta);
            this.dgEstadoVivienda.DataSource = controladorExpediente.get_ListaEstadoVivienda();           

            controladorExpediente.addVToraxPulmones(idConsulta);
            this.dgTorax.DataSource = controladorExpediente.get_ListaVistaToraxPulmones();
          
            controladorExpediente.addConsultaCraneo(idConsulta);
            this.dgCraneo.DataSource = controladorExpediente.get_ListaConsultaCraneo();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgCraneo);

            controladorExpediente.addConsultaOjo(idConsulta);
            this.dgOjos.DataSource = controladorExpediente.get_ListaConsultaOjo();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgOjos);

            controladorExpediente.addConsultaOido(idConsulta);
            this.dgOidos.DataSource = controladorExpediente.get_ListaConsultaOido();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgOidos);

            controladorExpediente.addConsultaNariz(idConsulta);
            this.dgNariz.DataSource = controladorExpediente.get_ListaConsultaNariz();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgNariz);

            controladorExpediente.addConsultaBoca(idConsulta);
            this.dgBoca.DataSource = controladorExpediente.get_ListaConsultaBoca();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgBoca);

            controladorExpediente.addConsultaCuello(idConsulta);
            this.dgCuello.DataSource = controladorExpediente.get_ListaConsultaCuello();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgCuello);

            controladorExpediente.addConsultaAbdomen(idConsulta);
            this.dgAbdomen.DataSource = controladorExpediente.get_ListaConsultaAbdomen();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgAbdomen);

            controladorExpediente.addConsultaAparatoDigestivo(idConsulta);
            this.dgApaDigestivo.DataSource = controladorExpediente.get_ListaConsultaAparatoDigestivo();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgApaDigestivo);


            controladorExpediente.addConsultaCoordinacionMarcha(idConsulta);
            this.dgCoordinacion.DataSource = controladorExpediente.get_ListaConsultaCoodinacionMarcha();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgCoordinacion);

            controladorExpediente.addAntecedenteGinecoObstretico(idConsulta);
            this.dgGinecoObstreticos.DataSource = controladorExpediente.get_ListaAntecedenteGinecoObstreticos();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgGinecoObstreticos);
            //  Sentidos
            controladorExpediente.addEstadoEmocional(idConsulta);
            this.dgEstadoEmocional.DataSource = controladorExpediente.get_ListaEstadoEmocional();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgEstadoEmocional);

            controladorExpediente.addSensibilidad(idConsulta);
            this.dgSensibilidad.DataSource = controladorExpediente.get_ListaSensibilidad();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgSensibilidad);

            controladorExpediente.addConsultaParesCraneales(idConsulta);
            this.dgParesCraneales.DataSource = controladorExpediente.get_ListaParesCraneales();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgParesCraneales);

            controladorExpediente.addReflejo(idConsulta);
            this.dgReflejos.DataSource = controladorExpediente.get_ListaReflejo();
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgReflejos);

            /**/
            ClinicaPro.DB.Consulta.ConsultaGaslowDB.ListaPorConsulta(idConsulta, dgGlasgow);

            controladorExpediente.addVServicios(idConsulta);
            this.dgServicios.DataSource = controladorExpediente.get_ListaVServicios();

            //Antecedentes  

            controladorExpediente.addVAntecedentePatologico(idConsulta);
            dgAntePatologicos.DataSource = controladorExpediente.get_ListaVAntecedentePatologico();


            controladorExpediente.addVAntecedenteHereditario(idConsulta);
            dgHereditario.DataSource = controladorExpediente.get_ListaVAntecedenteHereditario();

            controladorExpediente.addVDrogas(idConsulta);
            this.dgDroga.DataSource = controladorExpediente.get_ListaVDrogas();

            controladorExpediente.addVVacunas(idConsulta);
            this.dgVacunas.DataSource = controladorExpediente.get_ListaVVacunas();

            controladorExpediente.addVAlcohol(idConsulta);
            this.dgAlchol.DataSource = controladorExpediente.get_ListaVAlcohol();

            controladorExpediente.addVTabaco(idConsulta);
            dgTabaco.DataSource = controladorExpediente.get_ListaVTabaco();

            
            //Otras Cosas 
            controladorExpediente.addSeguimiento(idConsulta);
            dgSeguimientos.DataSource = controladorExpediente.get_ListaSeguimiento();
            dgSeguimientos.Columns["IdSeguimiento"].Visible = false;
                
            cambiarEncabezadoIdConsulta_NumeroConsulta(dgSeguimientos);
            HeadertextNumeroConsulta(); // Estético

        }
        /// <summary>
        ///  Estetico , cambio nombre de IdConsulta a Numero de Consulta
        /// </summary>
        /// <param name="gridconIdConsulta"></param>
        private void cambiarEncabezadoIdConsulta_NumeroConsulta(DataGridView gridconIdConsulta)
        {
            gridconIdConsulta.Columns["IdConsulta"].HeaderText = "Número de Consulta";
        }
        private void llenarAlergiasDetalle(int idCliente)
        {
            this.dgAlergias.DataSource = ClinicaPro.DB.Cliente.Vistas.VClienteAlergias.Listar(idCliente);
        }
        private void llenarAlergiasFiltroClientes(List<int> idCliente)
        {
            this.dgAlergias.DataSource = ClinicaPro.DB.Cliente.Vistas.VClienteAlergias.Listar(idCliente);
        }
        private void llenarImagenesDetalle(int IdCliente)
        {
            var list = ClinicaPro.DB.Cliente.ImagenesExamenesComplementariasBD.Listar(IdCliente);
            if (list.Count == 0) return;                
            List<Image> images = ClinicaPro.BL.manejaImagenes.recuperarIMG((from n in list select n.Imagen).ToList());                            
            LigarImagenesBindingNavigator(images);                                  
        }
        private void LigarImagenesBindingNavigator(List<Image> images)
        {          
            BindingSource BindingSource = new BindingSource();
            foreach (var item in images)
            {
                BindingSource.Add(item);
            }
            this.bNavigatorImagenesComplemntarias.BindingSource = BindingSource;

            this.pictureBoxComplementarias.Image = (Image)bNavigatorImagenesComplemntarias.BindingSource.Current; //Carga la primera img en el bindingNavigator
            
            pictureBoxComplementarias.SizeMode = PictureBoxSizeMode.AutoSize; //Sincroniza los Scroll del Panel y PictureBox

        }
        private void llenarCitasDetalle(int IdCliente)
        {
           this.dgCitas.DataSource = ClinicaPro.DB.Cita.CitasDB.Listar(IdCliente);
           this.dgCitas.Columns["IdCita"].Visible = false;
           this.dgCitas.Columns["Cliente"].Visible = false;
        }
         private void  llenarPDF(int  IdCliente)
        {
            this.dgElectros.DataSource= ElectroDB.ListaPorCliente(IdCliente);
             this.dgElectros.Columns["Cliente"].Visible = false;
             this.dgElectros.Columns["Consulta"].Visible = false;
             this.dgElectros.Columns["Consulta"].Visible = false;
             this.dgElectros.Columns["ElectroResultado"].Visible= false;
             this.dgElectros.Columns["IdConsulta"].HeaderText=Numero_Consulta;
             this.dgElectros.Columns["IdCliente"].HeaderText="Número_Cliente";                                      
        }
        #endregion
        /// <summary>
        ///  identifica si la celda actual es la Botón del Grid para ver Detalles
        /// </summary>        
        private void dgConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si añade un botón extra al grid podría haber confuciones, en tal caso , identifique por otro medio como Index
            var senderASGrid = (DataGridView)sender;
            if (senderASGrid.CurrentCell is DataGridViewButtonCell)
            {
                this.idCliente = (int)senderASGrid.CurrentRow.Cells[columnIdCliente].Value;
                //   this.txtNombre.Text = senderASGrid.CurrentRow.Cells[Nombre].Value.ToString();
                //  this.txtNumeroCliente = (int)senderASGrid.CurrentRow.Cells[columnIdCliente].Value;
                setNombreNumeroClienteDisplayControl();
                llenarconVerDetalle((int)senderASGrid.CurrentRow.Cells[Numero_Consulta].Value);
                int IdCliente  = (int)senderASGrid.CurrentRow.Cells["IdCliente"].Value;
                llenarAlergiasDetalle(IdCliente);
                llenarImagenesDetalle(IdCliente);
                llenarCitasDetalle(IdCliente);
                llenarPDF(IdCliente);
                manejaMensajeInformativo(sender);
            }
        }        
        private void Expediente_Shown(object sender, EventArgs e)
        {
            // Sea nececio es con begin Onvoke
        }
        /// <summary>
        /// Uso Estetico , de acuerdo al boton que lo invoque define un texto del control txtMensajeInformativo
        /// </summary>
        /// <param name="botonInvocado"></param>
        private void manejaMensajeInformativo(object botonInvocado)
        {
            if (botonInvocado is DataGridView) //En referencia de VerDetalle Grid
            {
                txtMensajeInformativo.Text = "Ver detalle: ";
            }
            if (botonInvocado == btnFiltrarPorCliente)
            {
                txtMensajeInformativo.Text = " Filtro Por Clientes: ";
            }
            if (txtMensajeInformativo.Visible)
            {
                txtMensajeInformativo.Text += Mensajes.DetallesActualizados;
            }
            else
            {
                txtMensajeInformativo.Text += Mensajes.Detalles_Cargados;
                txtMensajeInformativo.Visible = true;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnFiltrarPorCliente_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            _ListaIdConsultas.Clear();  

            using ( ClienteBuscar frmClienteBuscar = new ClienteBuscar() )
            {
                frmClienteBuscar.ShowDialog();
                List<int> listIdsClientes = frmClienteBuscar.getIdClientesDeFiltros();
                var listdgConsultaSource = this.dgConsulta.DataSource as List<VistaConsulta>;

                foreach (int idCliente in listIdsClientes)
                {
                    _ListaIdConsultas.AddRange(listdgConsultaSource.FindAll(Entidad => Entidad.IdCliente == idCliente).Select(Entidad => Entidad.Número_Consulta));                        
                }              
                    llenarAlergiasFiltroClientes(listIdsClientes);               
            }
            foreach (var item in _ListaIdConsultas)
            {                
                llenarConCliente(_ListaIdConsultas);
            }
           
            manejaMensajeInformativo(sender);
            this.UseWaitCursor = false;
        }
        private void chkActivarFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivarFiltro.Checked)
                this.btnFiltrarXNumeroCliente.Enabled = true;
            else
                this.btnFiltrarXNumeroCliente.Enabled = false;
        }
        private void dgConsulta_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.chkActivarFiltro.Checked)
            {
                setNombreNumeroClienteDisplayControl();
            }
        }
        private void btnFiltrarXNumeroCliente_Click(object sender, EventArgs e)
        {
            obtenerIdConsultasdeCliente((int)txtNumeroCliente.Value);
            llenarConCliente(_ListaIdConsultas);
            manejaMensajeInformativo(sender);
        }
        private void getListConsulta_FromGridCOnsulta()
        {
            var lista = dgConsulta.DataSource as List<VistaConsulta>;
            _ListaIdConsultas = (from n in lista
                                 where n.IdCliente == txtNumeroCliente.Value
                                 select n.Número_Consulta).ToList();
        }
        private void llenarConCliente(List<int> ListaIdConsultas)
        {
            ClinicaPro.DB.Consulta.Expediente.controladorExpedienteDB controladorExpediente = new ClinicaPro.DB.Consulta.Expediente.controladorExpedienteDB();
            foreach (int idConsulta in ListaIdConsultas)
            {
                  // Exploracion Fisica         
            controladorExpediente.addVExploracionFisica(idConsulta);                      
            controladorExpediente.addVEstadoVivienda(idConsulta);          
            controladorExpediente.addVToraxPulmones(idConsulta);
            controladorExpediente.addConsultaCraneo(idConsulta);
            controladorExpediente.addConsultaOjo(idConsulta);         
            controladorExpediente.addConsultaOido(idConsulta);           
            controladorExpediente.addConsultaNariz(idConsulta);           
            controladorExpediente.addConsultaBoca(idConsulta);          
            controladorExpediente.addConsultaCuello(idConsulta);            
            controladorExpediente.addConsultaAbdomen(idConsulta);
            controladorExpediente.addConsultaAparatoDigestivo(idConsulta);            
            controladorExpediente.addConsultaCoordinacionMarcha(idConsulta);           
            controladorExpediente.addAntecedenteGinecoObstretico(idConsulta);           
            //  Sentidos
            controladorExpediente.addEstadoEmocional(idConsulta);
            controladorExpediente.addSensibilidad(idConsulta);
            controladorExpediente.addConsultaParesCraneales(idConsulta);
            controladorExpediente.addReflejo(idConsulta);
            controladorExpediente.addVServicios(idConsulta);
             //Antecedentes              
            controladorExpediente.addVAntecedentePatologico(idConsulta);
            controladorExpediente.addVAntecedenteHereditario(idConsulta);
            controladorExpediente.addVDrogas(idConsulta);
            controladorExpediente.addVVacunas(idConsulta);
            controladorExpediente.addVAlcohol(idConsulta);
            controladorExpediente.addVTabaco(idConsulta);     
            }  
            this.dgExFisica_General.DataSource = controladorExpediente.get_ListExploracionFisica();
            this.dgEstadoVivienda.DataSource = controladorExpediente.get_ListaEstadoVivienda();          
            this.dgTorax.DataSource = controladorExpediente.get_ListaVistaToraxPulmones();    
            this.dgCraneo.DataSource = controladorExpediente.get_ListaConsultaCraneo();            
            this.dgOjos.DataSource=controladorExpediente.get_ListaConsultaOjo();            
	        this.dgOidos.DataSource = controladorExpediente.get_ListaConsultaOido();
	        this.dgNariz.DataSource = controladorExpediente.get_ListaConsultaNariz();
	        this.dgBoca.DataSource = controladorExpediente.get_ListaConsultaBoca();
	        this.dgCuello.DataSource = controladorExpediente.get_ListaConsultaCuello();
	        this.dgAbdomen.DataSource = controladorExpediente.get_ListaConsultaAbdomen();
	        this.dgApaDigestivo.DataSource= controladorExpediente.get_ListaConsultaAparatoDigestivo();
	        this.dgCoordinacion.DataSource = controladorExpediente.get_ListaConsultaCoodinacionMarcha();
		    this.dgGinecoObstreticos.DataSource = controladorExpediente.get_ListaAntecedenteGinecoObstreticos();            		 		 
		 // Sentidos		 
           this.dgEstadoEmocional.DataSource = controladorExpediente.get_ListaEstadoEmocional();
           this.dgSensibilidad.DataSource = controladorExpediente.get_ListaSensibilidad();
	       this.dgParesCraneales.DataSource = controladorExpediente.get_ListaParesCraneales();
	       this.dgReflejos.DataSource = controladorExpediente.get_ListaReflejo();		
		   this.dgServicios.DataSource = controladorExpediente.get_ListaVServicios();
		   //Antecedentes		       
		  dgHereditario.DataSource = controladorExpediente.get_ListaVAntecedenteHereditario();
		  dgAntePatologicos.DataSource = controladorExpediente.get_ListaVAntecedentePatologico();
          this.dgDroga.DataSource= controladorExpediente.get_ListaVDrogas();
	      this.dgVacunas.DataSource= controladorExpediente.get_ListaVVacunas();
		  this.dgAlchol.DataSource = controladorExpediente.get_ListaVAlcohol();
		  dgTabaco.DataSource = controladorExpediente.get_ListaVTabaco();
         /**/ //  ClinicaPro.DB.Consulta.ConsultaGaslowDB.ListaPorConsulta(idConsulta, dgGlasgow);

          HeadertextNumeroConsulta(); // Estético
        }
        /// <summary>
        /// Cambia el nombre del encabezado de IdConsulta a Número Consulta
        /// </summary>
        private void  HeadertextNumeroConsulta() //Estetico
        {
            // No estan Todos los, algunos vienen de View de la BD

            List<DataGridView> dataGrids = new List<DataGridView>();
            dataGrids.Add(dgCraneo);
            dataGrids.Add(dgOjos);
            dataGrids.Add(dgOidos);
            dataGrids.Add(dgNariz);
            dataGrids.Add(dgBoca);
            dataGrids.Add(dgCuello);
            dataGrids.Add(dgAbdomen);
            dataGrids.Add(dgApaDigestivo);
            dataGrids.Add(dgCoordinacion);
            dataGrids.Add(dgGinecoObstreticos);
            dataGrids.Add(dgEstadoEmocional);
            dataGrids.Add(dgSensibilidad);
            dataGrids.Add(dgParesCraneales);
            dataGrids.Add(dgReflejos);
            foreach (var item in dataGrids)  
            {
                item.Columns["Idconsulta"].HeaderText = "Número_Consulta";
            }
            
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            llenarConsulta_NoFiltro();
        }    
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
          //  bNavigator1.BindingSource.MoveNext();   El solito invoca este meotodo ,  no es necesario
            this.pictureBoxComplementarias.Image = (Image)bNavigatorImagenesComplemntarias.BindingSource.Current;
        }
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            //   bNavigator1.BindingSource.MovePrevious();  El solito invoca este meotodo ,  no es necesario
            this.pictureBoxComplementarias.Image = (Image)bNavigatorImagenesComplemntarias.BindingSource.Current;
        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            //bNavigator1.BindingSource.MoveLast(); El solito invoca este meotodo ,  no es necesario
            this.pictureBoxComplementarias.Image = (Image)bNavigatorImagenesComplemntarias.BindingSource.Current;
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            //bNavigator1.BindingSource.MoveFirst();  El solito invoca este meotodo ,  no es necesario
            this.pictureBoxComplementarias.Image = (Image)bNavigatorImagenesComplemntarias.BindingSource.Current;
        }
        private void dgElectros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgElectros.CurrentCell is DataGridViewButtonCell)
            {
                try
                {
                    Byte[] pdf = (Byte[])this.dgElectros.Rows[e.RowIndex].Cells["ElectroResultado"].Value;
                    this.saveFileElectro.FileName ="Electro "+idCliente+" "+this.txtNombre.Text;
                    ClinicaPro.BL.manejaPDFs.BitArray(this.saveFileElectro, pdf);
                }
                    catch(InvalidOperationException inv)
                {
                    MessageBox.Show(inv.InnerException.InnerException.ToString());  
                }
                catch (Exception)
                {
                                        
                }                
            }

        }                               
    }
}
