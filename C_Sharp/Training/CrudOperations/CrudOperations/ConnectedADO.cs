using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CrudOperations
{
    class ConnectedADO
    {
        // First declare Connection , Command and IdataReader for Excutereader

        public static SqlConnection conn; 
        public static SqlCommand cmd;
        public static IDataReader dr;
        static void Main(string[] args)
        {
            SelectData();
           // InsertData();
           // UpdateData();
            DeleteData();
            Console.Read();
        }

        static SqlConnection Connection()
        {
            // Step 1 Connect to database
            conn = new SqlConnection("Data Source=ICS-LT-D244D6BT;Initial Catalog=Assignment2;" +
                "Integrated Security=true;");
            Console.WriteLine("Connected to a database:");
            // Step 2 open the connection 
            conn.Open();
            return conn;
        }
        static void SelectData()
        {
            try
            {
                Connection();
                // Excute the query using Sql Command
                cmd = new SqlCommand("Select * from Emp", conn);
                Console.WriteLine("Command is executed:");
                // printing the result using IDataReader
                dr = cmd.ExecuteReader();
                Console.WriteLine("Data is retriving:");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} {dr[4]} {dr[5]} {dr[6]} {dr[7]}");
                }
            }
            catch(SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void InsertData()
        {
            Connection();
            Console.Write("Enter Empid : ");
            int e_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter EmpName : ");
            string ename = Console.ReadLine();
            Console.Write("Enter job : ");
            string job = Console.ReadLine();
            Console.Write("Enter mgrid : ");
            float mgr_id = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter hiredate : ");
            DateTime hiredate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter salary : ");
            float Sal = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter com :");
            int com = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter dept_no :");
            int Dept_no = Convert.ToInt32(Console.ReadLine());

            // step 3 Execute the query using sqlcommand class
            cmd = new SqlCommand("insert into Emp values(@eid,@empname,@ejob,@emgr,@ehired,@eSal,@ecom,@eDept)", conn);
            Console.WriteLine();
            Console.WriteLine("Query executed:");

            cmd.Parameters.AddWithValue("@eid", e_id);
            cmd.Parameters.AddWithValue("@empname", ename);
            cmd.Parameters.AddWithValue("@ejob", job);
            cmd.Parameters.AddWithValue("@emgr", mgr_id);
            cmd.Parameters.AddWithValue("@ehired", hiredate);
            cmd.Parameters.AddWithValue("@eSal", Sal);
            cmd.Parameters.AddWithValue("@ecom", com);
            cmd.Parameters.AddWithValue("@eDept", Dept_no);

            int result = cmd.ExecuteNonQuery();

            if (result > 0) Console.WriteLine("Values inserted Successfully! ");
            else Console.WriteLine("Values not inserted...");
        }
        static void UpdateData()
        {
            Connection();
            Console.Write("Enter Emp_id to be updated : ");
            int e_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name to be updated:");
            string ename = Console.ReadLine();
            Console.Write("Enter com :");
            int com = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("update Emp set Ename = @ename, Com = @com  where Emp_id = @emp_id", conn);
            Console.WriteLine();
            Console.WriteLine("Query Executed ");

            cmd.Parameters.AddWithValue("@emp_id", e_id);
            cmd.Parameters.AddWithValue("@ename", ename);
            cmd.Parameters.AddWithValue("@com", com);

            int res = cmd.ExecuteNonQuery();

            if (res > 0)
            {
                Console.WriteLine("Values are updated...");
                Console.WriteLine();

                cmd = new SqlCommand("Select * from Emp", conn);
                Console.WriteLine("Command is executed:");
                // printing the result using IDataReader
                dr = cmd.ExecuteReader();
                Console.WriteLine("Data is retriving:");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} {dr[4]} {dr[5]} {dr[6]} {dr[7]}");
                }
            }
            else Console.WriteLine("values are not updated...");

        }
        static void DeleteData()
        {
            Connection();
            Console.Write("Enter Emp id for delete : ");
            int id = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("delete from Emp where Emp_id = @emp_id", conn);

            cmd.Parameters.AddWithValue("@emp_id",id);

            int result = cmd.ExecuteNonQuery();

            if(result>0)
            {
                Console.WriteLine();
                Console.WriteLine("Deleted Successfully...");
                Console.WriteLine();
                cmd = new SqlCommand("Select * from Emp", conn);
                Console.WriteLine("Command is executed:");
                // printing the result using IDataReader
                dr = cmd.ExecuteReader();
                Console.WriteLine("Data is retriving:");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} {dr[4]} {dr[5]} {dr[6]} {dr[7]}");
                }
            }
            else Console.WriteLine("Not Deleted...");
        }
    }
}
