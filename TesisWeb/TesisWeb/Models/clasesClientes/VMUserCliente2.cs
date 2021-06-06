using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesClientes
{
    public class VMUserCliente2
    {
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
             ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                      MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        public int IdRol { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }
        public string Localidad { get; set; }
        public int IdProvincia { get; set; }

        public List<RolesUsuarios> Roles { get; set; }

        public List<Provincia> ListaProvincias { get; set; }
    }
}