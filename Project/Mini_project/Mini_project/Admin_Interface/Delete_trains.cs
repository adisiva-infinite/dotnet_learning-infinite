using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using System.Data;
using System.Data.SqlClient;

namespace Mini_project.Admin_Interface
{
    class Delete_trains : IAdmin
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;
        public void Admin_Inputs()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***   Delete train details by admin   ***");               
                conn = Database.Connection();
                
                Console.WriteLine();
                Console.Write("Enter Train num for delete : ");
                int num = Convert.ToInt32(Console.ReadLine());

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_deleteTrain", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@trainno", num);

                Console.WriteLine();
                cmd.ExecuteNonQuery();
                Console.WriteLine($" Deleting {num} train details ");
                Console.WriteLine();
            }
            catch(Exception delete)
            {
                Console.WriteLine($"Update status : {delete.Message}");
            }
        }
    }
}
