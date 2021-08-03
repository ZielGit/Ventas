using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Dominio.Modelos
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Impuesto { get; set; }
        public decimal total { get; set; }
        // Provider_Id
        public virtual Proveedor Proveedor { get; set; }
        // User_Id
        public virtual List<CompraDetalles> CompraDetalles { get; set; }
    }
}
