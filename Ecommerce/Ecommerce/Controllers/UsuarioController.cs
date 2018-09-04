using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAL;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(UsuarioDAO.RetornarUsuarios());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "UsuarioId,Nome,Email,Senha,ConfirmeSenha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioDAO.CadastrarUsuario(usuario))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);
            }
            return View(usuario);
        }
    }
}
