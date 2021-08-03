using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Dominio.Modelos
{
    public class Categoria
    {
        // Opcional, puedo poner id o IdCategoria <- que se encuentra en la entidad Producto pero el campo se crea automatico.
        // asi que depende como quieren hacer la referencia, por el momento comentare IdCategoria en la entidad Producto, ya que se crea automatico.
        [Key]
        public int Categoria_Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public virtual List<Producto> Productos { get; set; }
    }
}
