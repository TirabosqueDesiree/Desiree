using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesClientes
{
    public class Cliente
    {
       

        public int IdCliente { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido."), MinLength(3, ErrorMessage = "El {0} debe tener mínimo {1} caracteres."), MaxLength(30, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres.")]

        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Este campo es requerido."), MinLength(3, ErrorMessage ="El {0} debe tener mínimo {1} caracteres."), MaxLength(30, ErrorMessage ="El {0} debe tener un máximo de {1} caracteres.")]
        public string Apellido { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Direccion { get; set; }

        public int IdUsuario { get; set; }

        [Display(Name = "Localidad")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Localidad{ get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdProvincia { get; set; }
    }


}