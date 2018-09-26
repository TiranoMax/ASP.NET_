using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(ProdutoDAO.ListProduto());
        }
        #endregion

        #region Chamada View CadProduto
        [Authorize(Roles = "Admin")]
        public ActionResult CadProduto()
        {
            return View();
        }
        #endregion

        #region CadProduto
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CadProduto(Produto produto, HttpPostedFileBase fupImg)
        {
            if (ModelState.IsValid)
            {
                if (fupImg != null)
                {
                    string nomeImagem = Path.GetFileName(fupImg.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Imagem/"), nomeImagem);
                    fupImg.SaveAs(caminho);
                    produto.Img = nomeImagem;
                }
                else
                {
                    produto.Img = "SemImagem.gif";
                }

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
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduto(int id)
        {
            return View(ProdutoDAO.SearchProdutoByID(id));
        }
        #endregion

        #region EditProduto
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditProduto(Produto produtoAlterado, HttpPostedFileBase fupImagem)
        {

            Produto produtoOri = ProdutoDAO.SearchProdutoByID(produtoAlterado.ProdutoId);

            produtoOri.Nome = produtoAlterado.Nome;
            produtoOri.Categoria = produtoAlterado.Categoria;
            produtoOri.Ano_Lancamento = produtoAlterado.Ano_Lancamento;
            produtoOri.Autor = produtoAlterado.Autor;
            produtoOri.Descricao = produtoAlterado.Descricao;
            produtoOri.QTDE_Estoque = produtoAlterado.QTDE_Estoque;
            produtoOri.Preco_Venda = produtoAlterado.Preco_Venda;
            produtoOri.QTDE_Estoque_aluguel = produtoAlterado.QTDE_Estoque_aluguel;
            produtoOri.Preco_Aluguel = produtoAlterado.Preco_Aluguel;


            if (ModelState.IsValid)
            {
                if (fupImagem != null)
                {
                    string nomeImagem = Path.GetFileName(fupImagem.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Imagem/"), nomeImagem);
                    fupImagem.SaveAs(caminho);
                    produtoOri.Img = nomeImagem;
                }

                if (ProdutoDAO.AlterProduto(produtoOri))
                {
                    return RedirectToAction("Index", "Produto");
                }

            }
            return View(produtoOri);

        }
        #endregion

        #region Chamada Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ProdutoDAO.DeleteProduto(id);
            return RedirectToAction("Index", "Produto");
        }
        #endregion

        #region Chamada Pagina Principal De produto nivel Normal
        public ActionResult Home()
        {
            return View(ProdutoDAO.ListProduto());
        }
        #endregion

        #region Detalhes nivel normal
        public ActionResult Detalhes(int id)
        {
            ViewBag.Mostrar = ProdutoDAO.SearchProdutoByID(id);
            return View();
        } 
        #endregion


    }
}