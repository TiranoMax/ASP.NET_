using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private Context db = new Context();
       
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }
        

        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create([Bind(Include = "UsuarioId,Nome,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
    }
}
