using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using Mini_project.GatewaytoUser_Admin;
using System.Data;
using System.Data.SqlClient;

namespace Mini_project.Admin_Interface
{
    class Modify_train : IAdmin
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;
        public void Admin_Inputs()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***   Update train details by admin   ***");
                conn = Database.Connection();

                Console.WriteLine();
                Console.Write("Enter train number : ");
                int T_num = Convert.ToInt32(Console.ReadLine());

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_modify", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@train_id", T_num);
                dr = cmd.ExecuteReader();
                dr.Close();

                Console.Write("Enter Source Point : ");
                string T_start = Console.ReadLine();

                Console.Write("Enter Destination Point : ");
                string T_end = Console.ReadLine();

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_updateTrain", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@trainno", T_num);
                cmd.Parameters.AddWithValue("@from", T_start);
                cmd.Parameters.AddWithValue("@to", T_end);

                Console.WriteLine();
                cmd.ExecuteNonQuery();

            }
            catch(Exception Updatetrain)
            {
                Console.WriteLine($"Update Status : {Updatetrain.Message}");
            }
            finally
            {
                ITrainFactory Trainfactory;
                Trainfactory = new AdminFactory();
                IAdmin adminPerform = Trainfactory.CreateAdmin(); // Get the admin actions
                adminPerform.Admin_Inputs();
                conn.Close();
            }
        }
    }
}
