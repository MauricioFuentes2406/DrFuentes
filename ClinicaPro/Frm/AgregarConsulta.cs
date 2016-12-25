using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///librerias añadidas
using ClinicaPro.Entities;
using ClinicaPro.DB;
using ClinicaPro.General.Enumerados;
using ClinicaPro.General.Constantes;
using ClinicaPro.BL;
using System.Speech.Recognition;
using System.Transactions;

namespace Frm
{
    /// <summary>
    /// Regiones dividas por pestañas
    /// </summary>

    public partial class AgregarConsulta : Form
    {

        #region Atributos
        public int idCliente { get; set; }
        public String NombreCliente { get; set; }  // Para Nombre Completo del CLiente - uso estético
        public int idConsulta { get; set; }
        /// <summary>
        /// <value>_isLLenadoRapido</value>
        ///  Indica q se va llenar con datos predefinidos
        ///  Para tabla consulta y servicios
        /// </summary>
        private bool _isLLenadoRapido;

        #endregion
        public AgregarConsulta(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.idConsulta = -1;
        }
        public AgregarConsulta(int idCliente, String NombreCompleto)
        {
            InitializeComponent();
            this.NombreCliente = NombreCompleto;   //Para que ocupo esta Propiedad ??
            this.idCliente = idCliente;
            this.idConsulta = -1;
        }
        /// <summary>
        /// Usar este para Modificar
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="idConsulta"></param>
        /// <param name="NombreCompleto"></param>
        public AgregarConsulta(int idCliente,int idConsulta, String NombreCompleto)
        {
            InitializeComponent();
            this.NombreCliente = NombreCompleto;   //Para que ocupo esta Propiedad ??
            this.idCliente = idCliente;
            this.idConsulta = idConsulta;
        }
        private void AgregarConsulta_Load(object sender, EventArgs e)
        {
            if (isAlgunClienteAsignado())
            {
              
                this.lblNumero.Text = this.idCliente.ToString();
                this.lblNombreCLiente.Text = this.NombreCliente;
                _isLLenadoRapido = false;

                PonerFecha();
                llenaComboEscalaTiempoConsulta();
                llenar_listaOriginalAlergia();
                llenaComboEstadoVivienda();
                cbPorDefectoAbdomen();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarConsulta())
            {
                return;
            }
            else
            {
                if (idConsulta == -1 && _isLLenadoRapido == false)  // -1 Bandera indica q  es agregar
                {
                    GuardarTodos(ClinicaPro.General.accion.Agregar);
                }
                else
                    if (idConsulta == -1 && _isLLenadoRapido)
                    {
                        GuardarRapido(ClinicaPro.General.accion.Agregar);
                    }
                    else
                    {
                        GuardarTodos(ClinicaPro.General.accion.Modificar);
                    }

                MessageBox.Show(Mensajes.Agregar_Modificar,
                                        "Agregar Consulta",
                                          MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Information);
            }
        }
        private void btnCalcularCosto_Click(object sender, EventArgs e)  // Podria Calcular Costo x Invetario ahorita no
        {
            txtCostoConsulta.Value = CalcularCostoPorServicios();
        }

