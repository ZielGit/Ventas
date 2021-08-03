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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {

        VentasDbContexto db = new VentasDbContexto();

        public int Agregar(Categoria categoria)
        {
            //agregando la entidad en el contexto de EF
            db.Categoria.Add(categoria);
            //Persiste la infomación de la entidad en base de datos.
            db.SaveChanges();
            return categoria.Categoria_Id;
        }
        
        public IEnumerable<Categoria> ListarCategoria()
        {
            //COnsulta Linq --parecido--> Lenguaje Transact SQL
            // tipo de datos  int codigo, string nombre List<>
            var query  = (from p in db.Categoria select p);
            return query.ToList();
        }

        public bool Modificar(Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

    }
}
