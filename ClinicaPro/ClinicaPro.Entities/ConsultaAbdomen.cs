
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
    
public partial class ConsultaAbdomen
{

    public int IdConsulta { get; set; }

    public string TamanoOrganos { get; set; }

    public string Riñon { get; set; }

    public string Recto { get; set; }

    public string Vaso { get; set; }

    public bool Ascititis { get; set; }



    public virtual Consulta Consulta { private get; set; }

}

}
