
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
    
public partial class Busqueda
{

    public Busqueda()
    {

        this.BusquedaImagenes = new HashSet<BusquedaImagene>();

    }


    public int IdItem { get; set; }

    public string Nombre { get; set; }

    public string Síntoma { get; set; }

    public string Tratamiento { get; set; }

    public string EnfermedadRelacionada { get; set; }

    public string DescripcionAdicional { get; set; }



    public virtual ICollection<BusquedaImagene> BusquedaImagenes { get; set; }

}

}
