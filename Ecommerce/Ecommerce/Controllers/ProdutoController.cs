using Ecommerce.Models;
using System;
using System.Data.Entity;
using System.Linq;
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
            ViewBag.Produtos = contexto.Produtos.ToList();// lista tudo jogando para uma viewBag
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
        public ActionResult RemoverProduto(int id)
        {
            Produto p = contexto.Produtos.Find(id);

            contexto.Produtos.Remove(p);
            contexto.SaveChanges();
            
            return RedirectToAction("Index","Produto");
        }

     
        public ActionResult AlterarProduto(int id) 
        {
            ViewBag.Produto = contexto.Produtos.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult AlterarProduto(int txtId,string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {

            Produto produto = contexto.Produtos.Find(txtId);

            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            //contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified; ou
            contexto.Entry(produto).State = EntityState.Modified;
            contexto.SaveChanges();

            return RedirectToAction("Index", "Produto");
        }

    }
}