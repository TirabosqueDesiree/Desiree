using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWeb.AccesoDatos;
using TesisWeb.Models;
using TesisWeb.Models.clasesProducto;
using TesisWeb.Models.clasesUsuarios;

namespace TesisWeb.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private Entities1 db = new Entities1();

        
        public ActionResult CrearUsuario()
        {
            Gestor gestor = new Gestor();
            VMUsuario usuario = new VMUsuario();

            usuario.Roles = gestor.ListadoRoles();
           

            return View(usuario);
        }

        [HttpPost]
        public ActionResult CrearUsuario(VMUsuario usuario)
        {
           
            Gestor gestor = new Gestor();
            gestor.Insertarusuarios(usuario);
            
            return RedirectToAction("IndexPrincipal", "HomePrincipal");

        }
    }
}