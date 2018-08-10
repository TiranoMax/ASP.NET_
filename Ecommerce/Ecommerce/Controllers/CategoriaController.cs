using Ecommerce.DAL;
using Ecommerce.Models;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View(CategoriaDAO.RetornarCategorias());
        }

        public ActionResult CadastrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (CategoriaDAO.CadastrarCategoria(categoria))
                {
                    return RedirectToAction("Index", "Produto"); //modificar
                }
                else
                {
                    ModelState.AddModelError("", "Não é possivel adicionar uma categoria com um mesmo nome!");
                    return View(categoria);
                }
            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult RemoverCategoria(int id)
        {
            CategoriaDAO.RemoverCategoria(id);

            return RedirectToAction("Index", "Produto");
        }


        public ActionResult AlterarCategoria(int id)
        {
            return View(CategoriaDAO.BuscarCategoria(id));
        }

        [HttpPost]
        public ActionResult AlterarCategoria(Categoria categoriaAlterado)
        {

            Categoria produtoOriginal = CategoriaDAO.BuscarCategoria(categoriaAlterado.CategoriaId);

            produtoOriginal.NomeCategoria = categoriaAlterado.NomeCategoria;
            produtoOriginal.Descricao = categoriaAlterado.Descricao;

            if (ModelState.IsValid)
            {
                if (CategoriaDAO.AlterarCategoria(produtoOriginal))
                {
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possivel modificar, devido ja existir uma Categoria com o mesmo nome!");
                    return View(produtoOriginal);
                }
            }
            else
            {
                return View(produtoOriginal);
            }
        }

    }
}