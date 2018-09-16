namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedAttributeTypesProduto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Preco_Venda", c => c.Double(nullable: false));
            AlterColumn("dbo.Produto", "Preco_Aluguel", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Preco_Aluguel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Produto", "Preco_Venda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
