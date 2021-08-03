using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Dominio.Modelos;
using Ventas.Infraestructura.Repositorios;

namespace Ventas.UI.Controllers
{
    public class ClienteController : Controller
    {
        ClienteRepositorio dbCliente = new ClienteRepositorio();
        public ActionResult ListarCliente()
        {
            var lista = dbCliente.ListarCliente();

            return View(lista);
        }


        [HttpGet]
        public ActionResult AgregarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(Cliente cliente)
        {
            try
            {
                dbCliente.Agregar(cliente);
                return RedirectToAction("ListarCliente");
            }
            catch
            {
                return RedirectToAction("ListarCliente");
            }
        }
    }
}