        #region Metodos
        /// <summary>
        /// Chekea si han añadido servios al gridDeServicios 
        /// </summary>
        /// <returns>true si vacio, false no hay nada </returns>
        private Boolean isDgServiosEmpty()
        {
            if (dgServicios.DataSource == null) return true;
            else return false;
        }
        private void LimpiarradioButtons()
        {
            if (gbGaslowEscala.Enabled)
            {
                Rb_Gaslow_AO_Espontanea.Checked=true;
                Rb_Gaslow_RV_Orientado.Checked = true;
                Rb_Gaslow_RM_Obedece.Checked = true;
            }
        }
        private void LimpiarcbPorDefectoTodos()
        {
            if (gbAbdomen.Enabled)
            {
                cb_Abdomen_Bazo.SelectedIndex = 0;
                cb_Abdomen_Recto.SelectedIndex = 0;
                cb_Abdomen_Rinon.SelectedIndex = 0;
                cb_Abdomen_TamanoOrganos.SelectedIndex = 0;
            }
            if (gbAntecedentePatologicos.Enabled)
            {
                cb_Ante_Pato_Bronquitis.SelectedIndex = 0;
                cb_Ante_Pato_FiebreReumatica.SelectedIndex = 0;
                cb_Ante_Pato_Paludismo.SelectedIndex = 0;
                cb_Ante_Pato_Paroditis.SelectedIndex = 0;
                cb_Ante_Pato_Rubeola.SelectedIndex = 0;
                cb_Ante_Pato_Sarampion.SelectedIndex = 0;
                cb_Ante_Pato_Varicela.SelectedIndex = 0;
            }
            cb_Consulta_EscalaTiempo.SelectedIndex = 0;
            cb_Drogas.SelectedIndex = 0;
            cb_Ex_Color.SelectedIndex = 0;
            cb_Ex_ManosUnas.SelectedIndex = 0;
            if (gbHereditario.Enabled)
            {
                cb_Here_AfecTiroide.SelectedIndex = 0;
                cb_Here_Asma.SelectedIndex = 0;
                cb_Here_AVC.SelectedIndex = 0;
                cb_Here_Cancer.SelectedIndex = -0;
                cb_Here_Cardiopatia.SelectedIndex = 0;
                cb_Here_DM.SelectedIndex = 0;
                cb_Here_EnferPulmunar.SelectedIndex = 0;
                cb_Here_Hepato.SelectedIndex = 0;
                cb_Here_HTA.SelectedIndex = 0;
                cb_Here_Neuropatia.SelectedIndex = 0;
            }
            if (gbAntecedentePatologicos.Enabled)
            {
                cb_NoPato_AlcoholEscala.SelectedIndex = 0;
                cb_NoPato_BebePromedio.SelectedIndex = 0;
                cb_NoPato_DrogaEscala.SelectedIndex = 0;
                cb_NoPato_TabaquismoEscala.SelectedIndex = 0;
                cb_NoPato_VacunaEscala.SelectedIndex = 0;
            }
            cb_Reflejo_ValoracionGeneral.SelectedIndex = 0;
            if (gbTorax.Enabled)
            {
                cb_Torax_Ascultacion.SelectedIndex = 0;
                cb_Torax_Expa.SelectedIndex = 0;
                cb_Torax_ResDiafraAbdo.SelectedIndex = 0;
                cb_Torax_RuidoAgregado.SelectedIndex = 0;
            }
            cb_Vacunas.SelectedIndex = 0;
            cb_ArteriaCarotida.SelectedIndex = 0;
            cbEspecificacionAlergia.SelectedIndex = 0;
            cbGanglioLinfatico.SelectedIndex = 0;
            cbMaterialParedes.SelectedIndex = 0;
            cbMaterialPiso.SelectedIndex = 0;
            cbServicios.SelectedIndex = 0;
            cbTipoAlergia.SelectedIndex = 0;
            cbVomito.SelectedIndex = 0;
        }
        private void LimpiarTextTodos()
        {
            if (txt_Ante_Pato_Detalle.Enabled)
            {
                txt_Ante_Pato_Detalle.Text = String.Empty;
            }
            if (txt_EvivendaDetalle.Enabled)
            {
                txt_EvivendaDetalle.Text = String.Empty;
            }
            if (txt_HereditarioDetalle.Enabled)
            {
                txt_HereditarioDetalle.Text = String.Empty;
            }
            if (txt_ObsCoordinacion.Enabled)
            {
                txt_ObsCoordinacion.Text = String.Empty;
            }
            txtAntecedenteQuirurgico.Text = String.Empty;
            if (gbDatosGineco.Enabled)
            {
                txtAbortos.Value = 0;
                txtCesareas.Value = 0;
                txtGestaciones.Value = 0;
                txtPartos.Value = 0;
            }
            if (txtAparatoDigestivoDetalle.Enabled) { txtAparatoDigestivoDetalle.Text = String.Empty; }
            if (txtAuxilirAlergia.Enabled) { txtAuxilirAlergia.Text = String.Empty; }
            txtCostoConsulta.Value = 0;
            txtDescuentoPorcentaje.Value = 0;
            txtDiagnostico.Text = String.Empty;
            if (txtEmocional_Otro.Enabled) { txtEmocional_Otro.Text = String.Empty; }
            if (txtExploracionInfoAdicional.Enabled) { txtExploracionInfoAdicional.Text = "Info Adicional"; }
            txtFrecuenciaRespiratoria.Value = 0;
            txtFrencuenciaCardiaca.Value = 0;
            if (txtMareos.Enabled) { txtMareos.Value = 0; }
            txtMotivoConsulta.Text = String.Empty;
            if (gbAnteceDentesNoPatologicos.Enabled)
            {
                txtNoPato_NumTiempo_Alchol.Value = 1;
                txtNoPato_NumTiempo_Droga.Value = 1;
                txtNoPato_NumTiempo_Tabaquismo.Value = 1;
                txtNoPato_NumTiempo_Vacuna.Value = 1;
            }
            txtNumeroBaños.Value = 0;
            txtPA_Diastolica.Value = 0;
            txtPA_Sistolica.Value = 0;
            txtPadecimientoActual.Text = String.Empty;
            if (txtParCranealDetalle.Enabled) { txtParCranealDetalle.Text = String.Empty; }
            if (txtPerdidaAgudeza.Enabled) { txtPerdidaAgudeza.ResetText(); }
            txtPeso.Value = 0;
            txtPlanTratamiento.ResetText();
            if (txtPresionVenosaCuello.Enabled) { txtPresionVenosaCuello.Value = 0; }
            txtPrimerIndicio.ResetText();
            txtQSucedeAcontinuacion.ResetText();
            if (txtReflejoObservacion.Enabled) { txtReflejoObservacion.ResetText(); }
            if (txtSensibilidadDetalle.Enabled) { txtSensibilidadDetalle.ResetText(); }
            txtServiciosBasicos.Text = "Todos";
            txtTalla.Value = 0;
            txtTemperatura.Value = 0;
        }
        private void LimpiarChekBoxTodos()
        {
            LimpiadorAutomaticoChekBox(gbEstadoVivienda);
            if (gbReflejos.Enabled) { LimpiadorAutomaticoChekBox(gbReflejos); }
            if (gbCuello.Enabled) { LimpiadorAutomaticoChekBox(gbCuello); }
            if (gbOjos.Enabled) { LimpiadorAutomaticoChekBox(gbOjos); }
            if (gbAbdomen.Enabled) { chk_AbdomenAscititis.Checked = false; }
            if (gbCraneo.Enabled) { LimpiadorAutomaticoChekBox(gbCraneo); }
            if (gbAparatoDigestivo.Enabled) { LimpiadorAutomaticoChekBox(gbAparatoDigestivo); }
            if (gbBoca.Enabled) { LimpiadorAutomaticoChekBox(gbBoca); }
            if (gbTorax.Enabled) { chk_Torax_SonoridadPulmonar.Checked = false; }
            if (gbNariz.Enabled) { LimpiadorAutomaticoChekBox(gbNariz); }
            if (gbOidos.Enabled) { LimpiadorAutomaticoChekBox(gbOidos); }
            if (gbSensibilidad.Enabled) { LimpiadorAutomaticoChekBox(gbSensibilidad); }
            if (gbParesCraneales.Enabled) { LimpiadorAutomaticoChekBox(gbParesCraneales); }
            if (gbEstadoEmocional.Enabled) { LimpiadorAutomaticoChekBox(gbEstadoEmocional); }

        }
        /// <summary>
        /// Desmarca(Cheked=false) todos ChekBox contenidos en un GroupBox
        /// </summary>
        /// <param name="groupBoxConsulta">Elija Los GroupBox Que contengan ChekBox</param>
        private void LimpiadorAutomaticoChekBox(GroupBox groupBoxConsulta)
        {
            foreach (Control control in groupBoxConsulta.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox chk = (CheckBox)control;
                    chk.Checked = false;
                }
            }
        }
        private void LimpiarGrids()
        { 
          if (gbAnteceDentesNoPatologicos.Enabled)
          {
              if (listaDataGridDrogas != null) listaDataGridDrogas.Clear();
              if (listaGridvacunas != null)listaGridvacunas.Clear();                            
          }
          if (listaGridServicios != null) listaGridServicios.Clear();
          if (listaDataGridAlergia != null) { listaDataGridAlergia.Clear(); }
        }
        private void Limpiar()
        {
            this.idConsulta = -1;
            LimpiarGrids();
            LimpiarradioButtons();
            LimpiarcbPorDefectoTodos();  //Hay que arreglarle los cb, Definir los enabled antes 
            LimpiarTextTodos();
            LimpiarChekBoxTodos();
        }
        private int CalcularCostoPorServicios()
        {
            if (!isDgServiosEmpty())
            {
                int total = 0;
                foreach (var item in listaServicio_ParaAgregar())
                {
                    total += item.Precio;
                }
                return total;
            }
            else return 0;
        }
        private void PonerFecha()
        {
            txtFechaConsulta.Text = ClinicaPro.DB.FechaHoraServidorDB.ActualFecha();
        }
        private void medidasNormal()
        {
            this.txtTalla.Value = (decimal)1.70;
            this.txtTemperatura.Value = (decimal)37.0;
            this.txtPeso.Value = (decimal)70.00;
            this.txtPA_Sistolica.Value = (decimal)100;
            this.txtPA_Diastolica.Value = (decimal)60;
            this.txtFrecuenciaRespiratoria.Value = (decimal)14;
            this.txtFrencuenciaCardiaca.Value = (decimal)60;
        }
        private Boolean ValidarConsulta()
        {
            ///<summary>
            ///  Valida los campos que no esten vacios ni incosistentes , los pone Color.AliceBlue
            ///  <value>String Detalles, usado para crear una cadena al final con detalles  </value>
            ///  <value>boolean hallazgo, usado como bandera, si encontro algo = true </value>
            ///  <return>hallazgo</return>
            /// </summary>          

            String detalles = String.Empty;
            Boolean hallazgo = false;

            if (String.IsNullOrWhiteSpace(txtDiagnostico.Text))
            {
                detalles += "Campo Diagnostico" + Mensajes.Campo_Requerido;
                this.txtDiagnostico.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (String.IsNullOrWhiteSpace(txtMotivoConsulta.Text))
            {
                detalles += "Campo Plan de Tratamiento" + Mensajes.Campo_Requerido;
                this.txtMotivoConsulta.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (String.IsNullOrWhiteSpace(txtPlanTratamiento.Text))
            {
                detalles += "Campo Plan de Tratamiento" + Mensajes.Campo_Requerido;
                this.txtPlanTratamiento.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (isDgServiosEmpty())
            {
                detalles += "No has añadido Servicios" + Mensajes.Campo_Requerido;
                this.dgServicios.BackgroundColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
                dgServicios.Focus();
            }
            if (String.IsNullOrWhiteSpace(txtPadecimientoActual.Text))
            {
                detalles += "Campo Padecimiento Actual" + Mensajes.Campo_Requerido;
                this.txtPadecimientoActual.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtPeso.Value == 0)
            {
                detalles += "Campo Peso " + Mensajes.Numero_Mayor_Cero;
                this.txtPeso.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (txtTalla.Value == 0)
            {
                detalles += "Campo Talla " + Mensajes.Numero_Mayor_Cero;
                this.txtTalla.BackColor = System.Drawing.Color.AliceBlue;
                hallazgo = true;
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lblCampoRequerido.Visible = true;
            }
            return hallazgo;
        }
        /// <summary>
        ///  Valida que halla un cliente asignado a la consulta, debe ir en el Load para evitar perdidas de datos posteriormente
        /// </summary>
        /// <returns>True si hay Cliente, false si no</returns>
        private Boolean isAlgunClienteAsignado()
        {
            if (idCliente < 1)
            {
                MessageBox.Show(Mensajes.No_hay_Cliente, "No hay Cliente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// Valida que en los  Servicios Añadidos yse pueda aplicar Descuentos
        /// </summary>
        /// <returns>true si hay error, false todo bien </returns>
        private Boolean ValidarDescuento()  // No descuento de ServiciosNoEditables
        {
            String detalles = String.Empty;
            List<GeneralTipoServicio> listaLocal = listaServicio_ParaAgregar();
            if (isDgServiosEmpty())
            {
                MessageBox.Show(Mensajes.No_hay_Servicios, "Para calcular Descuento", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }
        private int AplicarDescuentoMontoTotal()
        {
            bool hallazgo = false;
            String detalles = String.Empty;
            decimal local = 0;

            List<GeneralTipoServicio> listaLocal = listaServicio_ParaAgregar();
            foreach (GeneralTipoServicio servicio in listaLocal)
            {
                if (servicio.IsPrecioEditable == false)
                {
                    detalles += "\n" + servicio.Nombre + " " + servicio.Precio + " " + Mensajes.Descuento_No_Aplicable;
                    hallazgo = true;
                }
            }
            if (hallazgo)
            {
                MessageBox.Show(detalles, "Para calcular Descuento", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            local = listaLocal.Where(EntidadLocal => EntidadLocal.IsPrecioEditable == true).Sum(EntidadLocal => EntidadLocal.Precio);
            if (local == 0)
            {
                return CalcularCostoPorServicios();
            }
            decimal MontoDescuento = local * ((decimal)txtDescuentoPorcentaje.Value / 100);
            return (int)txtCostoConsulta.Value - (int)MontoDescuento;
        }
        /// <summary>
        /// Llenado Rapido
        /// Cuando solo se quiere añadir un servicio
        /// </summary>
        private void LlenadoRapidoDatos()
        {
            medidasNormal();
            txtMotivoConsulta.Text = Mensajes.LLenadoRapido;
            txtPadecimientoActual.Text = Mensajes.LLenadoRapido;
            txtQSucedeAcontinuacion.Text = Mensajes.LLenadoRapido;
            txtDiagnostico.Text = Mensajes.LLenadoRapido;
            txtPlanTratamiento.Text = Mensajes.LLenadoRapido;
            txtPrimerIndicio.Text = Mensajes.LLenadoRapido;
        //    listaGridServicios.Add(new ClinicaPro.DB.Consulta.GeneralTipoServicioDB.ListarPorIdservicio());

        }
        /// <summary>
        /// Guarda en la Base Datos todos los datos de los controles
        /// </summary>
        /// <param name="isModificar">false para agregar, true modificar</param>
        private void GuardarTodos(bool isModificar)
        {
            // Alergias es con CLiente, tiene su propio Metodo
            // Servicio Se Añade dentro de ConsultaDB             

            using (TransactionScope scope = new TransactionScope())  // scope Hace un RollBack si ocurre un error
            {
                ClinicaPro.DB.Consulta.ConsultaDB consultaDB = new ClinicaPro.DB.Consulta.ConsultaDB();
                Consulta consulta = Consulta_Controles_A_Clase();

                if (isModificar == ClinicaPro.General.accion.Agregar)
                { 
                    this.idConsulta = consultaDB.Agregar_Modificar(consulta, isModificar); 
                }
                                                    
                if (gbDatosGineco.Enabled)
                {
                    ClinicaPro.DB.Consulta.GinecoObstreticosDB ginecoDB = new ClinicaPro.DB.Consulta.GinecoObstreticosDB();
                    AntecedentesGinecoObstrectico ginecoObstretico = Gineco_Controles_A_Clase();
                    ginecoObstretico.idConsulta = this.idConsulta;
                    ginecoDB.Agregar_Modificar(ginecoObstretico, isModificar);
                }

                ClinicaPro.DB.Consulta.ConsultaExploracionFisicaDB cFisicaDB = new ClinicaPro.DB.Consulta.ConsultaExploracionFisicaDB();
                ConsultaExploracionFisica exploracionFisica = ExploracionFisica_Controles_A_Clase();
                exploracionFisica.IdConsulta = this.idConsulta;
                cFisicaDB.Agregar_Modificar(exploracionFisica, isModificar);

                ClinicaPro.DB.Consulta.ConsultaNarizDB cnariz = new ClinicaPro.DB.Consulta.ConsultaNarizDB();
                ConsultaNariz consultaNariz = ConsultaNariz_Controles_A_Clase();
                consultaNariz.IdConsulta = this.idConsulta;
                cnariz.Agregar_Modificar(consultaNariz, isModificar);

                ClinicaPro.DB.Consulta.ConsultaOidosDB cOidosDB = new ClinicaPro.DB.Consulta.ConsultaOidosDB();
                ConsultaOido consultaOido = ConsultaOido_Controles_A_Clase();
                consultaOido.IdConsulta = this.idConsulta;
                cOidosDB.Agregar_Modificar(consultaOido, isModificar);

                ClinicaPro.DB.Consulta.ConsultaOjosDB cOjosDB = new ClinicaPro.DB.Consulta.ConsultaOjosDB();
                ConsultaOjo consultaOjos = ConsultaOjos_Controles_A_Clase();
                consultaOjos.IdConsulta = this.idConsulta;
                cOjosDB.Agregar_Modificar(consultaOjos, isModificar);

                ClinicaPro.DB.Consulta.ConsultaReflejosDB crefle = new ClinicaPro.DB.Consulta.ConsultaReflejosDB();
                ConsultaReflejo consultaReflejo = ConsultaReflejo_Controles_A_Clase();
                consultaReflejo.IdConsulta = this.idConsulta;
                crefle.Agregar_Modificar(consultaReflejo, isModificar);

                ClinicaPro.DB.Consulta.ConsultaCuelloDB cCuello = new ClinicaPro.DB.Consulta.ConsultaCuelloDB();
                ConsultaCuello consultaCUello = ConsultaCuello_Controles_A_Clase();
                consultaCUello.IdConsulta = this.idConsulta;
                cCuello.Agregar_Modificar(consultaCUello, isModificar);

                ClinicaPro.DB.Consulta.ConsultaEstadoEmocionalDB estadoEmocionalDB = new ClinicaPro.DB.Consulta.ConsultaEstadoEmocionalDB();
                ConsultaEstadoEmocional cEstadoEmocional = ConsultaEstadoEmocional_Controles_A_Clase();
                cEstadoEmocional.IdConsulta = this.idConsulta;
                estadoEmocionalDB.Agregar_Modificar(cEstadoEmocional, isModificar);

                ClinicaPro.DB.Consulta.ConsultaCraneoDB cCraneoDB = new ClinicaPro.DB.Consulta.ConsultaCraneoDB();
                ConsultaCraneo consultaCraneo = ConsultaCraneo_Controles_A_Clase();
                consultaCraneo.IdConsulta = this.idConsulta;
                cCraneoDB.Agregar_Modificar(consultaCraneo, isModificar);

                ClinicaPro.DB.Consulta.ConsultaAparatoDigestivoDB cAparatoDigestivoDB = new ClinicaPro.DB.Consulta.ConsultaAparatoDigestivoDB();
                ConsultaAparatoDigestivo aparatoDigestivo = ConsultaAparatoDigestivo_Controles_A_Clase();
                aparatoDigestivo.IdConsulta = this.idConsulta;
                cAparatoDigestivoDB.Agregar_Modificar(aparatoDigestivo, isModificar);

                ClinicaPro.DB.Consulta.ConsultaBocaDB cBocaDB = new ClinicaPro.DB.Consulta.ConsultaBocaDB();
                ConsultaBoca consultaBoca = ConsultaBoca_Controles_A_Clase();
                consultaBoca.IdConsulta = this.idConsulta;
                cBocaDB.Agregar_Modificar(consultaBoca, isModificar);

                ClinicaPro.DB.Consulta.CoordinacionYMarchaDB coodinacionMarchaDB = new ClinicaPro.DB.Consulta.CoordinacionYMarchaDB();
                CoordinacionyMarcha coordinacionMarcha = CoordinacionyMarcha_Controles_A_Clase();
                coordinacionMarcha.IdConsulta = this.idConsulta;
                coodinacionMarchaDB.Agregar_Modificar(coordinacionMarcha, isModificar);

                ClinicaPro.DB.Consulta.ToraxPulmonesDB toraxPulmonDB = new ClinicaPro.DB.Consulta.ToraxPulmonesDB();
                ConsultaToraxPulmone consultaToraxPulmon = ConsultaTorax_Controles_A_Clase();
                consultaToraxPulmon.IdConsulta = this.idConsulta;
                toraxPulmonDB.Agregar_Modificar(consultaToraxPulmon, isModificar);

                ClinicaPro.DB.Consulta.EstadoViviendaDB estadoViviendaDB = new ClinicaPro.DB.Consulta.EstadoViviendaDB();
                ConsultaEstadoVivienda cEstadoVivienda = ConsultaEstadoViviendaControles_A_Clase();
                cEstadoVivienda.IdConsulta = this.idConsulta;
                estadoViviendaDB.Agregar_Modificar(cEstadoVivienda, isModificar);

                ClinicaPro.DB.Consulta.SensbilidadDB sensibilidadDB = new ClinicaPro.DB.Consulta.SensbilidadDB();
                ConsultaSensibilidad cSensibilidad = ConsultaSensibilidad_Controles_A_Clase();
                cSensibilidad.IdConsulta = this.idConsulta;
                sensibilidadDB.Agregar_Modificar(cSensibilidad, isModificar);

                ClinicaPro.DB.Consulta.ParesCranealesDB paresDB = new ClinicaPro.DB.Consulta.ParesCranealesDB();
                ConsultaParesCraneale cParesCraneales = ParesCranealesControles_A_Clase();
                cParesCraneales.IdConsulta = this.idConsulta;
                paresDB.Agregar_Modificar(cParesCraneales, isModificar);                 

                if (isListaDrogasconDatos() )
                {
                    ClinicaPro.DB.Consulta.AntecedenteDrogaDB antedecedenteDrogaDB = new ClinicaPro.DB.Consulta.AntecedenteDrogaDB();
                    AntecedenteDrogra anteDroga = AntecedenteDroga_Controles_A_Clase();
                    anteDroga.idConsulta = this.idConsulta;
                    antedecedenteDrogaDB.Agregar_Modificar(anteDroga, isModificar);
                }
                else if (ClinicaPro.General.accion.Modificar)
                {
                    ClinicaPro.DB.Consulta.AntecedenteDrogaDB antedecedenteDrogaDB = new ClinicaPro.DB.Consulta.AntecedenteDrogaDB();
                    antedecedenteDrogaDB.EliminarListaDrogas(this.idConsulta);
                }
                if (isListaVacunasconDatos() )
                {
                    ClinicaPro.DB.Consulta.AntecedenteVacunaDB antedecedenteVacunaDB = new ClinicaPro.DB.Consulta.AntecedenteVacunaDB();
                    AntecedenteVacuna entidadAgregar = AntecedenteVacuna_Controles_A_Clase();
                    entidadAgregar.IdConsulta = this.idConsulta;
                    antedecedenteVacunaDB.Agregar_Modificar(entidadAgregar, isModificar);
                }
                else if (ClinicaPro.General.accion.Modificar)
                {
                    ClinicaPro.DB.Consulta.AntecedenteVacunaDB antedecedenteVacunaDB = new ClinicaPro.DB.Consulta.AntecedenteVacunaDB();
                    antedecedenteVacunaDB.EliminarListaVacunas(this.idConsulta);
                }
                if (gbAnteceDentesNoPatologicos != null)
                {
                    ClinicaPro.DB.Consulta.AntecedenteAlcoholDB anteAlcoDB = new ClinicaPro.DB.Consulta.AntecedenteAlcoholDB();
                    AntecedenteAlcohol anteAlco = AntecedenteAlcohol_Controles_A_Clase();
                    anteAlco.IdConsulta = this.idConsulta;
                    anteAlcoDB.Agregar_Modificar(anteAlco, isModificar);

                    ClinicaPro.DB.Consulta.AntecedentePatologicoPersonalDB antePatoPersoDB = new ClinicaPro.DB.Consulta.AntecedentePatologicoPersonalDB();
                    AntecedentePersonalesPatologico antePersoPatologico = AntecedentePatologico_Controles_A_Clase();
                    antePersoPatologico.IdConsulta = this.idConsulta;
                    antePatoPersoDB.Agregar_Modificar(antePersoPatologico, isModificar);

                    ClinicaPro.DB.Consulta.AntecedenteTabacoDB anteTabaDB = new ClinicaPro.DB.Consulta.AntecedenteTabacoDB();
                    AntecedenteTabaco anteTabaco = AntecedenteTabaco_Controles_A_Clase();
                    anteTabaco.IdConsulta = this.idConsulta;
                    anteTabaDB.Agregar_Modificar(anteTabaco, isModificar);

                    ClinicaPro.DB.Consulta.AntecedenteHereditarioDB anHereditarioDB = new ClinicaPro.DB.Consulta.AntecedenteHereditarioDB();
                    AntecedenteHereditario anteHereditario = AntecedenteHereditario_A_Clase();
                    anteHereditario.IdConsulta = this.idConsulta;
                    anHereditarioDB.Agregar_Modificar(anteHereditario, isModificar);

                }
                ClinicaPro.DB.Consulta.ConsultaAbdomenDB cAbdomenDB = new ClinicaPro.DB.Consulta.ConsultaAbdomenDB();
                ConsultaAbdomen cAbdomen = ConsultaAbdomen_A_Clase();
                cAbdomen.IdConsulta = this.idConsulta;
                cAbdomenDB.Agregar_Modificar(cAbdomen, isModificar);

                AlergiasABaseDatos(isModificar);

                scope.Complete(); 
            }
        }
        /// <summary>
        /// Guarda en la Base Datos, únicamente Consulta y Servicios
        /// </summary>
        /// <param name="isModificar"></param>
        private void GuardarRapido(bool isModificar) 
        {
            // Aveces solo se quisiera agregar un servicio
            Consulta consulta;
            ClinicaPro.DB.Consulta.ConsultaDB consultaDB = new ClinicaPro.DB.Consulta.ConsultaDB();
            consulta = Consulta_Controles_A_Clase();
            consultaDB.Agregar_Modificar(consulta, isModificar);
        }
        /// <summary>
        /// Verifica si  hay objetos en la coleccion del ComboBox
        /// </summary>
        /// <param name="cb_Algo"></param>
        /// <returns>true si count mayor a cero </returns>
        private bool isComboVacio( ComboBox cb_Algo)
        {
            if (cb_Algo.Items.Count == 0)
            { return true; }
            else return false;
        }


        #endregion
        #region Eventos
        private void txtDiagnostico_Enter(object sender, EventArgs e) // Cambia Color AuxliarAlergias, func Estetica
        {
            txtAuxilirAlergia.BackColor = Color.OldLace;
        }
        private void txtDiagnostico_Leave(object sender, EventArgs e) // Cambia Color AuxliarAlergias, func Estetica
        {
            txtAuxilirAlergia.BackColor = SystemColors.ControlLightLight;
        }
        private void txtPlanTratamiento_Enter(object sender, EventArgs e)// Cambia Color AuxliarAlergias, func Estetica
        {
            txtAuxilirAlergia.BackColor = Color.LemonChiffon;
        }
        private void txtPlanTratamiento_Leave(object sender, EventArgs e)// Cambia Color AuxliarAlergias, func Estetica
        {
            txtAuxilirAlergia.BackColor = SystemColors.ControlLightLight;
        }
        private void cb_Ex_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Ex_Color.DataSource != null)
            {
                var objeto = (ColorPaciente)cb_Ex_Color.SelectedItem;
                txtExploracionInfoAdicional.Text = "Color piel \n " + objeto.TextoInformativo;
            }
        }
        private void cb_Ex_ManosUnas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Ex_ManosUnas.DataSource != null)
            {
                var objeto = (ExploracionMano)cb_Ex_ManosUnas.SelectedItem;
                txtExploracionInfoAdicional.Text = "Exploracion mano \n " + objeto.TextoInformativo;
            }
        }
        private void btnSanoMedidas_Click(object sender, EventArgs e)
        {
            medidasNormal();
        }
        private void btnLLenaodoRapido_Click(object sender, EventArgs e)
        {
            if (_isLLenadoRapido == false)
            {
                _isLLenadoRapido = true;
                lblLlebadoRapido.Visible = true;
                LlenadoRapidoDatos();
            }
            else
            {
                _isLLenadoRapido = false;
                lblLlebadoRapido.Visible = false;
            }
        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            new Frm.frmBusquedas().ShowDialog();
        }
        private void chk_AplicarDescuento_CheckedChanged(object sender, EventArgs e) // Check  
        {
            if (chk_AplicarDescuento.Checked == false)
            {
                this.chk_AplicarDescuento.BackgroundImage = null;
                this.chk_AplicarDescuento.BackgroundImage = global::Frm.Properties.Resources.switch_OFF;
                txtCostoConsulta.Value = CalcularCostoPorServicios();
            }
            if (chk_AplicarDescuento.Checked)
            {
                if (!ValidarDescuento())
                {
                    txtCostoConsulta.Value = AplicarDescuentoMontoTotal();
                    this.chk_AplicarDescuento.BackgroundImage = null;
                    this.chk_AplicarDescuento.BackgroundImage = global::Frm.Properties.Resources.switch_ON;
                }
            }
        }
        #endregion
        #region Consulta
        public Consulta Consulta_Controles_A_Clase()
        {
            Consulta consulta = new Consulta();
            consulta.IdCliente = this.idCliente;
            consulta.NumeroTiempo = (byte)txt_Consulta_NumTiempo.Value;
            consulta.EscalaTiempo = (EscalaTiempo)cb_Consulta_EscalaTiempo.SelectedItem;
            consulta.PadecimientoActual = txtPadecimientoActual.Text;
            consulta.PlanTratamiento = txtPlanTratamiento.Text;
            consulta.PrimerIndicio = txtPrimerIndicio.Text;
            consulta.QSucedeAcontinuacion = txtQSucedeAcontinuacion.Text;
            consulta.GeneralTipoServicios = listaServicio_ParaAgregar();
            consulta.CobroFinalDeConsulta = (int)txtCostoConsulta.Value;
            consulta.Descuento = (int)txtDescuentoPorcentaje.Value;
            consulta.DiagnosticoEstado = chk_ConsultaEstado.Checked;
            consulta.Diagnostico = txtDiagnostico.Text;
            consulta.MotivoConsulta = txtMotivoConsulta.Text;
            consulta.FechaConsulta = DateTime.Parse(txtFechaConsulta.Text);
            consulta.AntecenteQuirurgico = txtAntecedenteQuirurgico.Text.Trim();

            if (gbGaslowEscala.Enabled)
            {
                GlasgowResultado gl = new GlasgowResultado();
                ClinicaPro.DB.Consulta.ConsultaGaslowDB gaslow = new ClinicaPro.DB.Consulta.ConsultaGaslowDB();
                consulta.GlasgowResultado = gaslow.getGlasgow(getGaslowid());
            }
            return consulta;
        }
        #endregion
        #region Alergias

        /// <summary>
        /// Hay 2 listas
        /// Una original que se trae desde la Base de Datos  y las 
        /// las otras 2 se usan para filtrar esa misma lista
        /// El dataGrid se llena en Base el ValueMember de comboBox cbEspecificacion
        /// <para>listaOriginalAlergia  , se trae desde Base Datos, se usa para filtar   </para>
        /// <para>listaDataGridAlergia ,En el grid se toman los id de alergias seleccionadas + idConsulta 
        /// se guardan en la tabla  clienteAlergias</para>
        /// </summary>
        List<TipoAlergia> listaOriginalAlergia;
        BindingList<TipoAlergia> listaDataGridAlergia;
        private void btnNuevaAlergia_Click(object sender, EventArgs e)
        {
            using (AgregarAlergia frmAgregarAlergia = new AgregarAlergia())
            {
                frmAgregarAlergia.ShowDialog();
            }
            llenar_listaOriginalAlergia();      // Actualiza los comboBox de Alergias
        }
        private void llenar_listaOriginalAlergia()
        {
            ClinicaPro.DB.Consulta.TipoAlergiaDB tipoAlergiaDB = new ClinicaPro.DB.Consulta.TipoAlergiaDB();
            this.listaOriginalAlergia = tipoAlergiaDB.Listar();
            this.cbTipoAlergia.DisplayMember = "Key";  //Al usar GroupBy se cambian el nombre de la variable 
            this.cbTipoAlergia.DataSource = listaOriginalAlergia.GroupBy(x => x.Tipo_Alergia).ToList();
        }
        private void cbTipoAlergia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTipoAlergia.DataSource != null)
            {
                this.cbEspecificacionAlergia.DataSource = listaOriginalAlergia.Where(x => x.Tipo_Alergia == cbTipoAlergia.Text).ToList();
                cbEspecificacionAlergia.DisplayMember = "Especificacion";
                cbEspecificacionAlergia.ValueMember = "idAlergia";
            }
        }
        /// <summary> Cada vez que se elimina un regitro del dataGrid se actualiza la lista, igualmente cuando se agrega
        ///  o modifica (*Es bueno que el GRID se mantega con la propiedad onlyRead) pero solo se toma el id de cada fila
        /// <seealso cref="https://msdn.microsoft.com/en-us/library/ms132679(v=vs.110).aspx"/>
        /// </summary>
        private void btnAlergiaGrid_Click(object sender, EventArgs e)  // Evento Click para añadir alergias al Grid
        {

            if (listaDataGridAlergia == null)
            {
                listaDataGridAlergia = new BindingList<TipoAlergia>();
                this.dgAlergias.DataSource = listaDataGridAlergia;
                this.dgAlergias.Columns["idAlergia"].Visible = false;
            }
            listaDataGridAlergia.Add((TipoAlergia)cbEspecificacionAlergia.SelectedItem);
        }
        private void dgAlergias_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            txtAuxilirAlergia.Text = String.Empty;
            Llena_txtAlergia();
        }
        private void dgAlergias_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtAuxilirAlergia.Text = String.Empty;
            Llena_txtAlergia();
        }
        private void Llena_txtAlergia()
        {
            foreach (TipoAlergia tipo in listaDataGridAlergia)
            {
                this.txtAuxilirAlergia.Text += tipo.Tipo_Alergia + ":\t " + tipo.Especificacion + "\n";
            }
        }
        /// <summary>
        ///  Retorna la lista con las Alergias Añadidas por el usuario
        /// </summary>
        /// <returns></returns>
        private BindingList<TipoAlergia> listaAlergia_ParaAgregar() 
        {
            return listaDataGridAlergia;
        }
        /// <summary>
        /// Guarda en Base DAtos las Alergias del Cliente, recordar que se liga a cliente y no consulta
        /// </summary>
        private void AlergiasABaseDatos(bool isModificar)
        {
            if (dgAlergias.DataSource != null)
            {                
                ClinicaPro.DB.Cliente.ClienteAlergiasDB.Agregar_Modificar(listaAlergia_ParaAgregar(), idCliente, isModificar);
            }
        }

        #endregion       
        #region Servicios
        List<GeneralTipoServicio> listaOriginalServicio;
        BindingList<GeneralTipoServicio> listaGridServicios;
        private void llenar_listaOriginalServicio()
        {
            ClinicaPro.DB.Consulta.GeneralTipoServicioDB generalTipoServicioDB = new ClinicaPro.DB.Consulta.GeneralTipoServicioDB();
            this.listaOriginalServicio = generalTipoServicioDB.Listar();
        }
        private void LlenaComboServicio()
        {
            llenar_listaOriginalServicio();
            ClinicaPro.BL.ComboBoxBL<GeneralTipoServicio> configuraCB = new ComboBoxBL<GeneralTipoServicio>();
            configuraCB.fuenteBaseDatos(cbServicios, listaOriginalServicio, comboNombreIDs.GeneralServicio);
        }
        private void btnServicios_Click(object sender, EventArgs e)
        {
            if (listaGridServicios == null)
            {
                listaGridServicios = new BindingList<GeneralTipoServicio>();
                this.dgServicios.DataSource = listaGridServicios;
                ocultarColumnas_gdServicios();
            }
            listaGridServicios.Add((GeneralTipoServicio)cbServicios.SelectedItem);
        }
        private List<GeneralTipoServicio> listaServicio_ParaAgregar() //Cuando ya se va guardar la lista Servicios a la Consulta
        {
            if (listaGridServicios != null)
            { return listaGridServicios.ToList(); }
            else { return null; }
        }
        private void btnAuxServici_Click(object sender, EventArgs e)
        {
            listaServicio_ParaAgregar();
        }
        private void ocultarColumnas_gdServicios()
        {
            this.dgServicios.Columns[comboNombreIDs.GeneralServicio].Visible = false;
            this.dgServicios.Columns["isPrecioEditable"].Visible = false;
        }
        #endregion
        #region GinecoObstreticos
        /// <summary> 
        /// Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>AntecedentesGinecoObstrectico</returns>
        private AntecedentesGinecoObstrectico Gineco_Controles_A_Clase()  // Recordar No carga el id
        {
            AntecedentesGinecoObstrectico anteGineco = new AntecedentesGinecoObstrectico();

            anteGineco.Abortos = (byte)this.txtAbortos.Value;
            anteGineco.Cecareas = (byte)this.txtCesareas.Value;
            anteGineco.FUM = this.dtFUM.Value;
            anteGineco.FUPAC = this.dtFUP.Value;
            anteGineco.Gestaciones = (byte)this.txtGestaciones.Value;
            anteGineco.Partos = (byte)this.txtPartos.Value;
            return anteGineco;
        }

        private void btnAuxiliar_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.GinecoObstreticosDB ginecoDB = new ClinicaPro.DB.Consulta.GinecoObstreticosDB();
            AntecedentesGinecoObstrectico entidadAgregar = Gineco_Controles_A_Clase();
            entidadAgregar.idConsulta = 7;
            ginecoDB.Agregar_Modificar(entidadAgregar, false);
            
        }
        #endregion
        #region Exploracion Fisica
        /// <summary> 
        /// Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>ConsultaExploracionFisica</returns>
        private ConsultaExploracionFisica ExploracionFisica_Controles_A_Clase() // No añade el Id
        {
            ConsultaExploracionFisica consultaExFisica = new ConsultaExploracionFisica();
            consultaExFisica.idColorPaciente = (int)cb_Ex_Color.SelectedValue;
            consultaExFisica.idExploracionManos = (int)cb_Ex_ManosUnas.SelectedValue;
            consultaExFisica.FrecuenciaCardiaca = (byte)txtFrencuenciaCardiaca.Value;
            consultaExFisica.FrecuenciaRespiratoria = (byte)txtFrecuenciaRespiratoria.Value;
            consultaExFisica.Peso = txtPeso.Value;
            consultaExFisica.PresionArterialDiastolico = (byte)txtPA_Diastolica.Value;
            consultaExFisica.PresionArterialSistolico = (byte)txtPA_Sistolica.Value;
            consultaExFisica.Talla = txtTalla.Value;
            consultaExFisica.Temperatura = txtTemperatura.Value;
            return consultaExFisica;
        }

        private void LlenacomboMano()
        {
            if (cb_Ex_ManosUnas.Items.Count == 0)
            {
                ClinicaPro.DB.Consulta.ExploracionManoDB exploraManoDB = new ClinicaPro.DB.Consulta.ExploracionManoDB();
                List<ExploracionMano> lista = exploraManoDB.Listar();

                ClinicaPro.BL.ComboBoxBL<ExploracionMano> configuraCB = new ComboBoxBL<ExploracionMano>();
                configuraCB.fuenteBaseDatos(cb_Ex_ManosUnas, lista, comboNombreIDs.exploracionMano);
            }
        }
        private void LlenacomboColor()
        {
            if (cb_Ex_Color.Items.Count == 0)
            {
                ClinicaPro.DB.Consulta.ColorPacienteDB exploracionColorDB = new ClinicaPro.DB.Consulta.ColorPacienteDB();
                List<ColorPaciente> lista = exploracionColorDB.Listar();
            
            ClinicaPro.BL.ComboBoxBL<ColorPaciente> configuraCB = new ComboBoxBL<ColorPaciente>();
            configuraCB.fuenteBaseDatos(cb_Ex_Color, lista, comboNombreIDs.colorPaciente);
            }
        }

        private void btnAuxExploraF_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaExploracionFisicaDB cFisicaDB = new ClinicaPro.DB.Consulta.ConsultaExploracionFisicaDB();
            ConsultaExploracionFisica entidadAgregar = ExploracionFisica_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cFisicaDB.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region Nariz
        private void btn_gbNariz_Click(object sender, EventArgs e)
        {
            this.gbNariz.Enabled = true;
            this.gbOidos.Enabled = true;
        }
        // <summary> 
        /// Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>ConsultaExploracionFisica</returns>
        private ConsultaNariz ConsultaNariz_Controles_A_Clase() // No añade el Id
        {
            ConsultaNariz nariz = new ConsultaNariz();
            nariz.Epitaxis = this.chk_Nariz_Epitaxis.Checked;
            nariz.ResfrioFrecuente = this.chk_Nariz_ResfrioFrecuente.Checked;
            nariz.Rinorrea = this.chk_Nariz_Rinorrea.Checked;
            nariz.Sinusitis = this.chk_Nariz_Sinusitis.Checked;
            return nariz;
        }
        private void auxiliarNariz_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaNarizDB cnariz = new ClinicaPro.DB.Consulta.ConsultaNarizDB();
            ConsultaNariz entidadAgregar = ConsultaNariz_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cnariz.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region Oidos
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>oido</returns>
        private ConsultaOido ConsultaOido_Controles_A_Clase() // No añade el Id
        {
            ConsultaOido oido = new ConsultaOido();
            oido.Acusia = this.chk_Oidos_Acusia.Checked;
            oido.Hipercusia = this.chk_Oidos_Hipercusia.Checked;
            oido.Hipocusia = this.chk_Oidos_Hipocusia.Checked;
            oido.Otalgia = this.chk_Oidos_Otalgia.Checked;
            oido.Otorrea = this.chk_Oidos_Otorrea.Checked;
            oido.Tinitus = this.chk_Oidos_Tinitus.Checked;
            return oido;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaOidosDB cnariz = new ClinicaPro.DB.Consulta.ConsultaOidosDB();
            ConsultaOido entidadAgregar = ConsultaOido_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cnariz.Agregar_Modificar(entidadAgregar, true);
        }

        #endregion
        #region Ojos
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>Ojo</returns>
        private ConsultaOjo ConsultaOjos_Controles_A_Clase() // No añade el Id
        {
            ConsultaOjo ojo = new ConsultaOjo();
            ojo.Diplopia = this.chk_Ojos_Diploplia.Checked;
            ojo.Epifora = this.chk_Ojos_Epifora.Checked;
            ojo.FotoFobia = this.chk_Ojos_FotoFobia.Checked;
            ojo.Lentes = this.chk_Ojos_Lentes.Checked;
            ojo.Midriasis = this.chk_Ojos_Midriasis.Checked;
            ojo.PerdidaAgudezaVisual = this.txtPerdidaAgudeza.Text.Trim();
            ojo.Xerolftamia = this.chk_Ojos_Xerolftamia.Checked;

            return ojo;
        }

        #endregion
        #region Reflejos
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>Reflejo</returns>
        private ConsultaReflejo ConsultaReflejo_Controles_A_Clase() // No añade el Id
        {
            ConsultaReflejo reflejo = new ConsultaReflejo();
            if (txtReflejoObservacion.Enabled) reflejo.Observacion = txtReflejoObservacion.Text;
            reflejo.R_Adominales = chk_R_Adominales.Checked;
            reflejo.R_Bicipital = chk_R_Bicipital.Checked;
            reflejo.R_Carneano = chk_R_Carneano.Checked;
            reflejo.R_Mentoniano = chk_R_Mentoniano.Checked;
            reflejo.R_Orbicular_De_Los_Ojos = chk_R_Orbicular_De_Los_Ojos.Checked;
            reflejo.R_Patelar = chk_R_Patelar.Checked;
            reflejo.R_Radial = chk_R_Radial.Checked;
            reflejo.R_Tricipital = chk_R_Tricipital.Checked;
            reflejo.R_ValoracionGeneral = cb_Reflejo_ValoracionGeneral.Text;

            return reflejo;
        }
        /// <summary>
        /// Valida que Valoracion General no vaya vacia 
        /// </summary>
        /// <returns>true si esta vacio , false si no</returns>
        private bool validar_Reflejo_valoracionGeneral_null()
        {
            if (cb_Reflejo_ValoracionGeneral.Text == String.Empty) return true;
            else return false;
        }
        /// <summary>
        /// Valida que Valoracion General no sea mayor a su campo correspondiente en la base datos
        /// para el dia 11/6/2016 esta fijado en 10
        /// </summary>
        /// <returns>true si mayor a 10 , false si es menor 0 igual </returns>
        private bool validar_Reflejo_valoracionGeneral_tamano()
        {
            if (cb_Reflejo_ValoracionGeneral.Text.Length > 10) return true;
            else return false;
        }
        /// <summary>
        /// Habilita el campo Observacion, en GroupBox Reflejos de Exploracion Fisica
        /// </summary>       
        private void btn_ReflejoObservacion_Click(object sender, EventArgs e)
        {
            txtReflejoObservacion.Enabled = true;
        }

        private void AuiliarReflejo_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaReflejosDB crefle = new ClinicaPro.DB.Consulta.ConsultaReflejosDB();
            ConsultaReflejo entidadAgregar = ConsultaReflejo_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            crefle.Agregar_Modificar(entidadAgregar, false);
        }

        #endregion
        #region Cuello
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>Cuello</returns>
        private ConsultaCuello ConsultaCuello_Controles_A_Clase() // No añade el Id
        {
            ConsultaCuello cuello = new ConsultaCuello();

            cuello.AdenoPatias = chk_Cuello_AdenoPatias.Checked;
            cuello.ArteriasCarotidas = cb_ArteriaCarotida.Text;
            cuello.ConfiguracionDelCuello = chk_Cuello_ConfiguracionCuello.Checked;
            cuello.GangliosLinfaticos = cbGanglioLinfatico.Text;
            cuello.LesionesPiel = chk_Cuello_LesionPiel.Checked;
            cuello.PresionVenosa = (byte)txtPresionVenosaCuello.Value;
            cuello.Simetrico = chk_Cuello_Simetrico.Checked;

            return cuello;
        }
        private void auxiliarCuello_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaCuelloDB cCuello = new ClinicaPro.DB.Consulta.ConsultaCuelloDB();
            ConsultaCuello entidadAgregar = ConsultaCuello_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region EstadoEmocional
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>EstadoEmocional</returns>
        private ConsultaEstadoEmocional ConsultaEstadoEmocional_Controles_A_Clase() // No añade el Id
        {
            ConsultaEstadoEmocional emocional = new ConsultaEstadoEmocional();
            emocional.AlteracionSueño = chk_Emocional_AlteracionSueno.Checked;
            emocional.Alucinaciones = chk_Emocional_Alucionaciones.Checked;
            emocional.Debilidad = chk_Emocional_Debilidad.Checked;
            emocional.Depresion = chk_Emocional_Depresion.Checked;
            emocional.Desmayos = chk_Emocional_Desmayos.Checked;
            emocional.Distraido = chk_Emocional_Distraido.Checked;
            emocional.EdadAvanzada = chk_Emocional_EdadAvanzada.Checked;
            emocional.Irritabilidad = chk_Emocional_Irritabilidad.Checked;
            emocional.Nervioso = chk_Emocional_Nervioso.Checked;
            emocional.Normal = chk_Emocional_Normal.Checked;
            if (txtEmocional_Otro.Enabled == true) { emocional.Otro = txtEmocional_Otro.Text; }
            emocional.Tensión = chk_Emocional_Tension.Checked;
            return emocional;
        }
        private void btn_EmocionalOtro_Click_1(object sender, EventArgs e)
        {
            txtEmocional_Otro.Enabled = true;
            txtEmocional_Otro.Focus();
        }
        private void auxiliarEstadoEmo_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaEstadoEmocionalDB cCuello = new ClinicaPro.DB.Consulta.ConsultaEstadoEmocionalDB();
            ConsultaEstadoEmocional entidadAgregar = ConsultaEstadoEmocional_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region Craneo
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>Craneo</returns>
        private ConsultaCraneo ConsultaCraneo_Controles_A_Clase() // No añade el Id
        {
            ConsultaCraneo craneo = new ConsultaCraneo();
            craneo.AlteracionOsea = chk_Craneo_AltereacionOsea.Checked;
            craneo.Cefalea = chk_Craneo_Cefalea.Checked;
            craneo.Mareos = (byte)txtMareos.Value;
            craneo.PerdidaConciencia = chk_Craneo_PerdidaConciencia.Checked;
            craneo.Prurito = chk_Craneo_Prurito.Checked;
            craneo.Simetrico = chk_Craneo_Simetrico.Checked;
            craneo.Sincope = chk_Craneo_Sincope.Checked;
            craneo.TamañaFormaNormal = chk_Craneo_TamanoForma.Checked;
            return craneo;
        }

        private void auxiliarCraneo_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaCraneoDB cCuello = new ClinicaPro.DB.Consulta.ConsultaCraneoDB();
            ConsultaCraneo entidadAgregar = ConsultaCraneo_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }


