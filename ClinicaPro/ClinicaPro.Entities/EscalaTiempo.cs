
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
    
public partial class EscalaTiempo
{

    public EscalaTiempo()
    {

        this.AntecedenteAlcohol = new HashSet<AntecedenteAlcohol>();

        this.AntecedenteDrogra = new HashSet<AntecedenteDrogra>();

        this.AntecedenteTabaco = new HashSet<AntecedenteTabaco>();

        this.AntecedenteVacuna = new HashSet<AntecedenteVacuna>();

        this.Consulta = new HashSet<Consulta>();

    }


    public string Nombre { get; set; }

    public byte IdEscalaTiempo { get; set; }



    public virtual ICollection<AntecedenteAlcohol> AntecedenteAlcohol { get; set; }

    public virtual ICollection<AntecedenteDrogra> AntecedenteDrogra { get; set; }

    public virtual ICollection<AntecedenteTabaco> AntecedenteTabaco { get; set; }

    public virtual ICollection<AntecedenteVacuna> AntecedenteVacuna { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; }

}

}
