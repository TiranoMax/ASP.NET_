namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Cep", c => c.String());
            AddColumn("dbo.Usuarios", "Logradouro", c => c.String());
            AddColumn("dbo.Usuarios", "Bairro", c => c.String());
            AddColumn("dbo.Usuarios", "Localidade", c => c.String());
            AddColumn("dbo.Usuarios", "UF", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "UF");
            DropColumn("dbo.Usuarios", "Localidade");
            DropColumn("dbo.Usuarios", "Bairro");
            DropColumn("dbo.Usuarios", "Logradouro");
            DropColumn("dbo.Usuarios", "Cep");
        }
    }
}
