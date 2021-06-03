using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWeb.AccesoDatos;
using TesisWeb.Models.clasesClientes;

namespace TesisWeb.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult CrearCliente(string email, string password)
        {
           

            Gestor gestor = new Gestor();

                VMCliente cliente = new VMCliente();

                cliente.ListaProvincias = gestor.ListadoProvincias();
               
        
                return View(cliente);
            
            
        }
        [HttpPost]
        public ActionResult CrearCliente(VMCliente cliente)
        {
           
            Gestor gestor = new Gestor();

            VMCliente vm = new VMCliente();
            
            

            gestor.InsertarCliente(cliente);

            ViewBag.Mesagge = ("Registro Exitoso");
            return RedirectToAction("CrearCliente", "Clientes");

        }





    }
}