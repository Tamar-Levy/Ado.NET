using System;
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
            string connectionString= "data source=srv2\\pupils;initial catalog=MyShop;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            Category category = new Category();
            Product product = new Product();
            category.InsertCategory(connectionString);
            product.InsertProduct(connectionString);
        }
    }
}
