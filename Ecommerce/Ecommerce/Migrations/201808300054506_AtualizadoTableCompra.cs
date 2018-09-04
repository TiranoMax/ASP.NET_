namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadoTableCompra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        CompraId = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(),
                        EnderecoCliente = c.String(),
                        TelCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompraId);
            
            AddColumn("dbo.ItemVenda", "Compra_CompraId", c => c.Int());
            CreateIndex("dbo.ItemVenda", "Compra_CompraId");
            AddForeignKey("dbo.ItemVenda", "Compra_CompraId", "dbo.Compra", "CompraId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "Compra_CompraId", "dbo.Compra");
            DropIndex("dbo.ItemVenda", new[] { "Compra_CompraId" });
            DropColumn("dbo.ItemVenda", "Compra_CompraId");
            DropTable("dbo.Compra");
        }
    }
}
