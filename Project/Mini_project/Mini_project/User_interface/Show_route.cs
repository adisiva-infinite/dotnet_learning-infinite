using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using Mini_project.GatewaytoUser_Admin;
using System.Data;
using System.Data.SqlClient;

namespace Mini_project.User_interface
{
    class Show_route : IUser
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;

        public void User_inputs()
        {
            try
            {
                conn = Database.Connection();
                Console.WriteLine();
                Console.WriteLine("***   Displaying all Trains Source and Destination Details to User   ***");
                Console.WriteLine();

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_route", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();
                //Console.WriteLine();
               

                while(dr.Read())
                {
                    Console.WriteLine($" {dr[0]} ---------> {dr[1]} ");
                }
                dr.Close();
            }
            catch (Exception route)
            {
                Console.WriteLine(route.Message);
            }
            finally
            {
                ITrainFactory Trainfactory;
                Trainfactory = new UserFactory();
                IUser userPerform = Trainfactory.CreateUser(); // Get the user actions
                userPerform.User_inputs();
                conn.Close();
            }
        }
    }
}