        #endregion
        #region AparatoDigestivo
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>Craneo</returns>
        private ConsultaAparatoDigestivo ConsultaAparatoDigestivo_Controles_A_Clase() // No añade el Id
        {
            ConsultaAparatoDigestivo apaDigestivo = new ConsultaAparatoDigestivo();
            apaDigestivo.Colicos = chk_ApaDigestivo_Colico.Checked;
            if (txtAparatoDigestivoDetalle.Enabled) { apaDigestivo.Detalles = txtAparatoDigestivoDetalle.Text; }
            apaDigestivo.Diarrea = chk_ApaDigestivo_Diarrea.Checked;
            apaDigestivo.Distencion = chk_ApaDigestivoDistencion.Checked;
            apaDigestivo.Dolor = chk_ApaDigestivo_Dolor.Checked;
            apaDigestivo.Estreñimiento = chk_ApaDigestivo_Estrenimiento.Checked;
            apaDigestivo.FaltaApetito = chk_ApaDigestivo_FaltaApetito.Checked;
            apaDigestivo.Nauseas = chk_ApaDigestivo_Nauseas.Checked;
            apaDigestivo.Pirosis = chk_ApaDigestivo_Pirosis.Checked;
            apaDigestivo.Vomito = (byte)cbVomito.SelectedValue;

            return apaDigestivo;
        }
        private void LlenarComboAparatoDigestivo()
        {
            cbVomito.DataSource = ClinicaPro.General.Enumerados.ConsultaEnums.colorVomito;
            cbVomito.DisplayMember = "nombre";
            cbVomito.ValueMember = "valor";
        }

