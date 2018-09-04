using Ecommerce.DAL;
using Ecommerce.Models;
using Ecommerce.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CompraController : Controller
    {
        
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCompra(Compra compra ) 
        {
            CompraDAO.CadastrarCompra(compra);

            Sessao.NovaSessao();

            return RedirectToAction( "Exibicao", "Exibicao", null);
        }
    }
}