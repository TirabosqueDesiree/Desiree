using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesisWeb.Controllers
{
    public class HomePrincipalController : Controller
    {
        // GET: HomePrincipal
        public ActionResult IndexPrincipal()
        {
            return View();
        }
    }
}