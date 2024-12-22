using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mini_project
{
    public class Database
    {
        public static SqlConnection conn;
        public static SqlConnection Connection()
        {
            // Step 1 Connect to database
            conn = new SqlConnection("Data Source=ICS-LT-D244D6BT;Initial Catalog=Railway_Reservation;" +
                "Integrated Security=true;");
            // Step 2 open the connection 
            conn.Open();
            return conn;
        }
    }
}
