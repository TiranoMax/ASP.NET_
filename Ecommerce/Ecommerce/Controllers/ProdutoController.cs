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
            ViewBag.Produtos = ProdutoDAO.RetornarProdutos();// lista tudo jogando para uma viewBag
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = new Models.Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };
            ProdutoDAO.CadastrarProduto(produto);

            return RedirectToAction("Index", "Produto");
        }

        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);
            
            return RedirectToAction("Index","Produto");
        }

        public ActionResult AlterarProduto(int id) 
        {
            ViewBag.Produto = ProdutoDAO.BuscarProduto(id);
            return View();
        }

        [HttpPost]
        public ActionResult AlterarProduto(int txtId,string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {

            Produto produto = ProdutoDAO.BuscarProduto(txtId);

            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            //contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified; ou
            ProdutoDAO.AlterarProduto(produto);

            return RedirectToAction("Index", "Produto");
        }

    }
}