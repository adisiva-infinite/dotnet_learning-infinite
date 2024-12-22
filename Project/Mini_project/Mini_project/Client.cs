using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.GatewaytoUser_Admin;
using Mini_project.Abstract_factory;


namespace Mini_project
{
    public class Client
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("*** Indian Railways ***");
            try
            {
               while(true)
                {
                    ITrainFactory Trainfactory;
                    Console.WriteLine();
                    Console.Write("*** Choose USER / ADMIN / EXIT : ");
                    string u1 = Console.ReadLine();

                    if (u1.Equals("user") || u1.Equals("USER"))
                    {
                        Trainfactory = new UserFactory();
                        IUser userPerform = Trainfactory.CreateUser(); // Get the user actions
                        userPerform.User_inputs();
                    }
                    else if (u1.Equals("admin") || u1.Equals("ADMIN"))
                    {
                        Trainfactory = new AdminFactory();
                        IAdmin adminPerform = Trainfactory.CreateAdmin(); // Get the admin actions
                        adminPerform.Admin_Inputs();
                    }
                    else if (u1.Equals("exit") || u1.Equals("EXIT")) return;
                }
            }
            catch(ArgumentException ee)
            {
                Console.WriteLine(ee.Message);
            }

            Console.Read();
        }
    }
}
