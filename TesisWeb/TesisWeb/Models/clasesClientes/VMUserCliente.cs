using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesClientes
{
    public class VMUserCliente
    {
        
        public Usuarios UsuarioModel { get; set; }
        public List<RolesUsuarios> Roles { get; set; }
        public Cliente ClienteModel { get; set; }
        public List<Provincia> ListaProvincias { get; set; }
    }
}