using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;

namespace Ventas.Dominio.Repositorios
{
    public interface ICompraRepositorio
    {
        int Agregar(Compra compra);
        bool Modificar(Compra compra);
        IEnumerable<Compra> ListarCompras();
        Compra ObtenerPorId(int id);
        bool Eliminar(int id);
    }
}
