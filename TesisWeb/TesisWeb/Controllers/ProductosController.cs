using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWeb.AccesoDatos;
using TesisWeb.Filters;
using TesisWeb.Models.clasesProducto;

namespace TesisWeb.Controllers
{
    public class ProductosController : Controller
    {
        [AuthorizeUser(idOperacion:1)]
        public ActionResult Carga()
        {
            Gestor gestor = new Gestor();
            VMProducto vm = new VMProducto();
            vm.TiposMarcas = gestor.ListadoMarcas();
            vm.TiposProductos = gestor.ListadoTiposProd();
            vm.TiposOfertas = gestor.ListadoOfertas();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Carga(VMProducto prod)
        {
            Gestor gestor = new Gestor();
            gestor.InsertarProductos(prod);
            return RedirectToAction("ListadoProductos");
        }

        [AuthorizeUser(idOperacion: 5)]
        public ActionResult CargaMarca()
        {
            Gestor gestor = new Gestor();
            Marca m = new Marca();

            return View(m);
        }

        [HttpPost]
        public ActionResult CargaMarca(Marca marca)
        {
            Gestor gestor = new Gestor();
            gestor.InsertarMarcas(marca);
            return View("RegistroExito");
        }


        public ActionResult EdicionProducto(int Id)
        {
            var prod = new VMProducto();
            Gestor gestor = new Gestor();
            prod.ProductoModel = gestor.BuscarProductos(Id);
            prod.TiposProductos = gestor.ListadoTiposProd();
            prod.TiposMarcas = gestor.ListadoMarcas();
            prod.TiposOfertas = gestor.ListadoOfertas();


            return View(prod);
        }
        [HttpPost]
        public ActionResult EdicionProducto(VMProducto producto)
        {
            Gestor gestor = new Gestor();
            gestor.EditarProductos(producto.ProductoModel);
            return RedirectToAction("ListadoProductos");
        }

        public ActionResult EliminarProducto(int Id)
        {
            var prod = new VMProducto();
            Gestor gestor = new Gestor();
            prod.ProductoModel = gestor.BuscarProductos(Id);
            prod.TiposProductos = gestor.ListadoTiposProd();
            prod.TiposMarcas = gestor.ListadoMarcas();
            prod.TiposOfertas = gestor.ListadoOfertas();


            return View(prod);

        }
        [HttpPost]
        public ActionResult EliminarProducto(VMProducto prod)
        {
            Gestor gestor = new Gestor();
            gestor.EliminarProducto(prod.ProductoModel);
            return RedirectToAction("ListadoProductos");
        }

        public ActionResult EliminarTipoProd(int Id)
        {
            var tipo = new TipoProducto();
            Gestor gestor = new Gestor();
            tipo = gestor.BuscarTipoProductos(Id);
            return View(tipo);

        }
        [HttpPost]
        public ActionResult EliminarTipoProd(TipoProducto tipo)
        {
            Gestor gestor = new Gestor();
            gestor.EliminarTipoProducto(tipo);
            return RedirectToAction("ListadoTiposProductos");
        }


        public ActionResult EliminarMarca(int Id)
        {
            var marca = new Marca();
            Gestor gestor = new Gestor();
            marca = gestor.BuscarMarcas(Id);
            return View(marca);

        }
        [HttpPost]
        public ActionResult EliminarMarca(Marca m)
        {
            Gestor gestor = new Gestor();
            gestor.EliminarMarca(m);
            return RedirectToAction("ListadoMarcas");
        }


        public ActionResult EliminarOferta(int Id)
        {
            var oferta = new Oferta();
            Gestor gestor = new Gestor();
            oferta = gestor.BuscarOfertas(Id);
            return View(oferta);

        }
        [HttpPost]
        public ActionResult EliminarOferta(Oferta o)
        {
            Gestor gestor = new Gestor();
            gestor.EliminarOferta(o);
            return RedirectToAction("ListadoOfertas");
        }


        public ActionResult EdicionTipoProducto(int Id)
        {
            var tipoProd = new TipoProducto();
            Gestor gestor = new Gestor();
            tipoProd = gestor.BuscarTipoProductos(Id);


            return View(tipoProd);
        }
        [HttpPost]
        public ActionResult EdicionTipoProducto(TipoProducto tipo)
        {
            Gestor gestor = new Gestor();
            gestor.EditarTipoProductos(tipo);
            return RedirectToAction("ListadoTiposProductos");
        }
        public ActionResult EdicionMarca(int Id)
        {
            var marca = new Marca();
            Gestor gestor = new Gestor();
            marca = gestor.BuscarMarcas(Id);


            return View(marca);
        }
        [HttpPost]
        public ActionResult EdicionMarca(Marca m)
        {
            Gestor gestor = new Gestor();
            gestor.EditarMarca(m);
            return RedirectToAction("ListadoMarcas");
        }


        public ActionResult EdicionOferta(int Id)
        {
            var oferta = new Oferta();
            Gestor gestor = new Gestor();
            oferta = gestor.BuscarOfertas(Id);


            return View(oferta);
        }
        [HttpPost]
        public ActionResult EdicionOferta(Oferta o)
        {
            Gestor gestor = new Gestor();
            gestor.EditarOferta(o);
            return RedirectToAction("ListadoOfertas");
        }



        [AuthorizeUser (idOperacion:2)]
        public ActionResult ListadoProductos()
        {
            Gestor gestor = new Gestor();
            List<DTOProducto> lista = gestor.ListadoProductos();
            return View(lista);
        }

        [AuthorizeUser(idOperacion:4)]
        public ActionResult ListadoTiposProductos()
        {
            Gestor gestor = new Gestor();
            List<TipoProducto> lista = gestor.ListadoTiposProd();
            return View(lista);
        }

        [AuthorizeUser(idOperacion:6)]
        public ActionResult ListadoMarcas()
        {
            Gestor gestor = new Gestor();
            List<Marca> lista = gestor.ListadoMarcas();
            return View(lista);
        }

        [AuthorizeUser(idOperacion: 8)]
        public ActionResult ListadoOfertas()
        {
            Gestor gestor = new Gestor();
            List<Oferta> lista = gestor.ListadoOfertas();
            return View(lista);
        }

        [AuthorizeUser(idOperacion: 3)]
        public ActionResult CargaTipoProducto()
        {
            Gestor gestor = new Gestor();
            TipoProducto tp = new TipoProducto();

            return View(tp);
        }

        [HttpPost]
        public ActionResult CargaTipoProducto(TipoProducto tp)
        {
            Gestor gestor = new Gestor();
            gestor.InsertarTipoProd(tp);
            return RedirectToAction("ListadoTiposProductos", "Productos");
        }

        [AuthorizeUser(idOperacion: 7)]
        public ActionResult CargaOferta()
        {
            Gestor gestor = new Gestor();
            Oferta oferta = new Oferta();
            return View(oferta);
        }

        [HttpPost]
        public ActionResult CargaOferta(Oferta oferta)
        {
            Gestor gestor = new Gestor();
            gestor.InsertarOferta(oferta);
            return View("RegistroExito");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}