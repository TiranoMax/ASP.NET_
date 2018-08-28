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
        private static Context contexto = SingletonContext.GetInstance();

        #region Retornar Produtos
        public static List<Produto> RetornarProdutos()
        {
            return contexto.Produtos.Include("Categoria").ToList();
        }
        #endregion

        #region Cadastrar Produto
        public static bool CadastrarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Buscar produto por categoria
        public static List<Produto> BuscarPorCategoria(int? id)
        {
            return contexto.Produtos.Include("Categoria").Where(x => x.Categoria.CategoriaId == id).ToList();
        }
        #endregion

        #region BuscarProdutoPorNome
        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return contexto.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
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
        public static bool AlterarProduto(Produto produto)
        {
            if (contexto.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome) && x.ProdutoId != produto.ProdutoId) == null)
            {
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;

        }
        #endregion
    }
}