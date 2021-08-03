using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Dominio.Modelos;
using Ventas.Infraestructura.Repositorios;

namespace Ventas.UI.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria

        CategoriaRepositorio dbCat = new CategoriaRepositorio();

        public ActionResult ListarCategoria()
        {
            var lista = dbCat.ListarCategoria();

            return View(lista);
        }

        
        [HttpGet]
        public ActionResult AgregarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCategoria(Categoria categoria)
        {
            try
            {
                dbCat.Agregar(categoria);
                return RedirectToAction("ListarCategoria");
            }
            catch
            {
                return RedirectToAction("ListarCategoria");
            }
        }

    }
}