
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
    
public partial class GeneralTipoServicio
{

    public GeneralTipoServicio()
    {

        this.Consultas = new HashSet<Consulta>();

        this.InventarioMedicinas = new HashSet<InventarioMedicina>();

    }


    public int idServicio { get; set; }

    public string Nombre { get; set; }

    public int Precio { get; set; }

    public bool IsPrecioEditable { get; set; }



    public virtual ICollection<Consulta> Consultas { private get; set; }

    public virtual ICollection<InventarioMedicina> InventarioMedicinas { protected get; set; }

}

}
