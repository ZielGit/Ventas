using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Dominio.Modelos
{
    public class CompraDetalles
    {
        // Relación de uno a mucho con compra
        // Atributos
        /*
         * id
         * cantidad
         * precio
         * compra_id
         * producto_id
         */
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
