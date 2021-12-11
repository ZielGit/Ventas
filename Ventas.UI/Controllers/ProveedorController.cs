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
    public class ProveedorController : Controller
    {
        ProveedorRepositorio dbProveedor = new ProveedorRepositorio();

        // GET: Proveedor
        public ActionResult Index()
        {
            var lista = dbProveedor.ListarProveedores();

            return View(lista);
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = dbProveedor.ObtenerPorId(id.Value);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedor/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,RUC,Direccion,Email,Celular")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                dbProveedor.Agregar(proveedor);
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = dbProveedor.ObtenerPorId(id.Value);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,RUC,Direccion,Email,Celular")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                dbProveedor.Modificar(proveedor);
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            dbProveedor.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
