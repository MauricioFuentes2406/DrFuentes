﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicaPro.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ClinicaDrFuentesEntities : DbContext
    {
        public ClinicaDrFuentesEntities()
            : base("name=ClinicaDrFuentesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AntecedenteHereditario> AntecedenteHereditarios { get; set; }
        public virtual DbSet<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos { get; set; }
        public virtual DbSet<AntecedentesGinecoObstrectico> AntecedentesGinecoObstrecticos { get; set; }
        public virtual DbSet<BusquedaImagene> BusquedaImagenes { get; set; }
        public virtual DbSet<Busqueda> Busquedas { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteOtrosArchivo> ClienteOtrosArchivos { get; set; }
        public virtual DbSet<ColorPaciente> ColorPacientes { get; set; }
        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Consulta_RespuestasGenerales> Consulta_RespuestasGenerales { get; set; }
        public virtual DbSet<ConsultaAparatoDigestivo> ConsultaAparatoDigestivoes { get; set; }
        public virtual DbSet<ConsultaCraneo> ConsultaCraneos { get; set; }
        public virtual DbSet<ConsultaCuello> ConsultaCuelloes { get; set; }
        public virtual DbSet<ConsultaEstadoEmocional> ConsultaEstadoEmocionals { get; set; }
        public virtual DbSet<ConsultaEstadoVivienda> ConsultaEstadoViviendas { get; set; }
        public virtual DbSet<ConsultaEstadoViviendaMateriale> ConsultaEstadoViviendaMateriales { get; set; }
        public virtual DbSet<ConsultaExploracionFisica> ConsultaExploracionFisicas { get; set; }
        public virtual DbSet<ConsultaNariz> ConsultaNarizs { get; set; }
        public virtual DbSet<ConsultaOido> ConsultaOidos { get; set; }
        public virtual DbSet<ConsultaOjo> ConsultaOjos { get; set; }
        public virtual DbSet<ConsultaParesCraneale> ConsultaParesCraneales { get; set; }
        public virtual DbSet<ConsultaReflejo> ConsultaReflejos { get; set; }
        public virtual DbSet<ConsultaSensibilidad> ConsultaSensibilidads { get; set; }
        public virtual DbSet<ConsultaToraxPulmone> ConsultaToraxPulmones { get; set; }
        public virtual DbSet<CoordinacionyMarcha> CoordinacionyMarchas { get; set; }
        public virtual DbSet<ElectroResultado> ElectroResultados { get; set; }
        public virtual DbSet<EscalaTiempo> EscalaTiempoes { get; set; }
        public virtual DbSet<Examene> Examenes { get; set; }
        public virtual DbSet<ExamenesResultado> ExamenesResultadoes { get; set; }
        public virtual DbSet<ExploracionMano> ExploracionManos { get; set; }
        public virtual DbSet<Familiar> Familiars { get; set; }
        public virtual DbSet<GastosGenerale> GastosGenerales { get; set; }
        public virtual DbSet<GeneralTipoServicio> GeneralTipoServicios { get; set; }
        public virtual DbSet<InventarioMedicina> InventarioMedicinas { get; set; }
        public virtual DbSet<Seguimiento> Seguimientoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TipoAlergia> TipoAlergias { get; set; }
        public virtual DbSet<TipoCita> TipoCitas { get; set; }
        public virtual DbSet<TipoExamene> TipoExamenes { get; set; }
        public virtual DbSet<TipoGastosGenerale> TipoGastosGenerales { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<ExpedienteT> ExpedienteTs { get; set; }
        public virtual DbSet<Vista_TiposAlergia_comboBox> Vista_TiposAlergia_comboBox { get; set; }
        public virtual DbSet<ClienteAlergia> ClienteAlergias { get; set; }
        public virtual DbSet<AntecedenteAlcohol> AntecedenteAlcohol { get; set; }
        public virtual DbSet<AntecedenteDrogra> AntecedenteDrogra { get; set; }
        public virtual DbSet<AntecedenteTabaco> AntecedenteTabaco { get; set; }
        public virtual DbSet<AntecedenteVacuna> AntecedenteVacuna { get; set; }
        public virtual DbSet<Drogas> Drogas { get; set; }
        public virtual DbSet<Vacunas> Vacunas { get; set; }
        public virtual DbSet<GlasgowResultado> GlasgowResultado { get; set; }
        public virtual DbSet<ConsultaAbdomen> ConsultaAbdomen { get; set; }
        public virtual DbSet<VistaAntecedentesPatologicos> VistaAntecedentesPatologicos { get; set; }
        public virtual DbSet<VistaAntecedenteHereditario> VistaAntecedenteHereditario { get; set; }
        public virtual DbSet<VistaClienteAlergias> VistaClienteAlergias { get; set; }
        public virtual DbSet<VistaExploracionFisica> VistaExploracionFisica { get; set; }
        public virtual DbSet<VistaConsulta> VistaConsulta { get; set; }
        public virtual DbSet<VistaServicios> VistaServicios { get; set; }
        public virtual DbSet<VistaDrogas> VistaDrogas { get; set; }
        public virtual DbSet<VistaVacunas> VistaVacunas { get; set; }
        public virtual DbSet<VistaAlchol> VistaAlchol { get; set; }
        public virtual DbSet<VistaTabaco> VistaTabaco { get; set; }
        public virtual DbSet<VistaEstadoVivienda> VistaEstadoVivienda { get; set; }
        public virtual DbSet<VistaToraxPulmones> VistaToraxPulmones { get; set; }
        public virtual DbSet<ConsultaBoca> ConsultaBocas { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
