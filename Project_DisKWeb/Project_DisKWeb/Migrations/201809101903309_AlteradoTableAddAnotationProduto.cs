namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteradoTableAddAnotationProduto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Produto", "Categoria", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Produto", "Autor", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Autor", c => c.String());
            AlterColumn("dbo.Produto", "Categoria", c => c.String());
            AlterColumn("dbo.Produto", "Nome", c => c.String());
        }
    }
}
