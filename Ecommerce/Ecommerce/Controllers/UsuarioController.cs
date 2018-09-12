using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ecommerce.DAL;
using Ecommerce.Models;
using Newtonsoft.Json;

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
            if(TempData["Mensagem"]!= null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View((Usuario)TempData["Usuario"]);
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "UsuarioId,Nome,Email,Senha,ConfirmeSenha,Logradouro,UF,Cep,Bairro,Localidade")] Usuario usuario)
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Senha")] Usuario usuario)
        {
            usuario = UsuarioDAO.BucarUsuarioPorEmailESenha(usuario);
            if(usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "O e-mail ou senha não coincidem!");
            return View();
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Exibicao", "Exibicao");
        }

        [HttpPost]
        public ActionResult PesquisarCep(Usuario usuario)
        {
            try
            {
                //Download da string em jason
                string url = "https://viacep.com.br/ws/" + usuario.Cep + "/json/";
                WebClient client = new WebClient();
                string json = client.DownloadString(url);

                //converter a string para utf-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);

                //converter o json para objeto
                usuario = JsonConvert.DeserializeObject<Usuario>(json);

                //passar informação para qualquer action do controller
                TempData["Usuario"] = usuario;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP inválido!";
               
            }

            return RedirectToAction("Create", "Usuario");
        }
    }
}
