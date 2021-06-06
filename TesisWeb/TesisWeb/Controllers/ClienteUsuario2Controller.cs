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
    public class ClienteUsuario2Controller : Controller
    {
        // GET: ClienteUsuario2
        public ActionResult CrearUserCliente2()
        {
            Gestor gestor = new Gestor();
            VMUserCliente2 usuario = new VMUserCliente2
            {
                Roles = gestor.ListadoRoles(),
                ListaProvincias = gestor.ListadoProvincias()
            };

            return View(usuario);


        }
        [HttpPost]
        public ActionResult CrearUserCliente2(FormCollection formCollection, VMUserCliente2 model)
        {

            if (ModelState.IsValid)
                return RedirectToAction("IndexPrincipal", "HomePrincipal");
            else
                return View(model);

            /*Gestor gestor = new Gestor();

            Usuarios u = new Usuarios();
            u.email = formCollection["Email"];
            u.contraseña = formCollection["Contraseña"];
            u.idRol = Convert.ToInt32(formCollection["IdRol"]);



            gestor.Insertarusuarios2(u);


            var lista = gestor.BuscarUsuarioConContraseñayEmail(u.email, u.contraseña);

            int idEncontrado = 0;
            foreach (var item in lista)
            {
                idEncontrado = item.Id;
            }


            Cliente c = new Cliente();

            c.Nombre = formCollection["Nombre"];
            c.Apellido = formCollection["Apellido"];
            c.Telefono = formCollection["Telefono"];
            c.Direccion = formCollection["Direccion"];



            c.IdUsuario = idEncontrado;
            c.Localidad = formCollection["Localidad"];
            c.IdProvincia = Convert.ToInt32(formCollection["IdProvincia"]);




            ViewBag.Registro = "Registro de Usuario Exitoso";
            gestor.InsertarCliente2(c);


        }


            return RedirectToAction("CrearUserCliente");*/



        }
    }
}