using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TesisWeb.AccesoDatos;
using TesisWeb.Filters;
using TesisWeb.Models;
using TesisWeb.Models.clasesProducto;

namespace TesisWeb.Controllers
{
    public class ProductosController : Controller
    {
        private Entities2 db = new Entities2();

        [AuthorizeUser(idOperacion: 1)]
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
        public ActionResult Carga(VMProducto prod, HttpPostedFileBase imagenProducto)
        {
            if (imagenProducto != null && imagenProducto.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(imagenProducto.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imagenProducto.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                prod.ProductoModel.imagenProducto = imageData;


            }
            Gestor gestor = new Gestor();
            gestor.InsertarProductos(prod);
            db.SaveChanges();
            return RedirectToAction("ListadoProductos");

        }


        public ActionResult convertirImagen(int idProducto)
        {
            var imagenProducto = db.Productos.Where(x => x.idProducto == idProducto).FirstOrDefault();

            return File(imagenProducto.imagen, "imagenProducto/jpeg");

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



        [AuthorizeUser(idOperacion: 11)]
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
        public ActionResult EdicionProducto(VMProducto prod, HttpPostedFileBase imagenProducto)
        {

            if (imagenProducto != null && imagenProducto.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(imagenProducto.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imagenProducto.ContentLength);
                }
                //setear la imagen a la entidad que se creara
                prod.ProductoModel.imagenProducto = imageData;


            }
            Gestor gestor = new Gestor();
            gestor.EditarProductos(prod.ProductoModel);
            db.SaveChanges();
            return RedirectToAction("ListadoProductos");
        }

        [AuthorizeUser(idOperacion: 12)]
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


        [AuthorizeUser(idOperacion: 14)]
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


        [AuthorizeUser(idOperacion: 16)]
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


        [AuthorizeUser(idOperacion: 18)]
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


        [AuthorizeUser(idOperacion: 13)]
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

        [AuthorizeUser(idOperacion: 15)]
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


        [AuthorizeUser(idOperacion: 17)]
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



        [AuthorizeUser(idOperacion: 2)]
        public ActionResult ListadoProductos()
        {
            Gestor gestor = new Gestor();
            List<DTOProducto> lista = gestor.ListadoProductos();
            return View(lista);
        }

        [AuthorizeUser(idOperacion: 4)]
        public ActionResult ListadoTiposProductos()
        {
            Gestor gestor = new Gestor();
            List<TipoProducto> lista = gestor.ListadoTiposProd();
            return View(lista);
        }

        [AuthorizeUser(idOperacion: 6)]
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