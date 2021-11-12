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
    public class CategoriaController : Controller
    {
        CategoriaRepositorio dbCat = new CategoriaRepositorio();

        // GET: Categoria
        public ActionResult Index()
        {
            var lista = dbCat.ListarCategoria();

            return View(lista);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = dbCat.ObtenerPorId(id.Value);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Categoria_Id,Nombre,Estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                dbCat.Agregar(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = dbCat.ObtenerPorId(id.Value);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Categoria_Id,Nombre,Estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                dbCat.Modificar(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            dbCat.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
