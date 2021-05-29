using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesisWeb.Models.clasesUsuarios
{
    public class VMUsuario
    {
        public Usuarios UsuarioModel { get; set; }
        public List<RolesUsuarios> Roles { get; set; }
    }
}