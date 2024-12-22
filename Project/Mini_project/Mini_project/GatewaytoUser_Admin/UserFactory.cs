using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using Mini_project.User_interface;

namespace Mini_project.GatewaytoUser_Admin
{
    public class UserFactory : ITrainFactory
    {
        public IUser CreateUser()
        {
           while(true)
            {
                Console.WriteLine();
                Console.Write("Enter 1.Booking|| 2.Cancel || 3.AvailableTrains || 4.Show ticket || 5.Exit : ");
                int res = Convert.ToInt32(Console.ReadLine());

                switch (res)
                {
                    case 1:
                        return new Ticket_booking();
                    case 2:
                        return new Cancel_ticket();
                    case 3:
                        return new Show_Trains();
                    case 4:
                        return new Show_ticket();
                    case 5:
                        return new Exit();
                        break;
                    default: throw new ArgumentException("Invalid gateway...");
                }
            }
        }

        public IAdmin CreateAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
