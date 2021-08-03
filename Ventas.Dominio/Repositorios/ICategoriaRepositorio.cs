using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;

namespace Ventas.Dominio.Repositorios
{
    public interface ICategoriaRepositorio
    {
        //Definiendo el comportamiento de la Entidad Categoria
        
        int Agregar(Categoria categoria);
        bool Modificar(Categoria categoria);
        IEnumerable<Categoria> ListarCategoria();
    }
}



