using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project_DisKWeb.DAL;
using Project_DisKWeb.Models;

namespace Project_DisKWeb.Controllers
{
    public class UsuariosController : Controller
    {


        #region pagina de login
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Senha")] Usuario usuario)
        {
            usuario = UsuarioDAO.BucarUsuarioPorEmailESenha(usuario);
            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "O e-mail ou senha não coincidem!");
            return View();
        }


        #region pagina Cadastro  user
        public ActionResult CadUser()
        {
            return View();
        }
        #endregion

        #region cadastro de user
        [HttpPost]
        public ActionResult CadUser(Usuario usuario)
        {
            if (ModelState.IsValid)
            {

                if (UsuarioDAO.CadUser(usuario))
                {
                    return RedirectToAction("Login", "Usuarios");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);
            }
            else
            {
                ModelState.AddModelError("", "Não é possivel cadastra um usuario que contenha o mesmo e-mail!");
                return View(usuario);
            }
        }
        #endregion


    }
}
