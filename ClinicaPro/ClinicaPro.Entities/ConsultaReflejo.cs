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
    
    public partial class ConsultaReflejo
    {
        public int IdConsulta { get; set; }
        public string R_ValoracionGeneral { get; set; }
        public bool R_Orbicular_De_Los_Ojos { get; set; }
        public bool R_Carneano { get; set; }
        public bool R_Mentoniano { get; set; }
        public bool R_Bicipital { get; set; }
        public bool R_Tricipital { get; set; }
        public bool R_Radial { get; set; }
        public bool R_Adominales { get; set; }
        public bool R_Patelar { get; set; }
        public string Observacion { get; set; }
    
        public virtual Consulta Consulta { private get; set; }
    }
}
