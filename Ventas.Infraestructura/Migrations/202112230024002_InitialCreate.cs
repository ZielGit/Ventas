namespace Ventas.Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Categoria_Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Categoria_Id = c.Int(nullable: false),
                        Proveedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id, cascadeDelete: true)
                .ForeignKey("dbo.Proveedor", t => t.Proveedor_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Proveedor_Id);
            
            CreateTable(
                "dbo.CompraDetalles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Compra_Id = c.Int(),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compra", t => t.Compra_Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Id)
                .Index(t => t.Compra_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCompra = c.DateTime(nullable: false),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Proveedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proveedor", t => t.Proveedor_Id)
                .Index(t => t.Proveedor_Id);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        RUC = c.String(),
                        Direccion = c.String(),
                        Email = c.String(),
                        Celular = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VentaDetalles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Producto_Id = c.Int(),
                        Venta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Id)
                .ForeignKey("dbo.Venta", t => t.Venta_Id)
                .Index(t => t.Producto_Id)
                .Index(t => t.Venta_Id);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaVenta = c.DateTime(nullable: false),
                        impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Ciudad = c.String(),
                        DNI = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VentaDetalles", "Venta_Id", "dbo.Venta");
            DropForeignKey("dbo.Venta", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.VentaDetalles", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.CompraDetalles", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.Producto", "Proveedor_Id", "dbo.Proveedor");
            DropForeignKey("dbo.Compra", "Proveedor_Id", "dbo.Proveedor");
            DropForeignKey("dbo.CompraDetalles", "Compra_Id", "dbo.Compra");
            DropForeignKey("dbo.Producto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Venta", new[] { "Cliente_Id" });
            DropIndex("dbo.VentaDetalles", new[] { "Venta_Id" });
            DropIndex("dbo.VentaDetalles", new[] { "Producto_Id" });
            DropIndex("dbo.Compra", new[] { "Proveedor_Id" });
            DropIndex("dbo.CompraDetalles", new[] { "Producto_Id" });
            DropIndex("dbo.CompraDetalles", new[] { "Compra_Id" });
            DropIndex("dbo.Producto", new[] { "Proveedor_Id" });
            DropIndex("dbo.Producto", new[] { "Categoria_Id" });
            DropTable("dbo.Cliente");
            DropTable("dbo.Venta");
            DropTable("dbo.VentaDetalles");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Compra");
            DropTable("dbo.CompraDetalles");
            DropTable("dbo.Producto");
            DropTable("dbo.Categoria");
        }
    }
}
