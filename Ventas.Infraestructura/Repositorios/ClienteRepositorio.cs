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
    public class ClienteRepositorio : IClientrRepositorio
    {
        VentasDbContexto db = new VentasDbContexto();

        public int Agregar(Cliente cliente)
        {
            //agregando la entidad en el contexto de EF
            db.Cliente.Add(cliente);
            //Persiste la infomación de la entidad en base de datos.
            db.SaveChanges();
            return cliente.Id;
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            //COnsulta Linq --parecido--> Lenguaje Transact SQL
            // tipo de datos  int codigo, string nombre List<>
            var query = (from p in db.Cliente
                         select p);

            return query.ToList();
        }

        public bool Modificar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
