using Project_DisKWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_DisKWeb.DAL
{
    public class ProdutoDAO
    {
        private static Context ctx = Singleton.GetInstance();
        
        #region Lista Produtos
        public static List<Produto> ListProduto()
        {
            return ctx.Produtos.ToList();
        }
        #endregion

        #region  Cadastra Produto
        public static void CadProduto(Produto produto)
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChanges();
        }
        #endregion

    }
}