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
    
    public partial class Seguimiento
    {
        public int IdSeguimiento { get; set; }
        public int IdConsulta { get; set; }
        public Nullable<System.DateTime> FechaSeguimiento { get; set; }
        public Nullable<int> Prioridad { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Estado { get; set; }
    
        public virtual Consulta Consulta { private get; set; }
    }
}
