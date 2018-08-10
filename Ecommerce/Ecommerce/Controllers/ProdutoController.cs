using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(ProdutoDAO.RetornarProdutos());
        }

        public ActionResult CadastrarProduto()
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategorias(), "CategoriaId", "NomeCategoria");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (ProdutoDAO.CadastrarProduto(produto))
                {
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possivel adicionar um produto com mesmo nome!");
                    return View(produto);
                }

            }
            else
            {
                return View(produto);
            }
        }

        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);

            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int id)
        {
            return View(ProdutoDAO.BuscarProduto(id));
        }

        [HttpPost]
        public ActionResult AlterarProduto(Produto produtoAlterado)
        {

            Produto produtoOriginal = ProdutoDAO.BuscarProduto(produtoAlterado.ProdutoId);

            produtoOriginal.Nome = produtoAlterado.Nome;
            produtoOriginal.Descricao = produtoAlterado.Descricao;
            produtoOriginal.Preco = produtoAlterado.Preco;
            produtoOriginal.Categoria = produtoAlterado.Categoria;

            //contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified; ou

            if (ModelState.IsValid)
            {
                if (ProdutoDAO.AlterarProduto(produtoOriginal))
                {
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possivel modificar, devido ja existir um produto com o mesmo nome!");
                    return View(produtoOriginal);
                }
            }
            else
            {
                return View(produtoOriginal);
            }
        }

    }
}