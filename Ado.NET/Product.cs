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
        int rowsEffact = 0;
        public int InsertProduct(string connectionString)
        { 
            string Product_Name, Category_Id, Price, Description;
            Console.WriteLine("insert ProductName");
            Product_Name = Console.ReadLine();
            Console.WriteLine("insert Price");
            Price = Console.ReadLine();
            Console.WriteLine("insert Category_Id");
            Category_Id = Console.ReadLine();
            Console.WriteLine("insert Description");
            Description = Console.ReadLine();

            string query = "INSERT INTO Products(Product_Name,Price,Category_Id,Description)" + "VALUES(@Product_Name,@Price,@Category_Id,@Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Product_Name", SqlDbType.VarChar, 50).Value = Product_Name;
                command.Parameters.Add("@Price", SqlDbType.VarChar, 50).Value = Price;
                command.Parameters.Add("@Category_Id", SqlDbType.Int).Value = Category_Id;
                command.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = Description;
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
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3],reader[4]);
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
