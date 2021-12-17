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

        // GET: Ventas/Details/5
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

        // GET: Ventas/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
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

        // GET: Ventas/Edit/5
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

        // POST: Ventas/Edit/5
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

        // POST: Ventas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            dbVenta.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
