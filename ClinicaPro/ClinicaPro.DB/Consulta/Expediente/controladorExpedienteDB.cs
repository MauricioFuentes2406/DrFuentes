using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Consulta.Expediente
{
    /// <summary>
    /// Contiene las listas para llenar los datos de de los GridView de Expediente, facilita la operacion de filtrado pq concatena las busquedas por IdConsulta
    /// </summary>
   public class controladorExpedienteDB
    {
        //Exploracion Fisica
        List<Entities.VistaExploracionFisica> _ListaVistaExploracionFisica;
        List<Entities.VistaEstadoVivienda> _ListaVistaEstadoVivienda;
        List<Entities.VistaToraxPulmones> _ListaVistaTorax;
        List<Entities.ConsultaCraneo> _ListaCraneo;
        List<Entities.ConsultaOjo> _ListaOjo;
        List<Entities.ConsultaOido> _ListaOido;
        List<Entities.ConsultaNariz> _ListaNariz;
        List<Entities.ConsultaBoca> _ListaBoca;
        List<Entities.ConsultaCuello> _ListaCuello;
        List<Entities.ConsultaAbdomen> _ListaAbdomen;
        List<Entities.ConsultaAparatoDigestivo> _ListaAparatoDigestivo;
        List<Entities.CoordinacionyMarcha> _ListaCordinacionMarcha;
        List<Entities.AntecedentesGinecoObstrectico> _ListaGinecoObs;
        // Sentidos
        List<Entities.ConsultaEstadoEmocional> _ListaEstadoEmocional;
        List<Entities.ConsultaSensibilidad> _ListaSensibilidad;
        List<Entities.ConsultaParesCraneale> _ListaParesCraneales;
        List<Entities.ConsultaReflejo> _ListaReflejos;
       //Antecedentes
        List<Entities.VistaAntecedentesPatologicos> _ListaVistaAntecedentePatologico;
        List<Entities.VistaAntecedenteHereditario> _ListaVistaAntecedenteHereditario;
        List<Entities.VistaDrogas> _ListaVistaDrogras;
        List<Entities.VistaVacunas> _ListaVistaVacunas;
        List<Entities.VistaAlchol> _ListaVistaAlcohol;
        List<Entities.VistaTabaco> _ListaVistaTabaco;
       // Otras cosas
        List<Entities.VistaServicios> _ListaServicios;
        List<Entities.Seguimiento> _ListaSeguimientos;

        public controladorExpedienteDB()
        {
            // Exploracion Fisica
            _ListaVistaExploracionFisica = new List<Entities.VistaExploracionFisica>();
            _ListaVistaEstadoVivienda = new List<Entities.VistaEstadoVivienda>();
            _ListaVistaTorax = new List<Entities.VistaToraxPulmones>();
            _ListaCraneo = new List<Entities.ConsultaCraneo>();
            _ListaOjo = new List<Entities.ConsultaOjo>();
            _ListaOido = new List<Entities.ConsultaOido>();
            _ListaNariz = new List<Entities.ConsultaNariz>();
            _ListaBoca = new List<Entities.ConsultaBoca>();
            _ListaCuello = new List<Entities.ConsultaCuello>();
            _ListaAbdomen = new List<Entities.ConsultaAbdomen>();
            _ListaAparatoDigestivo = new List<Entities.ConsultaAparatoDigestivo>();
            _ListaCordinacionMarcha = new List<Entities.CoordinacionyMarcha>();
            _ListaGinecoObs = new List<Entities.AntecedentesGinecoObstrectico>();
            // Sentidos
            _ListaEstadoEmocional = new List<Entities.ConsultaEstadoEmocional>();
            _ListaSensibilidad = new List<Entities.ConsultaSensibilidad>();
            _ListaParesCraneales = new List<Entities.ConsultaParesCraneale>();
            _ListaReflejos = new List<Entities.ConsultaReflejo>();
            // Antecedentes
            _ListaVistaAntecedentePatologico = new List<Entities.VistaAntecedentesPatologicos>();
            _ListaVistaAntecedenteHereditario = new List<Entities.VistaAntecedenteHereditario>();
            _ListaVistaDrogras = new List<Entities.VistaDrogas>();
            _ListaVistaVacunas = new List<Entities.VistaVacunas>();
            _ListaVistaAlcohol = new List<Entities.VistaAlchol>();
            _ListaVistaTabaco = new List<Entities.VistaTabaco>();
            //
            _ListaServicios = new List<Entities.VistaServicios>();
            _ListaSeguimientos = new List<Entities.Seguimiento>();
        }
        public void addVServicios(int idConsulta)
        {
            _ListaServicios.AddRange(ClinicaPro.DB.Consulta.Vistas.VServicios.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaServicios> get_ListaVServicios()
        {
            return this._ListaServicios;
        }
        public void addVTabaco(int idConsulta)
        {
            _ListaVistaTabaco.AddRange(ClinicaPro.DB.Consulta.Vistas.VTabaco.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaTabaco> get_ListaVTabaco()
        {
            return this._ListaVistaTabaco;
        }
        public void addVAlcohol(int idConsulta)
        {
            _ListaVistaAlcohol.AddRange(ClinicaPro.DB.Consulta.Vistas.VAlchol.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaAlchol> get_ListaVAlcohol()
        {
            return this._ListaVistaAlcohol;
        }
        public void addVVacunas(int idConsulta)
        {
            _ListaVistaVacunas.AddRange(ClinicaPro.DB.Consulta.Vistas.VVacunas.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaVacunas> get_ListaVVacunas()
        {
            return this._ListaVistaVacunas;
        }
        public void addVDrogas(int idConsulta)
        {
            _ListaVistaDrogras.AddRange(ClinicaPro.DB.Consulta.Vistas.VDrogas.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaDrogas> get_ListaVDrogas()
        {
            return this._ListaVistaDrogras;
        }
        public void addVAntecedenteHereditario(int idConsulta)
        {
            _ListaVistaAntecedenteHereditario.AddRange(ClinicaPro.DB.Consulta.Vistas.VAntecedenteHereditario.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaAntecedenteHereditario> get_ListaVAntecedenteHereditario()
        {
            return this._ListaVistaAntecedenteHereditario;
        }
        public void addVAntecedentePatologico(int idConsulta)
        {
            _ListaVistaAntecedentePatologico.AddRange(ClinicaPro.DB.Consulta.VAntecedentePatologico.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaAntecedentesPatologicos> get_ListaVAntecedentePatologico()
        {
            return this._ListaVistaAntecedentePatologico;
        }
        public void addReflejo(int idConsulta)
        {
            ConsultaReflejosDB rDb = new ConsultaReflejosDB();
            _ListaReflejos.AddRange(rDb.ListaPorConsulta(idConsulta));
        }
     
        public List<Entities.ConsultaReflejo> get_ListaReflejo()
        {
            return this._ListaReflejos;
        }
        public void addConsultaParesCraneales(int idConsulta)
        {
            ParesCranealesDB pcDb = new ParesCranealesDB();
            _ListaParesCraneales.AddRange(pcDb.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaParesCraneale> get_ListaParesCraneales()
        {
            return this._ListaParesCraneales;
        }
        public void addSensibilidad(int idConsulta)
        {
            SensbilidadDB sDb = new SensbilidadDB();
            _ListaSensibilidad.AddRange(sDb.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaSensibilidad> get_ListaSensibilidad()
        {
            return this._ListaSensibilidad;
        }
       public List<Entities.Seguimiento> get_ListaSeguimiento()
        {
            return this._ListaSeguimientos;
        }
        public void addEstadoEmocional(int idConsulta)
        {
            ConsultaEstadoEmocionalDB eeDb = new ConsultaEstadoEmocionalDB();
            _ListaEstadoEmocional.AddRange( eeDb.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaEstadoEmocional> get_ListaEstadoEmocional()
        {
            return this._ListaEstadoEmocional;
        }
        public void addAntecedenteGinecoObstretico(int idConsulta)
        {
            GinecoObstreticosDB giDb = new GinecoObstreticosDB();
            _ListaGinecoObs.AddRange(giDb.ListaPorConsulta(idConsulta));
        }
        public List<Entities.AntecedentesGinecoObstrectico> get_ListaAntecedenteGinecoObstreticos()
        {
            return this._ListaGinecoObs;
        }
        public void addConsultaCoordinacionMarcha(int idConsulta)
        {
            CoordinacionYMarchaDB cmDB = new CoordinacionYMarchaDB();
            _ListaCordinacionMarcha.AddRange(cmDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.CoordinacionyMarcha> get_ListaConsultaCoodinacionMarcha()
        {
            return this._ListaCordinacionMarcha;
        }
        public void addConsultaAparatoDigestivo(int idConsulta)
        {
            ConsultaAparatoDigestivoDB adDB = new ConsultaAparatoDigestivoDB();
            _ListaAparatoDigestivo.AddRange (adDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaAparatoDigestivo> get_ListaConsultaAparatoDigestivo()
        {
            return this._ListaAparatoDigestivo;
        }
        public void addConsultaAbdomen(int idConsulta)
        {
            ConsultaAbdomenDB aDB = new ConsultaAbdomenDB();
            _ListaAbdomen.AddRange(aDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaAbdomen> get_ListaConsultaAbdomen()
        {
            return this._ListaAbdomen;
        }
        public void addConsultaCuello(int idConsulta)
        {
            ConsultaCuelloDB cuDB = new ConsultaCuelloDB();
            _ListaCuello.AddRange(cuDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaCuello> get_ListaConsultaCuello()
        {
            return this._ListaCuello;
        }
       public void addConsultaBoca(int idConsulta)
        {
            ConsultaBocaDB bDB = new ConsultaBocaDB();
            _ListaBoca.AddRange(bDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaBoca> get_ListaConsultaBoca()
        {
            return this._ListaBoca;
        }
       public void addConsultaNariz(int idConsulta)
        {
            ConsultaNarizDB nDB = new ConsultaNarizDB();
            this._ListaNariz.AddRange( nDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaNariz> get_ListaConsultaNariz()
        {
            return this._ListaNariz;
        }
        public void addConsultaOido(int idConsulta)
        {
            ConsultaOidosDB oiDb = new ConsultaOidosDB();
            _ListaOido.AddRange(oiDb.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaOido> get_ListaConsultaOido()
        {
            return this._ListaOido;
        }
       public void addConsultaOjo(int idConsulta)
        {
            ConsultaOjosDB oDB = new ConsultaOjosDB();
            _ListaOjo.AddRange(oDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.ConsultaOjo> get_ListaConsultaOjo()
        {
            return this._ListaOjo;
        }
       public void addConsultaCraneo(int idConsulta)
        {
            ConsultaCraneoDB craneoDB = new ConsultaCraneoDB();
            this._ListaCraneo.AddRange(craneoDB.ListaPorConsulta(idConsulta));           
        }
        public List<Entities.ConsultaCraneo> get_ListaConsultaCraneo()
        {
            return this._ListaCraneo;
        }
       public   List<Entities.VistaToraxPulmones>  get_ListaVistaToraxPulmones()
        {
            return this._ListaVistaTorax;
        }
       public void addVToraxPulmones(int idConsulta)
        {
            this._ListaVistaTorax.AddRange(ClinicaPro.DB.Consulta.Vistas.VToraxPulmones.ListaPorConsulta(idConsulta));
        }
       public void addVEstadoVivienda (int idConsulta)
        {
            this._ListaVistaEstadoVivienda.AddRange(ClinicaPro.DB.Consulta.Vistas.VEstadoVivienda.Listar(idConsulta));
        }
       public List<Entities.VistaEstadoVivienda> get_ListaEstadoVivienda()
       {
           return this._ListaVistaEstadoVivienda;
       }
        public void addVExploracionFisica(int idConsulta)
        {
            this._ListaVistaExploracionFisica.AddRange(ClinicaPro.DB.Consulta.Vistas.VExploracionFisica.Listar(idConsulta));
        }
        public void addSeguimiento(int idConsulta)
        {
            _ListaSeguimientos.AddRange(SeguimientoDB.ListaPorConsulta(idConsulta));
        }
        public List<Entities.VistaExploracionFisica> get_ListExploracionFisica()
        {
            return _ListaVistaExploracionFisica;
        }           
    }
}

