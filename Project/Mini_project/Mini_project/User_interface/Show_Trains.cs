    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using System.Data;
using System.Data.SqlClient;
using Mini_project.GatewaytoUser_Admin;

namespace Mini_project.User_interface
{
    class Show_Trains :IUser
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
                Console.WriteLine("***   Displaying trains details for user   ***");
                Console.Write("Enter Source Point : ");
                string from = Console.ReadLine();

                Console.Write("Enter Destination Point : ");
                string to = Console.ReadLine(); 

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_showTrains", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Source", from);
                cmd.Parameters.AddWithValue("@Destination", to);

                // printing the result using IDataReader
                Console.WriteLine();
                dr = cmd.ExecuteReader();
                Console.WriteLine($" Displaying {from} to {to} train details ");
                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine($"Train no : {dr[0]} | Name : {dr[1]} | 1A : {dr[3]} | 2A : {dr[5]} | Sleeper: {dr[7]} |  {dr[8]} <---->  {dr[9]}");
                }
            }
            catch (Exception trains)
            {
                Console.WriteLine($"Train Details : {trains.Message}");
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
