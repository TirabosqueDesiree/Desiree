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


        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido."), MinLength(5, ErrorMessage = "El {0} debe tener mínimo {1} caracteres."), MaxLength(50, ErrorMessage = "{0} debe tener un máximo de {1} caracteres.")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [Required, Range(100, 20000, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public double Precio { get; set; }    
        

        public int idOferta { get; set; }
     
        public byte[] imagenProducto { get; set; }
    }
}