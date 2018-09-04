using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Usuario> RetornarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }

        public static bool CadastrarUsuario(Usuario usuario)
        {
            if(BuscarUsuarioPorEmail(usuario) == null)
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
                return true;
            }
            return false;
            
        }

        public static Usuario BuscarUsuarioPorEmail(Usuario usuario)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email));
        }

    }
}