namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertableEnderecoRemoveUsuarioId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Endereco", "UsaurioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "UsaurioId", c => c.Int(nullable: false));
        }
    }
}
