using System.Data.Entity;


namespace Ecommerce_ASP_NET.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbEcommerce") { }

        //Mapear as classes que vao virar tabela no banco
        public DbSet<Produto> Produtos { get; set; }

    }
}