        private void btnApaDigestivoDetalle_Click(object sender, EventArgs e)
        {
            txtAparatoDigestivoDetalle.Enabled = true;
        }
        private void AuxiliarDigestivo_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaAparatoDigestivoDB cCuello = new ClinicaPro.DB.Consulta.ConsultaAparatoDigestivoDB();
            ConsultaAparatoDigestivo entidadAgregar = ConsultaAparatoDigestivo_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region Boca
        private ConsultaBoca ConsultaBoca_Controles_A_Clase() // No añade el Id
        {
            ConsultaBoca boca = new ConsultaBoca();

            boca.Adoncia = chk_Boca_Adoncia.Checked;
            boca.Amigdalitis = chk_Boca_Amigdalitis.Checked;
            boca.Calzas = chk_Boca_Calzas.Checked;
            boca.Disfagia = chk_Boca_Disfagia.Checked;
            boca.Faringitis = chk_Boca_Faringitis.Checked;
            boca.Laringitis = chk_Boca_Laringitis.Checked;
            boca.LenguaDolorosa = chk_Boca_LenguaDolor.Checked;
            boca.Protesis_Dentales = chk_Boca_Protesis.Checked;
            boca.Ronquera = chk_Boca_Ronquera.Checked;
            boca.UlcerasOrales = chk_Boca_Ulceras.Checked;

            return boca;
        }

