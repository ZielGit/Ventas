using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Dominio.Modelos
{
    public class VentaDetalles
    {
        // Relación de uno a mucho con venta
        // Atributos
        /*
         * id
         * cantidad
         * precio
         * descuento
         * venta_id
         * producto_id
         */
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal descuento { get; set; }
        public virtual Venta Venta { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
