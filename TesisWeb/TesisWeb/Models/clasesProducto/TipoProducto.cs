using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesProducto
{
    public class TipoProducto
    {
        public int IdTipoProducto { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido."), MinLength(5, ErrorMessage = "{0} debe tener mínimo {1} caracteres."), MaxLength(30, ErrorMessage = "{0} debe tener un máximo de {1} caracteres.")]
        public string Descripcion { get; set; }
    }
}