
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
    
public partial class Familiar
{

    public Familiar()
    {

        this.AntecedenteHereditarios = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios1 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios2 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios3 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios4 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios5 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios6 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios7 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios8 = new HashSet<AntecedenteHereditario>();

        this.AntecedenteHereditarios9 = new HashSet<AntecedenteHereditario>();

    }


    public byte IdFamiliar { get; set; }

    public string Nombre { get; set; }



    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios1 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios2 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios3 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios4 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios5 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios6 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios7 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios8 { private get; set; }

    public virtual ICollection<AntecedenteHereditario> AntecedenteHereditarios9 { private get; set; }

}

}
