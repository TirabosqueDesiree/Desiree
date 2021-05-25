using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesProducto
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int idOferta { get; set; }
        //[Display(Name = "Imagen de Producto"), DataType(DataType.Upload)]
        public byte[] imagenProducto { get; set; }
    }
}