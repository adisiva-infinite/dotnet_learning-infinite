using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assesment_3
{
    class Stored_procedure
    {
        public static SqlConnection conn;
        public static SqlCommand cmd ;
        public static IDataReader dr;
        static void Main(string[] args)
        {
            insert();
            Console.Read();
        }

        static SqlConnection Connection()
        {
            // Step 1 Connect to database
            conn = new SqlConnection("Data Source=ICS-LT-D244D6BT;Initial Catalog=Assesment_1;" +
                "Integrated Security=true;");
            Console.WriteLine("Connected to a database:");
            // Step 2 open the connection 
            conn.Open();
            return conn;
        }
        static void insert()
        {
            try
            {
                Connection();
                Console.WriteLine("Connected to database...");

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Getting user input for the parameters
                Console.Write("Enter Product name : ");
                string Pname = Console.ReadLine();

                Console.Write("Enter the Product price : ");
                int P_price = Convert.ToInt32(Console.ReadLine());


                // inserting values into ProductsDetails

                cmd = new SqlCommand("insert into ProductsDetails values(@product_name,@product_price)", conn);
                Console.WriteLine();
                Console.WriteLine("Query Executed...");

                cmd.Parameters.AddWithValue("@product_name", Pname);
                cmd.Parameters.AddWithValue("product_price", P_price);

                int result = cmd.ExecuteNonQuery();

                if(result>0)
                {
                    Console.WriteLine();
                    Console.WriteLine("*** Product Details inserted Successfully ***");

                    cmd = new SqlCommand("Select * from ProductsDetails", conn);
                    Console.WriteLine("Command is executed:");
                    // printing the result using IDataReader
                    dr = cmd.ExecuteReader();
                    Console.WriteLine("Data is retriving:");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]}");
                    }

                }
                else Console.WriteLine("Product details not inserted");
            }
            catch (Exception product)
            {
                Console.WriteLine($"Error {product.Message}");
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
