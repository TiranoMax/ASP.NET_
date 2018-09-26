namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertableEnderecoCampoEstado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Estado", c => c.String());
            DropColumn("dbo.Endereco", "UF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "UF", c => c.String());
            DropColumn("dbo.Endereco", "Estado");
        }
    }
}
