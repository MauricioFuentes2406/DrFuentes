
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
    
public partial class AntecedenteDrogra
{

    public AntecedenteDrogra()
    {

        this.Drogas = new HashSet<Drogas>();

    }


    public int idConsulta { get; set; }

    public int idAntecedenteDroga { get; set; }

    public byte NumeroTiempo { get; set; }



    public virtual Consulta Consulta { private get; set; }

    public virtual EscalaTiempo EscalaTiempo { get; set; }

    public virtual ICollection<Drogas> Drogas { get; set; }

}

}
