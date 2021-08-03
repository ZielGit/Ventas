using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Dominio.Modelos;
using Ventas.Infraestructura.Repositorios;
using Ventas.Infraestructura.Repositorios.Base;

namespace Ventas.UI.Controllers
{


    public class ProductoController : Controller
    {

        ProductoRepositorio dbProd = new ProductoRepositorio();
        CategoriaRepositorio dbCate = new CategoriaRepositorio();

        // GET: Producto
        public ActionResult Index()
        {
            var lista = dbProd.ListarProductos();
            return View(lista);
        }

        public ActionResult Index1(int? dato1, string dato2, bool? dato3, bool? dato4)
        {
            llenarCategoria();
            ViewBag.lista = listaCate;

            var lista = dbProd.ListarProductos(dato1, dato2, dato3, dato4);
            Session["lista"] = lista;
            return View(lista);

        }
        //agregar 
        [HttpGet]
        public ActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto(Producto producto)
        {
            try
            {
                dbProd.Agregar(producto);
                return RedirectToAction("ListarProductos");
            }
            catch
            {
                return RedirectToAction("ListarProductos");
            }
        }

        List<SelectListItem> listaCate;

        private void llenarCategoria()
        {
            using (var bd = new VentasDbContexto())
            {
                listaCate = (from a in bd.Categoria
                             select new SelectListItem
                             {
                                 Text = a.Nombre,
                                 Value = a.Categoria_Id.ToString()
                             }).ToList();
                listaCate.Insert(0, new SelectListItem { Text = "Todos", Value = "" });

            }
        }

        public FileResult generarPDF()
        {
            Document doc = new Document();
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter.GetInstance(doc, ms);
                doc.Open();
                Paragraph title = new Paragraph("LISTA PRODUCTOS");
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph espacio = new Paragraph("  ");
                doc.Add(espacio);

                //Tabla con Número de columnas
                PdfPTable table = new PdfPTable(5);

                //anchos a las columnas
                float[] values = new float[5] { 40, 120, 60, 30, 30 };
                iText.Kernel.Font.PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                //anchos a la tabala
                table.SetWidths(values);

                //Creando Celdas con contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Id"));
                celda1.BackgroundColor = new BaseColor(52, 152, 219);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Nombre"));
                celda2.BackgroundColor = new BaseColor(52, 152, 219);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Precio"));
                celda3.BackgroundColor = new BaseColor(52, 152, 219);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase("Stock"));
                celda4.BackgroundColor = new BaseColor(52, 152, 219);
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda4);

                PdfPCell celda5 = new PdfPCell(new Phrase("Estado"));
                celda5.BackgroundColor = new BaseColor(52, 152, 219);
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda5);


                List<Producto> lista = (List<Producto>)Session["lista"];
                for (int i = 0; i < lista.Count; i++)
                {
                    table.AddCell(lista[i].Id.ToString());
                    table.AddCell(lista[i].Nombre.ToString());
                    table.AddCell(lista[i].Precio.ToString());
                    table.AddCell(lista[i].Stock.ToString());
                    table.AddCell(lista[i].Estado.ToString());
                }

                //Agregar Tabla al Documento
                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }

            return File(buffer, "application/pdf");
        }

    }
}