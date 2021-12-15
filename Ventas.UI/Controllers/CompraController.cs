using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ventas.Dominio.Modelos;
using Ventas.Infraestructura.Repositorios;

namespace Ventas.UI.Controllers
{
    public class CompraController : Controller
    {
        CompraRepositorio dbCompra = new CompraRepositorio();

        // GET: Compra
        public ActionResult Index()
        {
            var lista = dbCompra.ListarCompras();

            return View(lista);
        }

        // GET: Compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = dbCompra.ObtenerPorId(id.Value);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaCompra,Impuesto,total")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                dbCompra.Agregar(compra);
                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = dbCompra.ObtenerPorId(id.Value);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaCompra,Impuesto,total")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                dbCompra.Modificar(compra);
                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            dbCompra.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
