using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWeb.Controllers;
using TesisWeb.Models;

namespace TesisWeb.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Usuarios oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                

                oUsuario = (Usuarios)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                    }

                }
                base.OnActionExecuting(filterContext);

            }
            catch (Exception)
            {

                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }
    }
}