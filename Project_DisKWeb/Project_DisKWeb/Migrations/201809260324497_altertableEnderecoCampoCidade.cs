namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertableEnderecoCampoCidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Cidade", c => c.String());
            DropColumn("dbo.Endereco", "Localidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "Localidade", c => c.String());
            DropColumn("dbo.Endereco", "Cidade");
        }
    }
}
