using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Dominio.Modelos;


namespace Ventas.Infraestructura.Repositorios.Base
{
    public class VentasDbContexto : DbContext
    {
        public VentasDbContexto() : base("name=cadenaVentasNube")
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Proveedor> Proveedore { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<CompraDetalles> CompraDetalles { get; set; }
        // llamar a las entidades detalles si es necesario

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
