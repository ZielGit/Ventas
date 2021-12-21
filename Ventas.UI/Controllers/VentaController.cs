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
    public class VentaController : Controller
    {
        VentaRepositorio dbVenta = new VentaRepositorio();

        // GET: Ventas
        public ActionResult Index()
        {
            var lista = dbVenta.ListarVentas();

            return View(lista);
        }

        // GET: Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = dbVenta.ObtenerPorId(id.Value);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Venta/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Venta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaVenta,impuesto,total")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                dbVenta.Agregar(venta);
                return RedirectToAction("Index");
            }
            return View(venta);
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = dbVenta.ObtenerPorId(id.Value);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Venta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaVenta,impuesto,total")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                dbVenta.Modificar(venta);
                return RedirectToAction("Index");
            }
            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            dbVenta.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
