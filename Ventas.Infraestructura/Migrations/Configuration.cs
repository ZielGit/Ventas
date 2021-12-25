using System.Data.Entity.Migrations;

namespace Ventas.Infraestructura.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Ventas.Infraestructura.Repositorios.Base.VentasDbContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ventas.Infraestructura.Repositorios.Base.VentasDbContexto";
        }
    }
}
