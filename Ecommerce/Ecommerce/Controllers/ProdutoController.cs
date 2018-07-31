using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        Context contexto = new Context();
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = contexto.Produtos.ToList();
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

            contexto.Produtos.Add(produto);
            contexto.SaveChanges();

            return RedirectToAction("Index", "Produto");
        }

    }
}