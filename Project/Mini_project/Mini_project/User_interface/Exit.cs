using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using System.Data.SqlClient;

namespace Mini_project.User_interface
{
    public class Exit : IUser
    {
        public void User_inputs()
        {
            Console.WriteLine("Exited by user...");

        }
    }
}
