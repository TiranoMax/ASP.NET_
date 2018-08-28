using Ecommerce.Models;
using Ecommerce.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class ItemVendaDAO
    {
        private static Context contexto = SingletonContext.GetInstance();

        #region Adicionar Ao Carrinho
        public static void AdicionarAoCarrinho(ItemVenda itemVenda)
        {
            string Cart = Sessao.RetornarCarrinhoId();

            ItemVenda item = contexto.ItemVenda.Include("Produto").FirstOrDefault(x => x.Produto.ProdutoId == itemVenda.Produto.ProdutoId && x.CartId.Equals(Cart));

            if (item == null)
            {
                contexto.ItemVenda.Add(itemVenda);
            }
            else
            {
                item.Qtde++;
            }
            contexto.SaveChanges();
        }
        #endregion

        #region Retornar ItensVenda
        public static List<ItemVenda> BuscarItensPorCartId()
        {
            string CartId = Sessao.RetornarCarrinhoId();
            return contexto.ItemVenda.Include("Produto").Where(x => x.CartId.Equals(CartId)).ToList();
        }
        #endregion

        #region Remover Do Carrinho
        public static void RemoverDoCarrinho(int id)
        {
            ItemVenda item = contexto.ItemVenda.Find(id);

            if (item.Qtde > 1)
            {
                item.Qtde--;
            }
            else
            {
                contexto.ItemVenda.Remove(item);
            }
            contexto.SaveChanges();
        }
        #endregion

        #region Buscar Por Id
        public static ItemVenda BuscarPorId(int id)
        {
            return contexto.ItemVenda.Find(id);
        }
        #endregion

        #region Aumentar item do carrinho

        public static void AumentarItemCart(int id)
        {
            ItemVenda item = contexto.ItemVenda.Find(id);
            item.Qtde++;
            contexto.SaveChanges();
        }
        #endregion

        #region diminuir item do carrinho
        public static void DiminuirItemCart(int id)
        {
            ItemVenda item = contexto.ItemVenda.Find(id);
            if (item.Qtde > 1)
            {
                item.Qtde--;
                contexto.SaveChanges();
            }
        }
        #endregion

        #region TotalCart
        public static double TotalCart()
        {
            return BuscarItensPorCartId().Sum(x => x.Qtde * x.Preco);
        }
        #endregion

        #region Quantidade itens no cart
        public static double QtdeItensCart()
        {
            return BuscarItensPorCartId().Sum(x => x.Qtde);
        }
        #endregion 

    }
}