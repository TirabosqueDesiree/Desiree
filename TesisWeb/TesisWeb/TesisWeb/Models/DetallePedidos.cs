//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesisWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallePedidos
    {
        public int idDetallePedido { get; set; }
        public int nroPedido { get; set; }
        public Nullable<int> idProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        public virtual Productos Productos { get; set; }
    }
}
