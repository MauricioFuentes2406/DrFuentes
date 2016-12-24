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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Citas = new HashSet<Cita>();
            this.Consultas = new HashSet<Consulta>();
            this.ElectroResultados = new HashSet<ElectroResultado>();
            this.Examenes = new HashSet<Examene>();
            this.ClienteOtrosArchivos = new HashSet<ClienteOtrosArchivo>();
            this.ClienteAlergias = new HashSet<ClienteAlergia>();
        }
    
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public byte Edad { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public Nullable<int> Celular { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public bool isExtranjero { get; set; }
        public Nullable<byte> Estado { get; set; }
        public string TipoSangre { get; set; }
    
        public virtual ICollection<Cita> Citas { protected get; set; }
        public virtual ICollection<Consulta> Consultas { private get; set; }
        public virtual ICollection<ElectroResultado> ElectroResultados { private get; set; }
        public virtual ICollection<Examene> Examenes { private get; set; }
        public virtual ICollection<ClienteOtrosArchivo> ClienteOtrosArchivos { private get; set; }
        public virtual ICollection<ClienteAlergia> ClienteAlergias { private get; set; }
    }
}
