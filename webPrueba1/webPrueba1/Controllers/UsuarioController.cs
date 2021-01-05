using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webPrueba1.Models;

namespace webPrueba1.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario modelo)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Principal", "Home");
            }
            else
            {
                return View(modelo);
            }
            
        }
    }
}