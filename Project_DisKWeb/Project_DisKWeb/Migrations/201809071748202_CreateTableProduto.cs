namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria = c.String(),
                        Ano_Lancamento = c.DateTime(nullable: false),
                        Autor = c.String(),
                        Descricao = c.String(),
                        QTDE_Estoque = c.Int(nullable: false),
                        Preco_Venda = c.Double(nullable: false),
                        Preco_Aluguel = c.Double(nullable: false),
                        Img = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produto");
        }
    }
}
