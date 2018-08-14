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
        public ActionResult Exibicao()
        {
            return View(ProdutoDAO.RetornarProdutos());

        }

        public ActionResult Descricao(int id)
        {
            ViewBag.Mostrar = ProdutoDAO.BuscarProduto(id);
            return View();
        }
    }
}