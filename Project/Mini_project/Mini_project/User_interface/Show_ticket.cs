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
    class Show_ticket : IUser
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;

        public void User_inputs()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***   User Ticket   ***");
                conn = Database.Connection();

                Console.Write("Enter PNR No : ");
                int pnr = Convert.ToInt32(Console.ReadLine());

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_showTicket", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pnr_no", pnr);

                Console.WriteLine();
                dr = cmd.ExecuteReader();
                Console.WriteLine($" Details of these id : {pnr} ");
                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine($"| Train no : {dr[0]} \n| PNR No : {dr[1]} \n| Name : {dr[2]} \n| Age : {dr[3]} \n| Gender : {dr[4]} \n| Class : {dr[5]} \n| Berth : {dr[6]} \n| Source : {dr[7]} \n| Destination : {dr[8]} \n| Status : {dr[9]}");
                }
            }
            catch(Exception ticket)
            {
                Console.WriteLine($"Ticket Status : {ticket.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
