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
    public class UsuariosController : Controller
    {


        #region pagina de login
        public ActionResult Login()
        {
            return View();
        }
        #endregion


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
                UsuarioDAO.CadUser(usuario);

                ViewBag.test = usuario.UsuarioId;
                return RedirectToAction("CadEndereco", "Usuario");

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
