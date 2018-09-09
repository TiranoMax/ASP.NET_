using Project_DisKWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        #region Busca Produto pelo ID 
        public static Produto SearchProdutoByID(int Id)
        {
            return ctx.Produtos.Find(Id);
        }
        #endregion
        
        #region Alterar Produto
        public static bool AlterProduto(Produto produto)
        {
            if(ctx.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome) && x.ProdutoId.Equals(produto.ProdutoId)) == null)
            {
                ctx.Entry(produto).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Excluir Produto
        public static void DeleteProduto(int Id)
        {
            ctx.Produtos.Remove(ProdutoDAO.SearchProdutoByID(Id));
            ctx.SaveChanges();
        }
        #endregion

    }
}