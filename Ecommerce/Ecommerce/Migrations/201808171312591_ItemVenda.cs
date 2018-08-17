namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVenda",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        Qtde = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Produto_ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.Produto_ProdutoId, cascadeDelete: true)
                .Index(t => t.Produto_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "Produto_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItemVenda", new[] { "Produto_ProdutoId" });
            DropTable("dbo.ItemVenda");
        }
    }
}
