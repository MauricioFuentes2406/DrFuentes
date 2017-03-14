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
using ClinicaPro.BL;
using ClinicaPro.DB.Laboratorio;
using ClinicaPro.Entities;
using ClinicaPro.General.Constantes;

namespace ClinicaPro.Laboratorio
{
    public partial class AgregarExamenes : Form
    {
        public int idExamen { get; set; }
        public AgregarExamenes()
        {
            InitializeComponent();
        }
        public AgregarExamenes(int idExamen)
        {
            this.idExamen = idExamen;
            InitializeComponent();
            this.cbTipoExamen.Enabled = false;
        }
        #region Metodos

        private Examenes Examenes_Controles_A_Clase()
        {
            Examenes examen = new Examenes();            
             examen.ExamenEstado = (ExamenEstado) this.cbEstadoExamen.SelectedItem;
             examen.FechaConsulta = this.dtFechaHoy.Value;
             examen.FechaEntragaResultado = this.dtFechaResultado.Value;
             examen.TipoExamenes = (TipoExamenes)this.cbTipoExamen.SelectedItem;     
       
            if (idExamen > 0)
            {
                examen.idExamenes = this.idExamen;
            }
            if (numCliente.Value > 0)
            {
                var cliente = new ClinicaPro.DB.Cliente.ClienteDB().getCliente((int)this.numCliente.Value);
                if (cliente != null)
                { examen.Cliente = cliente; }
            }
            return examen;
        }
        private void Examenes_Clase_A_Controles()
        {
            var exa =  new ExamenesDB().getExamen(this.idExamen);
            if(exa != null)
            {
                cbTipoExamen.SelectedValue = exa.TipoExamenes.idTipoExamen;
                cbEstadoExamen.SelectedValue = exa.ExamenEstado.IdEstadoExamen;
                dtFechaResultado.Value = exa.FechaEntragaResultado;
                this.numCliente.Value = exa.Cliente.IdCliente;
            }
        }
        private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      " Agregar Examen ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private void MensajeNosePudoGuardar()
        {
              MessageBox.Show(Mensajes.NosePuedoGuardar,
                                      " Agregar Examen ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Error);
        }        
        private void cargarCombos()
        {
            cargarEstadoExamenes();
            cargarTipoExames();
        }
        private void cargarTipoExames()
        {
            new ComboBoxBL<TipoExamenes>().fuenteBaseDatos(this.cbTipoExamen, new TipoExamenDB().Listar(), comboNombreIDs.TipoExamenes);
        }
        private void cargarEstadoExamenes()
        {
            new ComboBoxBL<ExamenEstado>().fuenteBaseDatos(this.cbEstadoExamen, EstadoExamenDB.Listar(), "IdEstadoExamen");
        }
        private void CalcularFecha()
        {
            TipoExamenes tipo =(TipoExamenes)this.cbTipoExamen.SelectedItem;
            Double DiasCultivo = (double)tipo.DiasDeCultivo;
            this.dtFechaResultado.Value = DateTime.Today.AddDays(DiasCultivo);
        }
        #endregion
        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int result ;
            if (this.idExamen < 1)            
                result = new ExamenesDB().Agregar_Modificar(Examenes_Controles_A_Clase(), ClinicaPro.General.accion.Agregar);
            else
                result = new ExamenesDB().Agregar_Modificar(Examenes_Controles_A_Clase(), ClinicaPro.General.accion.Modificar);             
            if (result > 0)
                MensajeDeActulizacion();
            else
                MensajeNosePudoGuardar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AgregarExamenes_Load(object sender, EventArgs e)
        {
            cargarCombos();
            if (this.idExamen > 0)
                Examenes_Clase_A_Controles();
        }
        private void cbTipoExamen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcularFecha();
        }
        private void btnBusquedaCliente_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Clientes.MantenimientoCliente(3).Show(this);
        }
        #endregion                    
    }
}
