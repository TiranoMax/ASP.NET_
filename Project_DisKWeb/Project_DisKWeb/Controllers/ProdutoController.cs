using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_DisKWeb.DAL;
using Project_DisKWeb.Models;

namespace Project_DisKWeb.Controllers
{
    public class ProdutoController : Controller
    {
       
        public ActionResult Index()
        {
            return View(ProdutoDAO.ListProduto());
        }

        // GET: Produto/Create
        public ActionResult CadProduto()
        {
            return View();
        }

      
        [HttpPost]        
        public ActionResult CadProduto([Bind(Include = "ProdutoId,Nome,Categoria,Ano_Lancamento,Autor,Descricao,QTDE_Estoque,Preco_Venda,Preco_Aluguel,Img")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutoDAO.CadProduto(produto);
                
                return RedirectToAction("Index", "Produto"); 
            }
            else
            {
                return View(produto);
            }
        }




        //// GET: Produto/Edit/5
        //public ActionResult Edit(int? id)
        //{
            
        //}

       
        //[HttpPost]
        
        //public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Categoria,Ano_Lancamento,Autor,Descricao,QTDE_Estoque,Preco_Venda,Preco_Aluguel,Img")] Produto produto)
        //{
            
        //}

        //// GET: Produto/Delete/5
        //public ActionResult Delete(int? id)
        //{
        
        //    Produto produto = db.Produtos.Find(id);
          
        //}

        //// POST: Produto/Delete/5
        //[HttpPost]        
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Produto produto = db.Produtos.Find(id);
        //    db.Produtos.Remove(produto);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

       
    }
}
