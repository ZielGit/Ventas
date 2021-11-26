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
    public class ClienteController : Controller
    {
        ClienteRepositorio dbCliente = new ClienteRepositorio();

        // GET: Cliente
        public ActionResult Index()
        {
            var lista = dbCliente.ListarCliente();

            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = dbCliente.ObtenerPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Direccion,Ciudad,DNI,Email,Password,Estado,FechaCreacion,FechaModificacion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                dbCliente.Agregar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = dbCliente.ObtenerPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion,Ciudad,DNI,Email,Password,Estado,FechaCreacion,FechaModificacion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                dbCliente.Modificar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            dbCliente.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
