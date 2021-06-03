using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesClientes
{
    public class Cliente
    {
       

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }
        public string Localidad{ get; set; }
        public int IdProvincia { get; set; }
    }


}