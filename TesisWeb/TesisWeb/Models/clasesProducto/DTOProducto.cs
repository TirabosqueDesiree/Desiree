using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesProducto
{
    public class DTOProducto
    {
        public int IdProducto { get; set; }
        public string TipoProducto { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Oferta { get; set; }
    }
}