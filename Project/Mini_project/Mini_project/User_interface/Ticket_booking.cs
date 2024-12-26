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
    class Ticket_booking : IUser
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;
        public void User_inputs()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***   Get Tickets for user   ***");
                conn = Database.Connection();

                Console.WriteLine();
                Console.Write("Enter Source Point : ");
                string Leaving_address = Console.ReadLine();

                Console.Write("Enter Destination Point : ");
                string Going_address = Console.ReadLine();

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_check", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Source", Leaving_address);
                cmd.Parameters.AddWithValue("@Destination", Going_address);
                // printing the result using IDataReader
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine($" Train no : {dr[0]} | T_name : {dr[1]} | Firstclass : {dr[3]} | Second_class : {dr[5]} | Sleeper_class : {dr[7]}");
                    Console.WriteLine();
                }
                dr.Close();

                Console.Write("Select train by train id : ");
                int trainnum = Convert.ToInt32(Console.ReadLine());

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_validtrain", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@train_id", trainnum);
                dr = cmd.ExecuteReader();
                dr.Close();

                Console.Write("select type of class (1A / 2A / Sleeper ) : ");
                string Ty_cls = Console.ReadLine();

                Console.Write("Enter number of tickets : ");
                int num = Convert.ToInt32(Console.ReadLine());
                int booking = num;

                for (int i = 1; i <= num; i++)
                {
                    Console.WriteLine();
                    // Inserting passenger details for ticket booking
                    Console.Write($"Enter Passenger name {i} : ");
                    string Passenger_name = Console.ReadLine();

                    Console.Write($"Enter Age of Passenger {i} : ");
                    int Passenger_age = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"Enter Gender {i} : ");
                    string Passenger_gender = Console.ReadLine();

                    Console.Write("Select your berth like (Upper / Middle/ Lower/ Side Upper/ Side Lower : ");
                    string Passenger_berth = Console.ReadLine();

                    Console.WriteLine();

                    // Create a command object for the stored procedure
                    cmd = new SqlCommand("sp_tktbooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@train_id", trainnum);
                    cmd.Parameters.AddWithValue("@pname", Passenger_name);
                    cmd.Parameters.AddWithValue("@p_age", Passenger_age);
                    cmd.Parameters.AddWithValue("@gender", Passenger_gender);
                    cmd.Parameters.AddWithValue("@Typeofclass", Ty_cls);
                    cmd.Parameters.AddWithValue("@seats", 1); // 1 seat per passenger
                    cmd.Parameters.AddWithValue("@berth", Passenger_berth);
                    cmd.Parameters.AddWithValue("@from", Leaving_address);
                    cmd.Parameters.AddWithValue("@to", Going_address);

                    //output parameter
                    SqlParameter print_status = new SqlParameter("@printStatus", SqlDbType.VarChar, 50);
                    print_status.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(print_status);
                    cmd.ExecuteNonQuery();
                    string bookingStatus = Convert.ToString(print_status.Value);
                    //Console.WriteLine($"Booking Status : {bookingStatus} ");

                    if (bookingStatus != "Booking Success")
                    {
                        num = 0;
                        Console.WriteLine($"Booking Status for {i} :{bookingStatus}");
                    }

                }
                if (booking == num) Console.WriteLine("Booked Successfully....");
               

            }
            catch (Exception booking)
            {
                Console.WriteLine($"Booking status : {booking.Message}");
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