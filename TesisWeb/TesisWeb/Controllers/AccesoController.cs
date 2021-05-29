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
            int rolId = 0;
            try
            {
                
                using (Models.Entities1 db = new Models.Entities1())
                {
                    var oUser = (from d in db.Usuarios
                                 where d.email == email.Trim() && d.contraseña == password.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o Contraseña invalida";
                        return View();
                    }
                    Session["User"] = oUser;
                    rolId = Convert.ToInt32(oUser.idRol);

                }
                if (rolId != 3)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("IndexPrincipal", "HomePrincipal");
                }


                
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }

        }
        public ActionResult LoginAdm()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginAdm(string email, string password)
        {
            int rolId = 0;
            try
            {

                using (Models.Entities1 db = new Models.Entities1())
                {
                    var oUser = (from d in db.Usuarios
                                 where d.email == email.Trim() && d.contraseña == password.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o Contraseña invalida";
                        return View();
                    }
                    Session["User"] = oUser;
                    rolId = Convert.ToInt32(oUser.idRol);

                }
                if (rolId == 3)
                {
                    return RedirectToAction("IndexPrincipal", "HomePrincipal");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }


               
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
            return RedirectToAction("LoginAdm", "Acceso");
        }
    }
}