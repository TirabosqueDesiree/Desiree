using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesisWeb.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult UnauthorizedOperation(String operacion, String msjeError)
        {
            ViewBag.operacion = operacion;
            ViewBag.msjeError = msjeError;
            return View();
        }
    }
}