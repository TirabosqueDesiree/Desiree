using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesisWeb.Models;

namespace TesisWeb.Controllers
{
    public class Clientes1Controller : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Clientes1
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Provincias).Include(c => c.Usuarios);
            return View(clientes.ToList());
        }

        // GET: Clientes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes1/Create
        public ActionResult Create()
        {
            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descripcion");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "email");
            return View();
        }

        // POST: Clientes1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,nombre,apellido,telefono,direccion,idUsuario,localidad,idProvincia")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descripcion", clientes.idProvincia);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "email", clientes.idUsuario);
            return View(clientes);
        }

        // GET: Clientes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descripcion", clientes.idProvincia);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "email", clientes.idUsuario);
            return View(clientes);
        }

        // POST: Clientes1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,nombre,apellido,telefono,direccion,idUsuario,localidad,idProvincia")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descripcion", clientes.idProvincia);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "email", clientes.idUsuario);
            return View(clientes);
        }

        // GET: Clientes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
