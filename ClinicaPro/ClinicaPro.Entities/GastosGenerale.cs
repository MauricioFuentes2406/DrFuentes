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
    
    public partial class GastosGenerale
    {
        public int idGastos { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> tiposCategoria { get; set; }
        public Nullable<int> CostoGasto { get; set; }
        public int IdTipoUsuario { get; set; }
        public Nullable<int> idTipoGasto { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaDeGasto { get; set; }
    
        public virtual TipoGastosGenerale TipoGastosGenerale { private get; set; }
        public virtual TipoUsuario TipoUsuario { private get; set; }
    }
}