        private void auxiliarboca_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaBocaDB cCuello = new ClinicaPro.DB.Consulta.ConsultaBocaDB();
            ConsultaBoca entidadAgregar = ConsultaBoca_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region Coordinacion y Marcha
        private CoordinacionyMarcha CoordinacionyMarcha_Controles_A_Clase() // No añade el Id
        {
            CoordinacionyMarcha cooMarcha = new CoordinacionyMarcha();
            cooMarcha.Camina = chk_CooMar_Camina.Checked;
            cooMarcha.Dedo_Nariz = chk_CooMar_DedoNariz.Checked;
            if (txt_ObsCoordinacion.Enabled) { cooMarcha.Observacion = txt_ObsCoordinacion.Text; }
            cooMarcha.Romberg = chk_CooMar_Romberg.Checked;
            cooMarcha.Talon_Rodilla = chk_CooMar_TalonRodilla.Checked;

            return cooMarcha;
        }
        private void btn_Obs_CoordinacionMarcha_Click(object sender, EventArgs e)
        {
            txt_ObsCoordinacion.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.CoordinacionYMarchaDB cCuello = new ClinicaPro.DB.Consulta.CoordinacionYMarchaDB();
            CoordinacionyMarcha entidadAgregar = CoordinacionyMarcha_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region ToraxyPulmon
        private void llenaComboTorax()
        {
            ClinicaPro.DB.Consulta.RespuestaGeneralesDB resGenerales = new ClinicaPro.DB.Consulta.RespuestaGeneralesDB();
            List<Consulta_RespuestasGenerales> lista = resGenerales.Listar();
            ClinicaPro.BL.ComboBoxBL<Consulta_RespuestasGenerales> configuraCB = new ComboBoxBL<Consulta_RespuestasGenerales>();

            configuraCB.fuenteBaseDatos(cb_Torax_Ascultacion, lista.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Torax_Expa, lista.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Torax_ResDiafraAbdo, lista.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Torax_RuidoAgregado, lista, comboNombreIDs.respuestaGenerales);
        }
        private ConsultaToraxPulmone ConsultaTorax_Controles_A_Clase() // No añade el Id
        {
            ConsultaToraxPulmone torax = new ConsultaToraxPulmone();

            torax.AscultacionMurmulloVescular = (byte)cb_Torax_Ascultacion.SelectedValue;
            torax.ExpasibilidadToraxica = (byte)cb_Torax_Expa.SelectedValue;
            torax.RespiracionDiafragmaticaAbdominal = (byte)cb_Torax_ResDiafraAbdo.SelectedValue;
            torax.RuidosAgregados = (byte)cb_Torax_RuidoAgregado.SelectedValue;
            torax.SonoridadPulmunar = chk_Torax_SonoridadPulmonar.Checked;
            return torax;
        }

        private void auxiliarToraxP_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ToraxPulmonesDB cCuello = new ClinicaPro.DB.Consulta.ToraxPulmonesDB();
            ConsultaToraxPulmone entidadAgregar = ConsultaTorax_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region Sensibilidad
        private ConsultaSensibilidad ConsultaSensibilidad_Controles_A_Clase() // No añade el Id
        {
            ConsultaSensibilidad sensibilidad = new ConsultaSensibilidad();

            if (txtSensibilidadDetalle.Enabled) { sensibilidad.Detalles = txtSensibilidadDetalle.Text; }
            sensibilidad.S_Discriminacion_Dos_Puntos = chk_Sensiblidad_Dis_DosPuntos.Checked;
            sensibilidad.S_Discriminatoria = chk_Sensiblidad_Discriminatoria.Checked;
            sensibilidad.S_Profunda = chk_Sensiblidad_Profunda.Checked;
            sensibilidad.S_Superficial = chk_Sensiblidad_Superficial.Checked;

            return sensibilidad;
        }
        private void btnSensbilidadDetalle_Click(object sender, EventArgs e)
        {
            txtSensibilidadDetalle.Enabled = true;
        }
        #endregion
        #region Estado Vivienda
        private void btnEViviendaDetalle_Click(object sender, EventArgs e)
        {
            txt_EvivendaDetalle.Enabled = true;
            txt_EvivendaDetalle.Focus();
        }

        private void llenaComboEstadoVivienda()
        {
            ClinicaPro.DB.Consulta.EstadoViviendaMaterialesDB materialesCB = new ClinicaPro.DB.Consulta.EstadoViviendaMaterialesDB();

            List<ConsultaEstadoViviendaMateriale> listAuxiliar = materialesCB.Listar();

            cbMaterialPiso.DataSource = listAuxiliar.ToList();
            cbMaterialPiso.ValueMember = "IdMaterial";
            cbMaterialPiso.DisplayMember = "Nombre";

            cbMaterialParedes.DataSource = listAuxiliar;
            cbMaterialParedes.ValueMember = "IdMaterial";
            cbMaterialParedes.DisplayMember = "Nombre";
        }

        private ConsultaEstadoVivienda ConsultaEstadoViviendaControles_A_Clase() // No añade el Id
        {
            ConsultaEstadoVivienda vivienda = new ConsultaEstadoVivienda();

            vivienda.AguaPotable = chk_Evivienda__AguaPotable.Checked;
            vivienda.Cielorraso = chk_Evivienda_Cielorrazo.Checked;
            if (txt_EvivendaDetalle.Enabled) { vivienda.DetalleExtra = txt_EvivendaDetalle.Text; }
            vivienda.IsPropia = chk_Evivienda_Propia.Checked;
            vivienda.Paredes_Material = (byte)cbMaterialParedes.SelectedValue;
            vivienda.Piso = (byte)cbMaterialPiso.SelectedValue;
            vivienda.SanitariosCantidad = (byte)txtNumeroBaños.Value;
            vivienda.ServiciosBasicos = txtServiciosBasicos.Text;
            vivienda.Ventilacion = chk_Evivienda_BuenaVentilacion.Checked;

            return vivienda;
        }
        private void auxiliarEVivienda_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.EstadoViviendaDB cCuello = new ClinicaPro.DB.Consulta.EstadoViviendaDB();
            ConsultaEstadoVivienda entidadAgregar = ConsultaEstadoViviendaControles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }

