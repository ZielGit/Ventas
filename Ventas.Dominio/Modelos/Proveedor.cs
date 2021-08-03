using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Dominio.Modelos
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public virtual List<Producto> Producto { get; set; }
        public virtual List<Compra> Compras { get; set; }
    }
}
