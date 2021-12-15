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
    public class CompraRepositorio : ICompraRepositorio
    {
        VentasDbContexto db = new VentasDbContexto();

        public int Agregar(Compra compra)
        {
            db.Compra.Add(compra);
            db.SaveChanges();
            return compra.Id;
        }

        public IEnumerable<Compra> ListarCompras()
        {
            var query = (from c in db.Compra select c);
            return query.ToList();
        }

        public bool Modificar(Compra compra)
        {
            db.Entry(compra).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Compra ObtenerPorId(int id)
        {
            return db.Compra.Find(id);
        }

        public bool Eliminar(int id)
        {
            var compra = db.Compra.Find(id);
            if (compra == null)
            {
                return false;
            }
            db.Compra.Remove(compra);
            db.SaveChanges();
            return true;
        }
    }
}
