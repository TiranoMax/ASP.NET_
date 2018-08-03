using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
       private static Context contexto = new Context();

        #region Retornar Produtos
        public static List<Produto> RetornarProdutos()
        {
            return contexto.Produtos.ToList();
        }
        #endregion

        #region Cadastrar Produto
        public static void CadastrarProduto(Produto produto)
        {
            contexto.Produtos.Add(produto);
            contexto.SaveChanges();
        }
        #endregion

        #region RemoverProduto
        public static void RemoverProduto(int id)
        {
            contexto.Produtos.Remove(ProdutoDAO.BuscarProduto(id));
            contexto.SaveChanges();
        }
        #endregion

        #region BuscarProduto
        public static Produto BuscarProduto(int id)
        {
            return contexto.Produtos.Find(id);
        }
        #endregion

        #region AlterarProduto
        public static void AlterarProduto(Produto produto)
        {
            contexto.Entry(produto).State = EntityState.Modified;
            contexto.SaveChanges();
        }
        #endregion
    }
}