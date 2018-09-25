namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableEnderecoAddUsuarioId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "UsaurioId", c => c.Int(nullable: false));
            AddColumn("dbo.Endereco", "Usuario_UsuarioId", c => c.Int());
            CreateIndex("dbo.Endereco", "Usuario_UsuarioId");
            AddForeignKey("dbo.Endereco", "Usuario_UsuarioId", "dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "Usuario_UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Endereco", new[] { "Usuario_UsuarioId" });
            DropColumn("dbo.Endereco", "Usuario_UsuarioId");
            DropColumn("dbo.Endereco", "UsaurioId");
        }
    }
}
