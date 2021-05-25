using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesProducto
{
    public class VMProducto
    {
        public Producto ProductoModel { get; set; }
        public List<TipoProducto> TiposProductos { get; set; }
        public List<Marca> TiposMarcas { get; set; }
        public List<Oferta> TiposOfertas { get; set; }
    }
}