﻿using Ecommerce.DAL;
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
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
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
            ProdutoDAO.AlterarProduto(produtoOriginal);

            return RedirectToAction("Index", "Produto");
        }

    }
}