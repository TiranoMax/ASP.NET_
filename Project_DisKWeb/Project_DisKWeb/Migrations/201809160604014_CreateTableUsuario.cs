namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 45),
                        Cpf = c.String(nullable: false, maxLength: 13),
                        Email = c.String(nullable: false, maxLength: 100),
                        Nascimento = c.DateTime(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 60),
                        NivelAdmin = c.String(),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            AddColumn("dbo.Endereco", "Usuario_UsuarioId", c => c.Int());
            CreateIndex("dbo.Endereco", "Usuario_UsuarioId");
            AddForeignKey("dbo.Endereco", "Usuario_UsuarioId", "dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "Usuario_UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Endereco", new[] { "Usuario_UsuarioId" });
            DropColumn("dbo.Endereco", "Usuario_UsuarioId");
            DropTable("dbo.Usuario");
        }
    }
}
