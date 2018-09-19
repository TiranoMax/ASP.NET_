namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteradoBancoUsuarioEndereco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Endereco", "Usuario_UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Endereco", new[] { "Usuario_UsuarioId" });
            DropColumn("dbo.Endereco", "Usuario_UsuarioId");
            DropColumn("dbo.Usuario", "EnderecoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "EnderecoId", c => c.Int(nullable: false));
            AddColumn("dbo.Endereco", "Usuario_UsuarioId", c => c.Int());
            CreateIndex("dbo.Endereco", "Usuario_UsuarioId");
            AddForeignKey("dbo.Endereco", "Usuario_UsuarioId", "dbo.Usuario", "UsuarioId");
        }
    }
}
