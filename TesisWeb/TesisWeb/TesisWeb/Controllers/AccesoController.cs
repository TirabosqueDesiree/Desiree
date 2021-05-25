using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TesisWeb.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {

                using (Models.Entities1 db = new Models.Entities1())
                {
                    var oUser = (from d in db.Usuarios
                                 where d.email == email.Trim() && d.contraseña == password.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "usuario o Contraseña invalida";
                        return View();
                    }
                    Session["User"] = oUser;


                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }

        }
        
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Acceso");
        }
    }
}