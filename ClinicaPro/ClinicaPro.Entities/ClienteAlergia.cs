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
    
    public partial class ClienteAlergia
    {
        public int IdCLiente { get; set; }
        public int IdAlergia { get; set; }
        public Nullable<bool> soloxEF { get; set; }
    
        public virtual Cliente Cliente { private get; set; }
        public virtual TipoAlergia TipoAlergia { private get; set; }
    }
}
