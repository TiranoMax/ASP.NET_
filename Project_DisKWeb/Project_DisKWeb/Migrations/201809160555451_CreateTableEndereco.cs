namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableEndereco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        CEP = c.String(nullable: false, maxLength: 7),
                        Logradouro = c.String(nullable: false, maxLength: 100),
                        Bairro = c.String(nullable: false, maxLength: 80),
                        Localidade = c.String(nullable: false, maxLength: 80),
                        UF = c.String(nullable: false, maxLength: 2),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Endereco");
        }
    }
}
