using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class CategoriaDAO
    {
        private static Context contexto = new Context();

        public static List<Categoria> RetornarCategorias()
        {
            return contexto.Categorias.ToList();
        }

        public static bool CadastrarCategoria(Categoria categoria)
        {
            if(BuscarCategoriaNome(categoria) == null)
            {
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Categoria BuscarCategoriaNome(Categoria categoria)
        {
            return contexto.Categorias.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria));
        }

        public static void RemoverCategoria(int id)
        {
            contexto.Categorias.Remove(CategoriaDAO.BuscarCategoria(id));
            contexto.SaveChanges();
        }

        public static Categoria BuscarCategoria(int id)
        {
            return contexto.Categorias.Find(id);
        }

        public static bool AlterarCategoria(Categoria categoria)
        {
            if (contexto.Categorias.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria) && x.CategoriaId != categoria.CategoriaId) == null)
            {
                contexto.Entry(categoria).State = EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;

        }
    }
}