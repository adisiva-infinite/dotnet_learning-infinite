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
    class Show_bookings : IAdmin
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;
        public void Admin_Inputs()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***   Passenger Details who are Booked   ***");
                Console.WriteLine();
                conn = Database.Connection();

                Console.Write("Enter Source Point : ");
                string from = Console.ReadLine();

                Console.Write("Enter Destination Point : ");
                string to = Console.ReadLine();

                cmd = new SqlCommand("sp_booking", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@source", from);
                cmd.Parameters.AddWithValue("@destination", to);
                
                Console.WriteLine();
                dr = cmd.ExecuteReader();
                Console.WriteLine();
                Console.WriteLine($" Displaying {from} to {to} Booking details ");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(" Train id  |  PNR No  |      Name      |    Age    |    Gender   |   Class   |   Berth   |   Status");
                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($" {dr[0]}     |   {dr[1]}   |      {dr[2]}      |     {dr[3]}    |    {dr[4]}    |    {dr[5]}     |    {dr[6]}    |     {dr[9]} ");
                }
                Console.WriteLine();
            }
            catch(Exception show)
            {
                Console.WriteLine($" Show bookings : {show.Message}");
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
