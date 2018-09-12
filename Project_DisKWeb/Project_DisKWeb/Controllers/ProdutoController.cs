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
        #region Index
        public ActionResult Index()
        {
            return View(ProdutoDAO.ListProduto());
        }
        #endregion

        #region Chamada View CadProduto
        public ActionResult CadProduto()
        {
            return View();
        }
        #endregion

        #region CadProduto
        [HttpPost]        
        public ActionResult CadProduto([Bind(Include = "ProdutoId,Nome,Categoria,Ano_Lancamento,Autor,Descricao,QTDE_Estoque,Preco_Venda,QTDE_Estoque_aluguel,Preco_Aluguel,Img")] Produto produto)
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
        #endregion

        #region Chamada View EditProduto
        public ActionResult EditProduto(int id)
        {
            return View(ProdutoDAO.SearchProdutoByID(id)); 
        }
        #endregion


        #region EditProduto
        [HttpPost]
        public ActionResult EditProduto([Bind(Include = "ProdutoId,Nome,Categoria,Ano_Lancamento,Autor,Descricao,QTDE_Estoque,Preco_Venda,Preco_Aluguel,Img")] Produto produto)
        {
            return View(); 
        }
        #endregion

        #region Chamada Delete
        public ActionResult Delete(int id)
        {
            ProdutoDAO.DeleteProduto(id);
            return RedirectToAction("Index", "Produto");
        }
        #endregion

    }
}