        #endregion
        #region ParesCreaneales
        /// <summary>
        ///  Devuelve una instancia con los datos  de los controles según la clase que corresponda
        /// </summary>
        /// <returns>Pares Craneales</returns>
        private ConsultaParesCraneale ParesCranealesControles_A_Clase()
        {
            ConsultaParesCraneale pares = new ConsultaParesCraneale();

            pares.PC_I_Olfatorio = chk_PC_I_Olfatorio.Checked;
            pares.PC_II_AgudezaVisual = chk_PC_II_AgudezaVisual.Checked;
            pares.PC_II_Campimetria = chk_PC_II_Campimetria.Checked;
            pares.PC_II_FondoOjo = chk_PC_II_FondoOjo.Checked;
            pares.PC_II_ReflejoPupilar = chk_PC_II_ReflejoPupilar.Checked;
            pares.PC_II_VisionColores = chk_PC_II_VisionColores.Checked;
            pares.PC_III_IV_VI_MovimientoOcular = chk_PC_III_IV_VI_MovimientoOcular.Checked;
            pares.PC_III_IV_VI_ReflejoFotoMotorDirectoyConsensual = chk_PC_III_IV_VI_ReflejoFotoMotorDirectoyConsensual.Checked;
            pares.PC_IX_FunciasGustativa = chk_PC_IX_FunciasGustativa.Checked;
            pares.PC_V_MovimientoMandibula = chk_PC_V_MovimientoMandibula.Checked;
            pares.PC_V_ReflejoCorneano = chk_PC_V_ReflejoCorneano.Checked;
            pares.PC_V_SensibilidadCara = chk_PC_V_SensibilidadCara.Checked;
            pares.PC_VII_CierreOjosVsResistencia = chk_PC_VII_CierreOjosVsResistencia.Checked;
            pares.PC_VII_Gustos2TerciosAnterioresLengua = chk_PC_VII_Gustos2TerciosAnterioresLengua.Checked;
            pares.PC_VII_MovibilidadMusculosCara = chk_PC_VII_MovibilidadMusculosCara.Checked;
            pares.PC_VII_MuecasAmbosLado = chk_PC_VII_MuecasAmbosLado.Checked;
            pares.PC_VII_SoplaMuentraDientes = chk_PC_VII_SoplaMuentraDientes.Checked;
            pares.PC_VIII_Romberg = chk_PC_VIII_Romberg.Checked;
            pares.PC_VIII_WebberYRinne = chk_PC_VIII_WebberYRinne.Checked;
            pares.PC_X_ElevacionSimetrica = chk_PC_X_ElevacionSimetrica.Checked;
            pares.PC_X_Lengua = chk_PC_X_Lengua.Checked;
            pares.PC_X_Paladar = chk_PC_X_Paladar.Checked;
            pares.PC_X_ReflejoNauseano = chk_PC_X_ReflejoNauseano.Checked;
            pares.PC_XI_MovimientoEsternocleidomastoideo = chk_PC_XI_MovimientoEsternocleidomastoideo.Checked;
            pares.PC_XI_MovimientoTrapecio = chk_PC_XI_MovimientoTrapecio.Checked;
            pares.PC_XI_TonoFuerzaMuscarlarEsterno = chk_PC_XI_TonoFuerzaMuscarlarEsterno.Checked;
            pares.PC_XI_TonoFuerzaMuscarlarTrapecio = chk_PC_XI_TonoFuerzaMuscarlarTrapecio.Checked;
            if (txtParCranealDetalle.Enabled) { pares.OtroDetalle = txtParCranealDetalle.Text; }

            return pares;
        }
        private void auxPares_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ParesCranealesDB cCuello = new ClinicaPro.DB.Consulta.ParesCranealesDB();
            ConsultaParesCraneale entidadAgregar = ParesCranealesControles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        private void btnParCranealDetalle_Click(object sender, EventArgs e)
        {
            this.txtParCranealDetalle.Enabled = true;
            txtParCranealDetalle.Focus();
        }

