using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Dominio.Modelos
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        // client_id
        public virtual Cliente Cliente { get; set; }
        // user_id
        public virtual List<VentaDetalles> VentaDetalles { get; set; }
    }
}
