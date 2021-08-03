using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;

namespace Ventas.Dominio.Repositorios
{
    public interface IProductoRepositorio
    {
        int Agregar(Producto producto);
        int Modificar(Producto producto);
        IEnumerable<Producto> ListarProductos();
        IEnumerable<Producto> ListarProductos(int? dato1, string dato2, bool? dato3, bool? dato4);
        
        

    }
}
