using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Ado.NET
{
    internal class Category
    {
        public int InsertCategory(string connectionString) {
            Console.WriteLine("DO you want to add category? y/n");
            string res=Console.
            string Name;
        Console.WriteLine("insert CategoryName");
            Name = Console.ReadLine();

            string query = "INSERT INTO Category(Name)" + "VALUES(@Name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Name",SqlDbType.VarChar, 50).Value = Name;
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                connection.Close();

                return RowAffected;
            }
       }

         
        //private static void CreateCommand(string queryString,string connectionString)
        //{
        //    using (SqlConnection connection=new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}
