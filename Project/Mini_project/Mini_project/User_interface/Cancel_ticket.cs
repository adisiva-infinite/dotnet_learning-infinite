using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using System.Data;
using System.Data.SqlClient;

namespace Mini_project.User_interface
{
    class Cancel_ticket : IUser
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;
        public void User_inputs()
        {
            try
            {
                Console.WriteLine("***   Cancel ticket by user   ***");
                conn = Database.Connection();

                Console.WriteLine();
                Console.Write("Enter your PNR number : ");
                int pnr = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("sp_Cancelticket", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pnr", pnr);

                Console.WriteLine();
                cmd.ExecuteNonQuery();
            }
            catch (Exception cancel)
            {
                Console.WriteLine($"Cancelling Status : {cancel.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