        #endregion
        #region EscalaTiempo
        /// <summary>
        /// Llena los CombBox de la  pestaña Antecedentes, no Patologicos
        /// </summary>
        private void llenaComboEscalaTiempoAnteceDenteNoPatologico()
        {
            // se añade toList() para que  solo sea necesario acceder a la BD una sola vez
            if (gbAnteceDentesNoPatologicos.Enabled)
            {
                if (isComboVacio(cb_NoPato_AlcoholEscala) && isComboVacio(cb_NoPato_VacunaEscala))
                {
                    ClinicaPro.DB.Consulta.EscalaTiempoDB escalaTimpoDB = new ClinicaPro.DB.Consulta.EscalaTiempoDB();
                    List<EscalaTiempo> listAuxiliar = escalaTimpoDB.Listar();

                    ClinicaPro.BL.ComboBoxBL<EscalaTiempo> configuraCB = new ComboBoxBL<EscalaTiempo>();


                    configuraCB.fuenteBaseDatos(cb_NoPato_AlcoholEscala, listAuxiliar.ToList(), comboNombreIDs.escalaTiempo);
                    configuraCB.fuenteBaseDatos(cb_NoPato_DrogaEscala, listAuxiliar.ToList(), comboNombreIDs.escalaTiempo);
                    configuraCB.fuenteBaseDatos(cb_NoPato_TabaquismoEscala, listAuxiliar.ToList(), comboNombreIDs.escalaTiempo);
                    configuraCB.fuenteBaseDatos(cb_NoPato_VacunaEscala, listAuxiliar, comboNombreIDs.escalaTiempo);
                }
            }
        }
        private void llenaComboEscalaTiempoConsulta()
        {
            if (cb_Consulta_EscalaTiempo.DataSource == null)
            {
                ClinicaPro.DB.Consulta.EscalaTiempoDB escalaTimpoDB = new ClinicaPro.DB.Consulta.EscalaTiempoDB();
                List<EscalaTiempo> listAuxiliar = escalaTimpoDB.Listar();
                ClinicaPro.BL.ComboBoxBL<EscalaTiempo> configuraCB = new ComboBoxBL<EscalaTiempo>();
                configuraCB.fuenteBaseDatos(cb_Consulta_EscalaTiempo, listAuxiliar.ToList(), comboNombreIDs.escalaTiempo);
            }
        }

        #endregion
        #region Antecedente Hereditario
        private AntecedenteHereditario AntecedenteHereditario_A_Clase() // No añade el ID 
        {
            AntecedenteHereditario antecedente = new AntecedenteHereditario();

            antecedente.AfeccionTiroide = (byte)cb_Here_AfecTiroide.SelectedValue;
            antecedente.Asma = (byte)cb_Here_Asma.SelectedValue;
            antecedente.AVC = (byte)cb_Here_AVC.SelectedValue;
            antecedente.Cancer = (byte)cb_Here_Cancer.SelectedValue;
            antecedente.Cardiopatía = (byte)cb_Here_Cardiopatia.SelectedValue;
            antecedente.DM = (byte)cb_Here_DM.SelectedValue;
            antecedente.EnfermedadPulmonar = (byte)cb_Here_EnferPulmunar.SelectedValue;
            antecedente.Hepatopapia = (byte)cb_Here_Hepato.SelectedValue;
            antecedente.HTA = (byte)cb_Here_HTA.SelectedValue;
            antecedente.Neuropatia = (byte)cb_Here_Neuropatia.SelectedValue;
            if (txt_HereditarioDetalle.Enabled) { antecedente.otro = txt_HereditarioDetalle.Text; }

            return antecedente;
        }
        private void auxHere_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.AntecedenteHereditarioDB cCuello = new ClinicaPro.DB.Consulta.AntecedenteHereditarioDB();
            AntecedenteHereditario entidadAgregar = AntecedenteHereditario_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        private void btnHereditarioDetalle_Click(object sender, EventArgs e)
        {
            txt_HereditarioDetalle.Enabled = true;
        }
        private void llenaComboAntecenteHereditario()
        {
            if (cb_Here_AfecTiroide.Items.Count == 0 && cb_Here_Neuropatia.Items.Count == 0)
            {
                ClinicaPro.DB.Consulta.FamiliarDB familiaDB = new ClinicaPro.DB.Consulta.FamiliarDB();
                List<Familiar> listAuxiliar = familiaDB.Listar();

                ClinicaPro.BL.ComboBoxBL<Familiar> configuraCB = new ComboBoxBL<Familiar>();

                configuraCB.fuenteBaseDatos(cb_Here_AfecTiroide, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_Asma, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_AVC, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_Cancer, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_Cardiopatia, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_DM, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_EnferPulmunar, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_Hepato, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_HTA, listAuxiliar.ToList(), comboNombreIDs.familiar);
                configuraCB.fuenteBaseDatos(cb_Here_Neuropatia, listAuxiliar, comboNombreIDs.familiar);
            }
        }
        private void llenaComboAntecedenteHereditario_Familiar() // Interesante, Llenar los combo en un iteracion
        {
            ClinicaPro.DB.Consulta.FamiliarDB familiaDB = new ClinicaPro.DB.Consulta.FamiliarDB();
            List<Familiar> listAuxiliar = familiaDB.Listar();

            ClinicaPro.BL.ComboBoxBL<Familiar> configuraCB = new ComboBoxBL<Familiar>();

            int saltos = 0;
            foreach (Control comboLocal in gbHereditario.Controls)
            {
                if (comboLocal is ComboBox)
                {
                    configuraCB.fuenteBaseDatos(comboLocal as ComboBox, listAuxiliar.ToList(), comboNombreIDs.familiar);
                }
                saltos++;
            }
        }
        #endregion
        #region Drogas

        BindingList<Drogas> listaDataGridDrogas;

        private AntecedenteDrogra AntecedenteDroga_Controles_A_Clase()
        {
            AntecedenteDrogra anteDroga = new AntecedenteDrogra();

            anteDroga.Drogas = listaDataGridDrogas.ToList();
            anteDroga.EscalaTiempo = cb_NoPato_DrogaEscala.SelectedItem as EscalaTiempo;
            anteDroga.NumeroTiempo = (byte)txtNoPato_NumTiempo_Droga.Value;
            return anteDroga;
        }

        private void btnDrogas_Click(object sender, EventArgs e)
        {
            if (dgDrogas.DataSource == null)
            {
                listaDataGridDrogas = new BindingList<Drogas>();
                dgDrogas.DataSource = listaDataGridDrogas;
                dgDrogas.Columns["idDrogas"].Visible = false;
            }
            listaDataGridDrogas.Add((Drogas)cb_Drogas.SelectedItem);
        }

        private Boolean isListaDrogasconDatos()
        {
            if (listaDataGridDrogas == null)
            {
                return false;
            }
            else return true;
        }

        private void llenaComboDrogas()
        {

            ClinicaPro.DB.Consulta.DrogaDB escalaDrogaDB = new ClinicaPro.DB.Consulta.DrogaDB();
            List<Drogas> listAuxiliar = escalaDrogaDB.Listar();

            ClinicaPro.BL.ComboBoxBL<Drogas> configuraCB = new ComboBoxBL<Drogas>();
            configuraCB.fuenteBaseDatos(cb_Drogas, listAuxiliar, comboNombreIDs.drogas);
        }

