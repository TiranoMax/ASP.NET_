using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DisKWeb.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbDisKWeb") { }

        public DbSet<Produto> Produtos { get; set; }
    }
}