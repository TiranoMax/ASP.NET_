namespace Project_DisKWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertableenderecoRetiradoRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Endereco", "CEP", c => c.String());
            AlterColumn("dbo.Endereco", "Logradouro", c => c.String());
            AlterColumn("dbo.Endereco", "Bairro", c => c.String());
            AlterColumn("dbo.Endereco", "Localidade", c => c.String());
            AlterColumn("dbo.Endereco", "UF", c => c.String());
            AlterColumn("dbo.Endereco", "Complemento", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Endereco", "Complemento", c => c.String(maxLength: 30));
            AlterColumn("dbo.Endereco", "UF", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Endereco", "Localidade", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Endereco", "Bairro", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Endereco", "Logradouro", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Endereco", "CEP", c => c.String(nullable: false, maxLength: 7));
        }
    }
}
