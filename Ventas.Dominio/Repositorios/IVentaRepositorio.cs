using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;

namespace Ventas.Dominio.Repositorios
{
    public interface IVentaRepositorio
    {
        int Agregar(Venta venta);
        bool Modificar(Venta venta);
        IEnumerable<Venta> ListarVentas();
        Venta ObtenerPorId(int id);
        bool Eliminar(int id);
    }
}
