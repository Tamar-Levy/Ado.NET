﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString= "data source=srv2\\pupils;initial catalog=MyShop_0331;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            Category category = new Category();
            Product product = new Product();
            //product.readProduct(connectionString);
            category.readCategory(connectionString);
            //category.InsertCategory(connectionString);
            //product.InsertProduct(connectionString);
        }
    }
}
