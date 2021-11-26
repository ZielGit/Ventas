using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;

namespace Ventas.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        int Agregar(Cliente cliente);
        bool Modificar(Cliente cliente);
        IEnumerable<Cliente> ListarCliente();
        Cliente ObtenerPorId(int id);
        bool Eliminar(int id);
    }
}
