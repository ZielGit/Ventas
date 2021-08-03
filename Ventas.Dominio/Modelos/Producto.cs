using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Dominio.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        // si quieren descomentar IdCategoria tendran que cambiar en el modulo categoria el campo Id por IdCategoria
        // si no lo hacen se creara dos campos IdCategoria y Categoria_Id, sino dejarlo como esta.
        // public int IdCategoria { get; set; }
        public int Categoria_Id { get; set; }
        // Proveedor_Id
        public virtual Categoria Categoria { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        // compradetalle
        public virtual List<CompraDetalles> CompraDetalles { get; set; }
        public virtual List<VentaDetalles> VentaDetalles { get; set; }
    }
}
