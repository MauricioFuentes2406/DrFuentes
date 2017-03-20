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
using ClinicaPro.General.Constantes.Citas;
using ClinicaPro.DB.Cita;
using ClinicaPro.General.Constantes;
//using ClinicaPro.Entities;

namespace ClinicaPro.Citas
{
    public partial class frmAgregarCita : Form
    {

        private int _currentDay;

        // Variables  usada a  la  hora de Modificar 
        private int _IdCita;
        private int _IdCliente;
        private int _IdTipoUsuario;
        // StackvOverflow

        private DateTime _prevDate;
        private bool initialValue = false;
        /// <summary>
        /// Variable auxiliar ayuda a poner los minutos  dtHora en 00 o 30
        /// </summary>
        DateTime dateTime;
        /// <summary>
        /// Agrear
        /// </summary>
        /// <param name="idTipoUsuario"></param>
        public frmAgregarCita(int idTipoUsuario)
        {
            InitializeComponent();
            this._IdCita = -1;
            this._IdCita = -1;
            this._IdTipoUsuario = idTipoUsuario;
         //   dateTime = dateTimePicker1.Value;
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="idCita"></param>
        /// <param name="idCliente"></param>
        /// <param name="idTipousuario"></param>
        public frmAgregarCita(int idCita, int idCliente, int idTipousuario)
        {
            InitializeComponent();
            this._IdCita = idCita;
            this._IdCliente = idCliente;
            this._IdTipoUsuario = idTipousuario;
            initialValue = true;
        }

        private void frmAgregarCita_Load(object sender, EventArgs e)
        {
            cargarGrid();
            cbEstado.SelectedIndex = 0;
            _currentDay = DateTime.Now.DayOfYear;
            llenarComboDuracion();
            if (_IdCita > 0)
            {
                Cita_Clase_A_Controles();
            }
            HoraCitaFormato0030m();
         
        }
        #region Metodos
        private void Cita_Clase_A_Controles()
        {
            var cita = CitasDB.getCita(this._IdCita);
            if (cita != null)
            {
                this.numIdCliente.Value = this._IdCliente;
                this.txtComentario.Text = cita.Comentario;
                this.cbEstado.Text = cita.EstadoCita;
                this.dtFechaCita.Value = cita.FechaCitaDesde;
                this.dtDesde.Value = cita.FechaCitaDesde;                               
                    TimeSpan horaA = new TimeSpan(cita.FechaCitaDesde.Hour, cita.FechaCitaDesde.Minute, 0);
                    TimeSpan horaB = cita.FechaCitaHasta;
                    var result = horaB - horaA;
                    try
                    {
                        cbDuracion.SelectedValue = (byte)result.TotalMinutes;
                    }
                    catch (InvalidOperationException)
                    { 
                        MessageBox.Show(this,Mensajes.AlgoPaso+"\n Se pondrá la  duracion de cita  Media hora","Duración Cita",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }               
                cita.SePresento = chkSePresento.Checked;                
            }
        }
        private void cargarGrid()
        {
            this.dgInfoDia.DataSource = DisplayDay.List();
            colorAlGrid();
        }
        private Boolean Validar()
        {
            String detalles = String.Empty;
            Boolean hallazgo = false;

            return hallazgo;
        }
        private void MensajeDeActulizacion()
        {
            MessageBox.Show(Mensajes.Agregar_Modificar,
                                      " Agregar Citas ",
                                        MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Information);
        }
        private ClinicaPro.Entities.Citas Cita_ControlAClase()
        {
            ClinicaPro.Entities.Citas cita = new ClinicaPro.Entities.Citas();
            cita.FechaCitaDesde = timeDesde();
            cita.FechaCitaHasta = timeHasta();
            cita.EstadoCita = (string)cbEstado.SelectedItem;
            cita.Comentario = txtComentario.Text.Trim();

            if (this._IdCita > 0)
            {
                cita.IdCita = this._IdCita;
                cita.SePresento = chkSePresento.Checked;
            }
            else
                cita.SePresento = false;
            return cita;
        }
        private TimeSpan timeHasta()
        {
            TimeSpan time = new TimeSpan(0, (byte)cbDuracion.SelectedValue , 0);
            TimeSpan timeHasta = new TimeSpan(dtDesde.Value.Hour,dtDesde.Value.Minute,0);
            ///timeHasta = timeHasta.AddHours((double)cbDuracion.SelectedValue ) ;
             return timeHasta.Add(time);
           
        }
        private DateTime timeDesde()
        {
            try
            {
                return new DateTime(dtFechaCita.Value.Year, dtFechaCita.Value.Month, dtFechaCita.Value.Day, dtDesde.Value.Hour, dtDesde.Value.Minute, 0);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(this,"Se produjo un erro en la fecha de Inicio , se añadio la fecha selecciona con la hora actual");
                return dtFechaCita.Value;            
            }
            
        }
        private void Limpiar()
        {
            txtComentario.ResetText();
            cbEstado.SelectedIndex = 0;
        }
        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (_currentDay != dtFechaCita.Value.DayOfYear)
            {
                //   this.dgInfoDia.DefaultCellStyle.BackColor = Color.White;
                cargarGrid();
            }
        }
        private void colorAlGrid()
        {
            var list = CitasDB.ListarDia(this.dtFechaCita.Value.Date);
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    actualizaHoy(item);
                }
            }
        }
        private void actualizaHoy(ClinicaPro.Entities.Citas cita)
        {
            int hora = cita.FechaCitaDesde.Hour;
            bool isMediaHora = false;
            if (cita.FechaCitaDesde.Minute >= 30)
            {
                isMediaHora = true;
            }

            switch (hora)
            {
                case 8:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.ocho, cita);
                    else
                        setRow(HoursRowIndex.ochoMedia, cita);
                    break;
                case 9:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Nueve, cita);
                    else
                        setRow(HoursRowIndex.NueveMedia, cita);
                    break;
                case 10:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Diez, cita);
                    else
                        setRow(HoursRowIndex.DiezMedia, cita);
                    break;
                case 11:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Once, cita);
                    else
                        setRow(HoursRowIndex.OnceMedia, cita);
                    break;
                case 12:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Doce, cita);
                    else
                        setRow(HoursRowIndex.DoceMedia, cita);
                    break;
                case 13:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Una, cita);
                    else
                        setRow(HoursRowIndex.UnaMedia, cita);
                    break;
                case 14:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Dos, cita);
                    else
                        setRow(HoursRowIndex.DosMedia, cita);
                    break;
                case 15:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Tres, cita);
                    else
                        setRow(HoursRowIndex.TresMedia, cita);
                    break;
                case 16:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Cuatro, cita);
                    else
                        setRow(HoursRowIndex.CuatroMedia, cita);
                    break;
                case 17:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Cinco, cita);
                    else
                        setRow(HoursRowIndex.CincoMedia, cita);
                    break;
                case 18:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Seis, cita);
                    else
                        setRow(HoursRowIndex.SeisMedia, cita);
                    break;
                case 19:
                    if (!isMediaHora)
                        setRow(HoursRowIndex.Siete, cita);
                    break;

                default:
                    break;
            }
        }
  /// <summary>
  /// LLena los Datos del Grid y da color a las filas
  /// </summary>
  /// <param name="HourRowIndex">Cada media hora representa un indice</param>
  /// <param name="cita"></param>
        private void setRow(int HourRowIndex, ClinicaPro.Entities.Citas cita)
        {
            var somethig = cita.FechaCitaHasta - cita.FechaCitaDesde.TimeOfDay;

            int numberFilas = (int)(somethig.TotalMinutes / 30);

            for (int i = 0; i < numberFilas; i++)
            {
                this.dgInfoDia.Rows[HourRowIndex + i].Cells["Estado"].Value = cita.EstadoCita;
                this.dgInfoDia.Rows[HourRowIndex + i].Cells["Nombre"].Value = "Pendiente de COlocar";
                this.dgInfoDia.Rows[HourRowIndex + i].Cells["Comentario"].Value = cita.Comentario;
                this.dgInfoDia.Rows[HourRowIndex + i].DefaultCellStyle.BackColor = System.Drawing.Color.Khaki;
            }

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                int result;
                if (this._IdCita == -1)
                   result = CitasDB.Agregar(Cita_ControlAClase(), (int)numIdCliente.Value);
                else
                {
                    result = CitasDB.Modificar(Cita_ControlAClase(),(int)numIdCliente.Value);
                }
                if (result >0 )
                {
                    Limpiar();
                    MensajeDeActulizacion();
                    cargarGrid();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            new ClinicaPro.Clientes.MantenimientoCliente(this._IdTipoUsuario).Show();
        }
       /// <summary>
       /// Hace que el DateTime.value sea de minutos 0 o 30 m
       /// </summary>
        private void HoraCitaFormato0030m()
        {
            if (_IdCita <= 0)
            {
                var dateTime = DateTime.Now;
                int MinutoActual = dateTime.Minute;

                if (MinutoActual < 30)  // 
                {
                    initialValue = true;
                    TimeSpan diff = new TimeSpan(0, MinutoActual, 0);
                    dtDesde.Value = dateTime.Subtract(diff);
                }
                else
                {
                    initialValue = true;
                    TimeSpan diff = new TimeSpan(0, MinutoActual - 30, 0);
                    dtDesde.Value = dateTime.Subtract(diff);
                }
            }
            _prevDate = dtDesde.Value;
        }
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            if (initialValue)
            {
                initialValue = false;
                return;
            }
            dateTime = dtDesde.Value;
            TimeSpan diff = dateTime - _prevDate;

            if (diff.Ticks < 0)
                dtDesde.Value = _prevDate.AddMinutes(-30);
            else
                dtDesde.Value = _prevDate.AddMinutes(30);

            _prevDate = dtDesde.Value;
        }
        private void llenarComboDuracion()
        {
            this.cbDuracion.DataSource = General.Enumerados.CitaEnums.DuracionPorMediaHora;
            cbDuracion.DisplayMember = "nombre";
            cbDuracion.ValueMember = "valor";
            cbDuracion.SelectedIndex = 0;
        }
    }
}
