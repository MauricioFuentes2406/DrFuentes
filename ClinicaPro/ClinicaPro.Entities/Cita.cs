
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
    
public partial class Cita
{

    public int IdCita { get; set; }

    public int IdCliente { get; set; }

    public int IdTipoCita { get; set; }

    public System.DateTime FechaCita { get; set; }

    public int EstadoCita { get; set; }

    public string Comentario { get; set; }



    public virtual Cliente Cliente { private get; set; }

    public virtual TipoCita TipoCita { private get; set; }

}

}
