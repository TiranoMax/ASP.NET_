﻿using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class SingletonContext
    {
        private static Context ctx;

        private SingletonContext() { }

        public static Context GetInstance()
        {
            if(ctx == null)
            {
                ctx = new Context();
            }
            return ctx;
        }
    }
}