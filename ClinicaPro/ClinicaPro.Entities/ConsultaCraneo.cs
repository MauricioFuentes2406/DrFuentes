
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
    
public partial class ConsultaCraneo
{

    public int IdConsulta { get; set; }

    public bool TamañaFormaNormal { get; set; }

    public bool Simetrico { get; set; }

    public bool AlteracionOsea { get; set; }

    public bool Cefalea { get; set; }

    public bool Sincope { get; set; }

    public byte Mareos { get; set; }

    public bool PerdidaConciencia { get; set; }

    public bool Prurito { get; set; }



    public virtual Consulta Consulta { private get; set; }

}

}
