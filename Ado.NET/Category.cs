using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Collections;

namespace Ado.NET
{
    internal class Category
    {
        int rowsEffact = 0;
        public void InsertCategory(string connectionString) {
            
            string Category_Name;
            Console.WriteLine("insert CategoryName");
            Category_Name = Console.ReadLine();

            string query = "INSERT INTO Categories(Category_Name)" + "VALUES(@Category_Name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Category_Name", SqlDbType.VarChar, 50).Value = Category_Name;
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                rowsEffact++;
                connection.Close();

                Console.WriteLine("DO you want to add category? y/n");
                string res = Console.ReadLine();
                if (res == "y")
                {
                    InsertCategory(connectionString);
                }
                else { 
                Console.WriteLine(rowsEffact + "  RowAffected");
                    rowsEffact = 0;
                }
            }
       }
        public void readCategory(string connectionString)
        {
            string queryString = "select * from Categories";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }


        }

}
