
//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
public partial class Consulta_RespuestasGenerales
{

    public Consulta_RespuestasGenerales()
    {

        this.AntecedentePersonalesPatologicos = new HashSet<AntecedentePersonalesPatologico>();

        this.AntecedentePersonalesPatologicos1 = new HashSet<AntecedentePersonalesPatologico>();

        this.AntecedentePersonalesPatologicos2 = new HashSet<AntecedentePersonalesPatologico>();

        this.AntecedentePersonalesPatologicos3 = new HashSet<AntecedentePersonalesPatologico>();

        this.AntecedentePersonalesPatologicos4 = new HashSet<AntecedentePersonalesPatologico>();

        this.AntecedentePersonalesPatologicos5 = new HashSet<AntecedentePersonalesPatologico>();

        this.AntecedentePersonalesPatologicos6 = new HashSet<AntecedentePersonalesPatologico>();

        this.ConsultaToraxPulmones = new HashSet<ConsultaToraxPulmone>();

        this.ConsultaToraxPulmones1 = new HashSet<ConsultaToraxPulmone>();

        this.ConsultaToraxPulmones2 = new HashSet<ConsultaToraxPulmone>();

        this.ConsultaToraxPulmones3 = new HashSet<ConsultaToraxPulmone>();

    }


    public byte idRespuestaGeneral { get; set; }

    public string Nombre { get; set; }



    public virtual ICollection<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos { private get; set; }

    public virtual ICollection<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos1 { private get; set; }

    public virtual ICollection<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos2 { private get; set; }

    public virtual ICollection<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos3 { private get; set; }

    public virtual ICollection<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos4 { private get; set; }

    public virtual ICollection<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos5 { private get; set; }

    public virtual ICollection<AntecedentePersonalesPatologico> AntecedentePersonalesPatologicos6 { private get; set; }

    public virtual ICollection<ConsultaToraxPulmone> ConsultaToraxPulmones { private get; set; }

    public virtual ICollection<ConsultaToraxPulmone> ConsultaToraxPulmones1 { private get; set; }

    public virtual ICollection<ConsultaToraxPulmone> ConsultaToraxPulmones2 { private get; set; }

    public virtual ICollection<ConsultaToraxPulmone> ConsultaToraxPulmones3 { private get; set; }

}

}
