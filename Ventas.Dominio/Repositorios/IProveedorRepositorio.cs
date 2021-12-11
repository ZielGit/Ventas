using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;

namespace Ventas.Dominio.Repositorios
{
    public interface IProveedorRepositorio
    {
        int Agregar(Proveedor proveedor);
        bool Modificar(Proveedor proveedor);
        IEnumerable<Proveedor> ListarProveedores();
        Proveedor ObtenerPorId(int id);
        bool Eliminar(int id);
    }
}
