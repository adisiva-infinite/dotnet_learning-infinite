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
    class Add_Trains : IAdmin
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static IDataReader dr;
        public void Admin_Inputs()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("***   Add New Train details   ***");
                conn = Database.Connection();
                
                Console.WriteLine();    
                // Inserting train details 
                Console.Write("Enter train no : ");
                int T_num = Convert.ToInt32(Console.ReadLine());

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_checktrain", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@train_id", T_num);
                dr = cmd.ExecuteReader();
                dr.Close();

                Console.Write("Enter train name : ");
                string T_name = Console.ReadLine();

                Console.Write("Enter 1A Available tickets : ");
                int First_ac = Convert.ToInt32(Console.ReadLine());

                int Available_1A = 0 + First_ac;

                Console.Write("Enter 2A Available tickets : ");
                int Second_ac = Convert.ToInt32(Console.ReadLine());

                int Available_2A = 0 + Second_ac;

                Console.Write("Enter 3A Available tickets : ");
                int Sleeper_cls = Convert.ToInt32(Console.ReadLine());

                int Available_sleeper = 0 + Sleeper_cls;

                Console.Write("Enter Source From : ");
                string T_start = Console.ReadLine();

                Console.Write("Enter Destination To : ");
                string T_end = Console.ReadLine();

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_AddTrains", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.WriteLine();
                cmd.Parameters.AddWithValue("@trainno", T_num);
                cmd.Parameters.AddWithValue("@trainname", T_name);
                cmd.Parameters.AddWithValue("fclass", First_ac);
                cmd.Parameters.AddWithValue("@Ticket_1A", Available_1A);
                cmd.Parameters.AddWithValue("@sclass", Second_ac);
                cmd.Parameters.AddWithValue("@Ticket_2A", Available_2A);
                cmd.Parameters.AddWithValue("@sleeperclass", Sleeper_cls);
                cmd.Parameters.AddWithValue("@Ticket_sleeper", Available_sleeper);
                cmd.Parameters.AddWithValue("@from", T_start);
                cmd.Parameters.AddWithValue("@to", T_end);
                Console.WriteLine($"Adding train {T_name}  {T_start} <------> {T_end}");
                Console.WriteLine();
                cmd.ExecuteNonQuery();
                
            }
            catch(Exception Addtrain)
            {
                Console.WriteLine($"Train status : {Addtrain.Message}");
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
