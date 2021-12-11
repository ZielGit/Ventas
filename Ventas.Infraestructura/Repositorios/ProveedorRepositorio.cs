using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;
using Ventas.Dominio.Repositorios;
using Ventas.Infraestructura.Repositorios.Base;

namespace Ventas.Infraestructura.Repositorios
{
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        VentasDbContexto db = new VentasDbContexto();

        public int Agregar(Proveedor proveedor)
        {
            db.Proveedor.Add(proveedor);
            db.SaveChanges();
            return proveedor.Id;
        }

        public IEnumerable<Proveedor> ListarProveedores()
        {
            var query = (from p in db.Proveedor select p);
            return query.ToList();
        }

        public bool Modificar(Proveedor proveedor)
        {
            db.Entry(proveedor).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Proveedor ObtenerPorId(int id)
        {
            return db.Proveedor.Find(id);
        }

        public bool Eliminar(int id)
        {
            var proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return false;
            }
            db.Proveedor.Remove(proveedor);
            db.SaveChanges();
            return true;
        }
    }
}
