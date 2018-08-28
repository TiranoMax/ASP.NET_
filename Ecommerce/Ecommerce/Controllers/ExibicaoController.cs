using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAL;
using Ecommerce.Models;
using Ecommerce.Utils;

namespace Ecommerce.Controllers
{
    public class ExibicaoController : Controller
    {

        // GET: Exibicao
        public ActionResult Exibicao(int? CatId)
        {
            ViewBag.Categorias = CategoriaDAO.RetornarCategorias();

            if (CatId == null)
            {
                return View(ProdutoDAO.RetornarProdutos());
            }
            else
            {
                return View(ProdutoDAO.BuscarPorCategoria(CatId));
            }

        }

        public ActionResult Descricao(int id)
        {
            ViewBag.Mostrar = ProdutoDAO.BuscarProduto(id);
            return View();
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto Produto = ProdutoDAO.BuscarProduto(id);

            ItemVenda itemVenda = new ItemVenda
            {
                Produto = Produto,
                Qtde = 1,
                Preco = Produto.Preco,
                Data = DateTime.Now,
                CartId = Sessao.RetornarCarrinhoId()
            };
            ItemVendaDAO.AdicionarAoCarrinho(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        #region Listar Vendas
        public ActionResult CarrinhoCompras()
        {
            ViewBag.Total = ItemVendaDAO.TotalCart();
            return View(ItemVendaDAO.BuscarItensPorCartId());
        }
        #endregion

        public ActionResult RemovendoItem(int id)
        {
            ItemVendaDAO.RemoverDoCarrinho(id);
            return RedirectToAction("CarrinhoCompras", "Exibicao");
        }

        public ActionResult AdicionarItem(int id)
        {
            ItemVendaDAO.AumentarItemCart(id);
            return RedirectToAction("CarrinhoCompras", "Exibicao");
        }

        public ActionResult DiminuirItem(int id)
        {
            ItemVendaDAO.DiminuirItemCart(id);
            return RedirectToAction("CarrinhoCompras", "Exibicao");
        }

    }
}