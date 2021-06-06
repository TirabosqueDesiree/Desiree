using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWeb.AccesoDatos;
using TesisWeb.Models;
using TesisWeb.Models.clasesClientes;

namespace TesisWeb.Controllers
{
    public class ClienteUsuarioController : Controller
    {
        // GET: ClienteUsuario
        public ActionResult CrearUserCliente()
        {
            Gestor gestor = new Gestor();
            VMUserCliente usuario = new VMUserCliente
            {
                Roles = gestor.ListadoRoles(),
                ListaProvincias = gestor.ListadoProvincias()
            };

            return View(usuario);

         
        }
        [HttpPost]
        public ActionResult CrearUserCliente(FormCollection formCollection)
        {
           
            Gestor gestor = new Gestor();

            Usuarios u = new Usuarios();
            u.email = formCollection["UsuarioModel.email"];
            u.contraseña = formCollection["UsuarioModel.contraseña"];
            u.idRol = Convert.ToInt32(formCollection["UsuarioModel.idRol"]);


            if (ModelState.IsValid)
            {
                gestor.Insertarusuarios2(u);
            }

            var lista= gestor.BuscarUsuarioConContraseñayEmail(u.email, u.contraseña);

            int idEncontrado = 0;
            foreach (var item in lista)
            {
                idEncontrado= item.Id;
            }


            Cliente c = new Cliente();

            c.Nombre = formCollection["ClienteModel.Nombre"];
            c.Apellido = formCollection["ClienteModel.Apellido"];
            c.Telefono = formCollection["ClienteModel.Telefono"];
            c.Direccion = formCollection["ClienteModel.Direccion"];



            c.IdUsuario = idEncontrado;
            c.Localidad = formCollection["ClienteModel.Localidad"];
            c.IdProvincia = Convert.ToInt32(formCollection["ClienteModel.IdProvincia"]);



            if(ModelState.IsValid)
            {
                ViewBag.Registro = "Registro de Usuario Exitoso";
                gestor.InsertarCliente2(c);

                return RedirectToAction("IndexPrincipal", "HomePrincipal" );
            }
            else
            {
                return RedirectToAction("CrearUserCliente");
            }

            
      

            
            
            

        }
    }
}