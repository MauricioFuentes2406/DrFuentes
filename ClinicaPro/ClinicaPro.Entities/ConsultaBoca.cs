
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
    
public partial class ConsultaBoca
{

    public int IdConsulta { get; set; }

    public bool Adoncia { get; set; }

    public bool Protesis_Dentales { get; set; }

    public bool Calzas { get; set; }

    public bool UlcerasOrales { get; set; }

    public bool LenguaDolorosa { get; set; }

    public bool Faringitis { get; set; }

    public bool Amigdalitis { get; set; }

    public bool Laringitis { get; set; }

    public bool Ronquera { get; set; }

    public bool Disfagia { get; set; }



    public virtual Consulta Consulta { private get; set; }

}

}
