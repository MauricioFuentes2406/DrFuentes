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
    
    public partial class ExploracionMano
    {
        public ExploracionMano()
        {
            this.ConsultaExploracionFisicas = new HashSet<ConsultaExploracionFisica>();
        }
    
        public int idExploracionManos { get; set; }
        public string Nombre { get; set; }
        public string TextoInformativo { get; set; }
    
        public virtual ICollection<ConsultaExploracionFisica> ConsultaExploracionFisicas { private get; set; }
    }
}
