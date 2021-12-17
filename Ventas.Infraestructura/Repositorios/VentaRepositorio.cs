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
    public class VentaRepositorio : IVentaRepositorio
    {
        VentasDbContexto db = new VentasDbContexto();

        public int Agregar(Venta venta)
        {
            db.Venta.Add(venta);
            db.SaveChanges();
            return venta.Id;
        }

        public IEnumerable<Venta> ListarVentas()
        {
            var query = (from v in db.Venta select v);
            return query.ToList();
        }

        public bool Modificar(Venta venta)
        {
            db.Entry(venta).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Venta ObtenerPorId(int id)
        {
            return db.Venta.Find(id);
        }

        public bool Eliminar(int id)
        {
            var venta = db.Venta.Find(id);
            if (venta == null)
            {
                return false;
            }
            db.Venta.Remove(venta);
            db.SaveChanges();
            return true;
        }
    }
}
