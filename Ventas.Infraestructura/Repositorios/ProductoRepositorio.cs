using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;
using Ventas.Dominio.Repositorios;

using Ventas.Infraestructura.Repositorios.Base;

namespace Ventas.Infraestructura.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {

        VentasDbContexto db = new VentasDbContexto();
        public int Agregar(Producto producto)
        {
            //agregando la entidad en el contexto de EF
            db.Producto.Add(producto);
            //Persiste la infomación de la entidad en base de datos.
            db.SaveChanges();
            return producto.Id;
        }

     
        public IEnumerable<Producto> ListarProductos()
        {
            //Consulta Linq
            var query = from a in db.Producto select a;

            return query.ToList();
        }

        public IEnumerable<Producto> ListarProductos(int? dato1, string dato2, bool? dato3, bool? dato4)
        {
            List<Producto> query = null;
            if (dato2 == null)
            {
                query = (from a in db.Producto select a).ToList();
            }
            else if (dato4 == true)
            {
                if (dato3 == true)
                {
                    query = (from a in db.Producto
                             join b in db.Categoria
                             on a.Categoria_Id equals b.Categoria_Id
                             where (dato1 == null || a.Categoria_Id == dato1) &&
                             (a.Nombre.Contains(dato2)) && a.Estado == dato4
                             orderby a.Nombre
                             select a).ToList();
                }
                else
                {
                    query = (from a in db.Producto
                             join b in db.Categoria
                             on a.Categoria_Id equals b.Categoria_Id
                             where (dato1 == null || a.Categoria_Id == dato1) &&
                             (a.Nombre.Contains(dato2)) && a.Estado == dato4
                             orderby a.Precio
                             select a).ToList();
                }
            }
            else
            {
                if (dato3 == true)
                {
                    query = (from a in db.Producto
                             join b in db.Categoria
                             on a.Categoria_Id equals b.Categoria_Id
                             where (dato1 == null || a.Categoria_Id == dato1) &&
                             (a.Nombre.Contains(dato2))
                             orderby a.Nombre
                             select a).ToList();
                }
                else
                {
                    query = (from a in db.Producto
                             join b in db.Categoria
                             on a.Categoria_Id equals b.Categoria_Id
                             where (dato1 == null || a.Categoria_Id == dato1) &&
                             (a.Nombre.Contains(dato2))
                             orderby a.Precio
                             select a).ToList();
                }
            }



            return query.ToList();
        }

        public int Modificar(Producto producto)
        {
            throw new NotImplementedException();
        }

    }
}
