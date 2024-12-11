using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConnectedADO
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static IDataReader dr;
        static void Main()
        {
            //InsertData();
            //DeleteData();
            SelectData();
            UpdateData();
            Console.Read();
        }

        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-D244D6BT;Initial Catalog=Assignment2;" +
                "Integrated Security=true;");
            con.Open();
            return con;
        }
        static void SelectData()
        {
             getConnection();
            cmd = new SqlCommand("select * from Emp");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            Console.WriteLine("Data is Retriving");
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " " + dr[4]+" " + dr[5] + " " + dr[6] + " " + dr[7]);

                //Console.WriteLine("Employee ID :" + dr[0]);

                //Console.WriteLine("Employee Name :" + dr[1]);
                //Console.WriteLine("Employee Salary :" + dr[3]);
            }

        }

        static void InsertData()
        {
            con = getConnection();
            Console.WriteLine("Enter Empid, EmpName,job,mgrid,hiredate,sal,com,dept_no :");
            int e_id = Convert.ToInt32(Console.ReadLine());
            string ename = Console.ReadLine();
            string job = Console.ReadLine();
            float mgr_id = Convert.ToSingle(Console.ReadLine());
            DateTime hiredate = Convert.ToDateTime(Console.ReadLine());
            float Sal = Convert.ToInt32(Console.ReadLine());
            int com = Convert.ToInt32(Console.ReadLine());
            int Dept_no = Convert.ToInt32(Console.ReadLine());
            //  cmd=new SqlCommand("Insert into tblemployee values(150,'Rama','Male',15000,5,0000007)",con);

            cmd = new SqlCommand("Insert into Emp values(@eid,@empname,@ejob,@emgr,@ehired,@eSal,@ecom,@eDept)", con);
            //all the above variables are now appended to the parameters collection of the command object
            cmd.Parameters.AddWithValue("@eid", e_id);
            cmd.Parameters.AddWithValue("@empname", ename);
            cmd.Parameters.AddWithValue("@ejob", job);
            cmd.Parameters.AddWithValue("@emgr", mgr_id);
            cmd.Parameters.AddWithValue("@ehired", hiredate);
            cmd.Parameters.AddWithValue("@eSal", Sal);
            cmd.Parameters.AddWithValue("@ecom", com);
            cmd.Parameters.AddWithValue("@eDept", Dept_no);

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                Console.WriteLine("Inserted Successfully");
            else
                Console.WriteLine("Could not Insert..");
        }

        static void DeleteData()
        {
            con = getConnection();
            Console.WriteLine("Enter Empid to delete :");
            int e_id = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd1 = new SqlCommand("select * from Emp where Emp_id=@eid");
            cmd1.Connection = con;
            cmd1.Parameters.AddWithValue("@eid", e_id);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                for (int i = 0; i < dr1.FieldCount; i++)
                {
                    Console.WriteLine(dr1[i]);
                }

                con.Close();
                Console.WriteLine();
                Console.WriteLine("Are You sure to delete this Employee ( Y/N )? :");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    cmd = new SqlCommand("delete from Emp where Emp_id=@eid", con);
                    cmd.Parameters.AddWithValue("@eid", e_id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Deleted Successfully..");
                }
            }
        }
        static void UpdateData()
        {
            // Step 2: Open the connection
            con = getConnection();
            Console.WriteLine("Connection established successfully.");

            Console.WriteLine("Enter the Empid:");
            int id = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("update Emp set Ename = 'Adi Siva' where Emp_id = @empid", con);
            cmd.Parameters.AddWithValue("@empid", id);
            int res = cmd.ExecuteNonQuery();  
            if (res > 0) Console.WriteLine("Updated successfully:");
            else Console.WriteLine("Updation failed:");
            con.Close();

        }
    }
}