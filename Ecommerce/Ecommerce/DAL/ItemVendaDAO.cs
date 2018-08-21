using Ecommerce.Models;
using System;
using System.Collections.Generic;
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
            contexto.ItemVenda.Add(itemVenda);
            contexto.SaveChanges();
        }
        #endregion

        #region Retornar ItensVenda
        public static List<ItemVenda> BuscarItensPorCartId(String CartId)
        { 
            return contexto.ItemVenda.Include("Produto").Where(x => x.CartId.Equals(CartId)).ToList();
        }
        #endregion

        #region Remover Do Carrinho
        public static void RemoverDoCarrinho(int id)
        {
            contexto.ItemVenda.Remove(ItemVendaDAO.BuscarPorId(id));
            contexto.SaveChanges();
        }
        #endregion

        #region Buscar Por Id
        public static ItemVenda BuscarPorId(int id)
        {
            return contexto.ItemVenda.Find(id);
        }
        #endregion
    }
}