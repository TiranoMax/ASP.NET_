using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAL;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class ExibicaoController : Controller
    {
        private static Context contexto = SingletonContext.GetInstance();

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
                return View(BuscarPorCategoria(CatId));
            }

        }

        private static List<Produto> BuscarPorCategoria(int? id)
        {
            return contexto.Produtos.Include("Categoria").Where(x => x.Categoria.CategoriaId == id).ToList();
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
                Data = DateTime.Now
            };
            ItemVendaDAO.AdicionarAoCarrinho(itemVenda);
            return RedirectToAction("CarrinhoCompras","Exibicao");
        }

        public ActionResult CarrinhoCompras()
        {
            return View(ItemVendaDAO.RetornarItens());
        }

    }
}