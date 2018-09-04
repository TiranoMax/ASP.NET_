using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class CompraDAO
    {
        private static Context contexto = SingletonContext.GetInstance();

        public static void CadastrarCompra(Compra Compra)
        {
            
                contexto.Compras.Add(Compra);
                contexto.SaveChanges();

        }


    }
}