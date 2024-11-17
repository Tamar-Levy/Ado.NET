using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NET
{
    internal class Product
    {
        public int InsertProduct(string connectionString)
        {
            string Category_Id,Name, Describtion, Price, Image;
            Console.WriteLine("insert CategoryId");
            Category_Id = Console.ReadLine();
            Console.WriteLine("insert ProductName");
            Name = Console.ReadLine();
            Console.WriteLine("insert Describtion");
            Describtion = Console.ReadLine();
            Console.WriteLine("insert Price");
            Price = Console.ReadLine();
            Console.WriteLine("insert Image");
            Image = Console.ReadLine();

            string query = "INSERT INTO Products(Category_Id,Name,Describtion,Price,Image)" + "VALUES(@Category_Id,@Name,@Describtion,@Price,@Image)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Category_Id", SqlDbType.Int).Value = Category_Id;
                command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;
                command.Parameters.Add("@Describtion", SqlDbType.VarChar, 50).Value = Describtion;
                command.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
                command.Parameters.Add("@Image", SqlDbType.VarChar, 50).Value = Image;
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                connection.Close();

                return RowAffected;
            }
        }
    }
}
