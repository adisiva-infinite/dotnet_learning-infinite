﻿using System;
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

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_trains", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Train no : {dr[0]} | Name : {dr[1]} | 1A : {dr[3]} | 2A : {dr[5]} | Sleeper: {dr[7]} | {dr[8]} <----> {dr[9]} | Status : {dr[10]}");

                }
                dr.Close();

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Train num for delete : ");
                int num = Convert.ToInt32(Console.ReadLine());

                // Create a command object for the stored procedure
                cmd = new SqlCommand("sp_deleteTrain", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@trainno", num);

                Console.WriteLine();
                dr = cmd.ExecuteReader();
                dr.Close();
                Console.WriteLine();
                Console.WriteLine($" Deleting {num} train details ");
                Console.WriteLine();
            }
            catch(Exception delete)
            {
                Console.WriteLine($"Update status : {delete.Message}");
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
