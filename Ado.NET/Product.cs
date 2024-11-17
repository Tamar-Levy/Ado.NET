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
            int rowsEffact = 0;
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
                rowsEffact++;
                connection.Close();
                Console.WriteLine("DO you want to add Product? y/n");
                string res = Console.ReadLine();
                if (res == "y")
                {
                    InsertProduct(connectionString);
                }
                Console.WriteLine(RowAffected + "  RowAffected");
                rowsEffact = 0;
                return RowAffected;
            }
        }
        public void readProduct(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\\t{2}\\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3],reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