        private void auxDroga_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.AntecedenteDrogaDB cCuello = new ClinicaPro.DB.Consulta.AntecedenteDrogaDB();
            AntecedenteDrogra entidadAgregar = AntecedenteDroga_Controles_A_Clase();
            entidadAgregar.idConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }


        #endregion
        #region Vacunas

        BindingList<Vacunas> listaGridvacunas;

        public AntecedenteVacuna AntecedenteVacuna_Controles_A_Clase()
        {
            AntecedenteVacuna anteVacu = new AntecedenteVacuna();

            anteVacu.Vacunas = listaGridvacunas.ToList();
            anteVacu.EscalaTiempo = cb_NoPato_VacunaEscala.SelectedItem as EscalaTiempo;
            anteVacu.NumeroTiempo = (byte)txtNoPato_NumTiempo_Vacuna.Value;
            return anteVacu;
        }

        private void llenaComboVacunas()
        {
            if (cb_Vacunas.Items.Count == 0)
            {
                ClinicaPro.DB.Consulta.VacunasDB vacunaDB = new ClinicaPro.DB.Consulta.VacunasDB();
                List<Vacunas> listAuxiliar = vacunaDB.Listar();

                ClinicaPro.BL.ComboBoxBL<Vacunas> configuraCB = new ComboBoxBL<Vacunas>();
                configuraCB.fuenteBaseDatos(cb_Vacunas, listAuxiliar, comboNombreIDs.vacunas);
            }
        }

        private void btnVacunas_Click(object sender, EventArgs e)
        {
            if (dgVacuna.DataSource == null)
            {
                listaGridvacunas = new BindingList<Vacunas>();
                dgVacuna.DataSource = listaGridvacunas;
                this.dgVacuna.Columns["idVacunas"].Visible = false;

            }
            listaGridvacunas.Add((Vacunas)cb_Vacunas.SelectedItem);
        }
        private void auxVacuna_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.AntecedenteVacunaDB cCuello = new ClinicaPro.DB.Consulta.AntecedenteVacunaDB();
            AntecedenteVacuna entidadAgregar = AntecedenteVacuna_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        private bool isListaVacunasconDatos()
        {
            if (listaGridvacunas == null)
            {
                return false;

            }
            else return true;
        }
        #endregion
        #region Alcohol

        public AntecedenteAlcohol AntecedenteAlcohol_Controles_A_Clase()
        {
            AntecedenteAlcohol alco = new AntecedenteAlcohol();
            alco.BebeEnPromedio = cb_NoPato_BebePromedio.Text.Trim();
            alco.EscalaTiempo = (EscalaTiempo)cb_NoPato_AlcoholEscala.SelectedItem;
            alco.NumeroTiempo = (byte)txtNoPato_NumTiempo_Alchol.Value;
            return alco;
        }
        private void auxAlcho_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.AntecedenteAlcoholDB cCuello = new ClinicaPro.DB.Consulta.AntecedenteAlcoholDB();
            AntecedenteAlcohol entidadAgregar = AntecedenteAlcohol_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region AntecedentePatologico
        private AntecedentePersonalesPatologico AntecedentePatologico_Controles_A_Clase()
        {
            AntecedentePersonalesPatologico antePato = new AntecedentePersonalesPatologico();
            antePato.Bronquitis = (byte)cb_Ante_Pato_Bronquitis.SelectedValue;
            if (txt_Ante_Pato_Detalle.Enabled) antePato.Detalle = txt_Ante_Pato_Detalle.Text;
            antePato.Fiebre_Reumatica = (byte)cb_Ante_Pato_FiebreReumatica.SelectedValue;
            antePato.Paludismo = (byte)cb_Ante_Pato_Paludismo.SelectedValue;
            antePato.Parotiditis = (byte)cb_Ante_Pato_Paroditis.SelectedValue;
            antePato.Rubeola = (byte)cb_Ante_Pato_Rubeola.SelectedValue;
            antePato.Sarampion = (byte)cb_Ante_Pato_Sarampion.SelectedValue;
            antePato.Varicela = (byte)cb_Ante_Pato_Varicela.SelectedValue;

            return antePato;
        }

        /// <summary>
        /// Utiliza la tabla Respuesta_Generales  
        /// </summary>
        public void llenarComboAntecedentesPatologicos()
        {

            if (cb_Ante_Pato_Bronquitis.Items.Count == 0 && cb_Ante_Pato_Varicela.Items.Count == 0 )
            { 
            ClinicaPro.DB.Consulta.RespuestaGeneralesDB reespuestaGeneralesDB = new ClinicaPro.DB.Consulta.RespuestaGeneralesDB();
            List<Consulta_RespuestasGenerales> listAuxiliar = reespuestaGeneralesDB.Listar();

            ClinicaPro.BL.ComboBoxBL<Consulta_RespuestasGenerales> configuraCB = new ComboBoxBL<Consulta_RespuestasGenerales>();

            configuraCB.fuenteBaseDatos(cb_Ante_Pato_Bronquitis, listAuxiliar.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Ante_Pato_FiebreReumatica, listAuxiliar.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Ante_Pato_Paludismo, listAuxiliar.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Ante_Pato_Paroditis, listAuxiliar.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Ante_Pato_Rubeola, listAuxiliar.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Ante_Pato_Sarampion, listAuxiliar.ToList(), comboNombreIDs.respuestaGenerales);
            configuraCB.fuenteBaseDatos(cb_Ante_Pato_Varicela, listAuxiliar, comboNombreIDs.respuestaGenerales);
            // No quitar los toList()
            }
        }
        private void btnAntecedentePatologicoDetalle_Click(object sender, EventArgs e)
        {
            txt_Ante_Pato_Detalle.Enabled = true;
        }

        private void AuxPatologico_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.AntecedentePatologicoPersonalDB cCuello = new ClinicaPro.DB.Consulta.AntecedentePatologicoPersonalDB();
            AntecedentePersonalesPatologico entidadAgregar = AntecedentePatologico_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }

        #endregion
        #region Tabaquismo
        public AntecedenteTabaco AntecedenteTabaco_Controles_A_Clase()
        {
            AntecedenteTabaco alco = new AntecedenteTabaco();
            alco.EscalaTiempo = (EscalaTiempo)cb_NoPato_TabaquismoEscala.SelectedItem;
            alco.NumeroTiempo = (byte)txtNoPato_NumTiempo_Tabaquismo.Value;
            return alco;
        }
        private void auxTAba_Click(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.AntecedenteTabacoDB cCuello = new ClinicaPro.DB.Consulta.AntecedenteTabacoDB();
            AntecedenteTabaco entidadAgregar = AntecedenteTabaco_Controles_A_Clase();
            entidadAgregar.IdConsulta = 7;
            cCuello.Agregar_Modificar(entidadAgregar, false);
        }
        #endregion
        #region EscalaGaslow // Este es el mas distinto

        /// <summary>
        /// Una de las 3 categorias de la Escala Gaslow , la suma de las 3 se obtiene la valoracion final
        /// </summary>
        /// <returns>Número del 1-4</returns>
        private int RespuestaAperturaOcular()
        {
            if (Rb_Gaslow_AO_AOrden.Checked) return EscalaGaslow.AperturaOcular.A_la_orden;
            if (Rb_Gaslow_AO_Ausencia.Checked) return EscalaGaslow.AperturaOcular.Ausencia_de_apertura_ocular;
            if (Rb_Gaslow_AO_Espontanea.Checked) { return EscalaGaslow.AperturaOcular.Espontanea; }
            else return EscalaGaslow.AperturaOcular.Ante_un_estímulo_doloroso;
        }
        /// <summary>
        /// Una de las 3 categorias de la Escala Gaslow , la suma de las 3 se obtiene la valoracion final
        /// </summary>
        /// <returns>Número del 1-5</returns>
        private int RespuestaVerbal()
        {
            if (Rb_Gaslow_RV_Carencia.Checked) return EscalaGaslow.RespuestaVerbal.Carencia_de_actividad_verbal;
            if (Rb_Gaslow_RV_Linapropiado.Checked) return EscalaGaslow.RespuestaVerbal.Lenguaje_inapropiado;
            if (Rb_Gaslow_RV_Lincompresible.Checked) return EscalaGaslow.RespuestaVerbal.Lenguaje_incomprensible;
            if (Rb_Gaslow_RV_Orientado.Checked) return EscalaGaslow.RespuestaVerbal.Orientado_correctamente;
            else return EscalaGaslow.RespuestaVerbal.Paciente_confuso;
        }
        /// <summary>
        /// Una de las 3 categorias de la Escala Gaslow, la suma de las 3 se obtiene la valoracion final
        /// </summary>
        /// <returns>Número del 1-6</returns>
        private int RespuestaMotora()
        {
            if (Rb_Gaslow_RM_Ausencia.Checked) return EscalaGaslow.RespuestaMotora.Ausencia_de_respuesta_motora;
            if (Rb_Gaslow_RM_Evita.Checked) return EscalaGaslow.RespuestaMotora.Evita_estímulos_dolorosos_retirando_segmento_corporal_explorado;
            if (Rb_Gaslow_RM_Localiza.Checked) return EscalaGaslow.RespuestaMotora.Localiza_estímulos_dolorosos;
            if (Rb_Gaslow_RM_Obedece.Checked) return EscalaGaslow.RespuestaMotora.Obedece_órdenes_correctamente;
            if (Rb_Gaslow_RM_Rextension.Checked) return EscalaGaslow.RespuestaMotora.Respuesta_con_extensión_anormal_miembros;
            else return EscalaGaslow.RespuestaMotora.Respuesta_con_flexión_anormal_miembros;
        }
        private int Suma_RespuestaDeEscalaGaslow()
        {
            return (RespuestaMotora() + RespuestaVerbal() + RespuestaAperturaOcular());
        }
        private int getGaslowid()
        {
            int a = Suma_RespuestaDeEscalaGaslow();
            if (a > 13)
            {
                return EscalaGaslow.idResultadoSuma.Entre_14y15;
            }
            else if (a >= 9 && a <= 13)
            { return EscalaGaslow.idResultadoSuma.Entre_9y13; }
            else
            {
                return EscalaGaslow.idResultadoSuma.Entre_3y8;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClinicaPro.DB.Consulta.ConsultaGaslowDB cCuello = new ClinicaPro.DB.Consulta.ConsultaGaslowDB();
            //  cCuello.Agregar_Modificar(7, EscalaGaslow.idResultado_deSumas(Suma_RespuestaDeEscalaGaslow()), false);
        }

        #endregion
        #region Abdomen
        private ConsultaAbdomen ConsultaAbdomen_A_Clase()
        {
            ConsultaAbdomen abdomen = new ConsultaAbdomen();
            abdomen.Ascititis = chk_AbdomenAscititis.Checked;
            abdomen.Recto = cb_Abdomen_Recto.Text;
            abdomen.Riñon = cb_Abdomen_Rinon.Text;
            abdomen.TamanoOrganos = cb_Abdomen_TamanoOrganos.Text;
            abdomen.Vaso = cb_Abdomen_Bazo.Text;
            return abdomen;
        }
        private void cbPorDefectoAbdomen()
        {
            cb_Abdomen_Recto.SelectedIndex = 0;
            cb_Abdomen_Rinon.SelectedIndex = 0;
            cb_Abdomen_TamanoOrganos.SelectedIndex = 0;
            cb_Abdomen_Bazo.SelectedIndex = 0;
        }
        #endregion
      
        private void button14_Click(object sender, EventArgs e)
        {
            this.gbDatosGineco.Enabled = true;
            gbDatosGineco.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Pone los comboBox del  del segundoTab  anidado de ExploracioFIsica en sus valores predeterminados
        /// </summary>           
        private void buttonau_Click(object sender, EventArgs e)
        {
            llenaComboAntecedenteHereditario_Familiar();
        }
        private void buttonmanu_Click(object sender, EventArgs e)
        {
            llenaComboAntecenteHereditario();
        }     
        private void tapGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabGeneral.SelectedTab == tabAntecedente)
            {
                gbHereditario.Enabled = true;
                llenaComboEscalaTiempoAnteceDenteNoPatologico();
                llenaComboVacunas();
                llenaComboDrogas();
                llenarComboAntecedentesPatologicos();
                llenaComboAntecenteHereditario();
                cb_NoPato_BebePromedio.SelectedIndex = 1;
            }
            if (tabExploracionFisica.SelectedTab == tabMedidas)
            {
                LlenacomboMano();
                LlenacomboColor();
                cbGanglioLinfatico.SelectedIndex = 0;
                cb_ArteriaCarotida.SelectedIndex = 0;
                cb_Reflejo_ValoracionGeneral.SelectedIndex = 0;
                LlenarComboAparatoDigestivo();
                llenaComboTorax();
            }
            if (tabGeneral.SelectedTab == tabServicio)
            {
                LlenaComboServicio();
            }
            if (tabGeneral.SelectedTab == tabDiagnostico)
            {
                txtCostoConsulta.Value = CalcularCostoPorServicios();
            }
            if (tabGeneral.SelectedTab == tabDiagnostico)
            {
                txtPadecimientoActual.Focus();
            }
            if (tabGeneral.SelectedTab == tabSentidos)
            {
                gbGaslowEscala.Enabled = true;
            }
        }           
        private void chkLimpiarDatos_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void ModificarTemporal(bool isModificar)
        {
            ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new ClinicaDrFuentesEntities();       

            using (TransactionScope scope = new TransactionScope())  // scope Hace un RollBack si ocurre un error
            {  
                  AlergiasABaseDatos(isModificar);              
                scope.Complete();
            }
        }
        private void btnAuxiliarModificar_Click(object sender, EventArgs e)
        {
            //ModificarTemporal(ClinicaPro.General.accion.Modificar);
            GuardarTodos(ClinicaPro.General.accion.Modificar) ;
        }
    }
}
