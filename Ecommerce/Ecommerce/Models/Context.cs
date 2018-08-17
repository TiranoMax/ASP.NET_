using System.Data.Entity;


namespace Ecommerce.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbEcommerce") { }

        //Mapear as classes que vao virar tabela no banco
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }

    }
}