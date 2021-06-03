using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWeb.Models.MaestroDetalle;

namespace TesisWeb.Controllers
{
    public class MaestroDetalleController : Controller
    {
        // GET: MaestroDetalle
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(VMPedido model)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View();
            }
        }
    }
}