using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWeb.Models;

namespace TesisWeb.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuarios oUsuario;
        private Entities db = new Entities();
        private int idOperacion;

        public AuthorizeUser (int idOperacion=0)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";

            try
            {
                oUsuario = (Usuarios)HttpContext.Current.Session["User"];
                var lstEntities = from m in db.Roles_Operaciones
                                  where m.idRol == oUsuario.idRol
                                  && m.idOperacion == idOperacion
                                  select m;
                if (lstEntities.ToList().Count <1)
                {
                    var oOperacion = db.Operaciones.Find(idOperacion);
                    nombreOperacion = getNombreOperacion(idOperacion);
                    nombreOperacion = nombreOperacion.Replace(' ', '+');

                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion);
                }
                    
            }
            catch (Exception)
            {

                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion);
            }
            
        }

        private string getNombreOperacion(int idOperacion)
        {
            var ope = from op in db.Operaciones
                      where op.idOperacion == idOperacion
                      select op.nombre;

            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {

                nombreOperacion = ""; 
            }
            return nombreOperacion;


        }
    }
}