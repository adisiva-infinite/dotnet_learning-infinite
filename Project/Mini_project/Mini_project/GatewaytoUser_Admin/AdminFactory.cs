using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;
using Mini_project.Admin_Interface;

namespace Mini_project.GatewaytoUser_Admin
{
    public class AdminFactory : ITrainFactory
    {
        public IUser CreateUser()
        {
            throw new NotImplementedException(); 
        }

        public IAdmin CreateAdmin()
        {
            Console.WriteLine();
            Console.WriteLine(" 1.Addtrain | 2.Deletetrain | 3.Modifytrain | 4.Show all bookings | 5.Show all Cancelled tickets  | 6.All trains  | 7.Exit  ");
            Console.WriteLine();
            Console.Write("Choose (1/2/3/4/5/6/7) : ");
            int res = Convert.ToInt32(Console.ReadLine());
            switch (res)
            {
                case 1:
                    return new Add_Trains();
                    break;
                case 2:
                    return new Delete_trains();
                    break;
                case 3:
                    return new Modify_train();
                    break;
                case 4:
                    return new Show_bookings();
                    break;
                case 5:
                    return new User_Cancelled_Tickets();
                    break;
                case 6:
                    return new ShowAllTrains();
                    break;
                case 7:
                    return new Exit();
                    break;
                default:
                    throw new ArgumentException("Invalid gateway...");
            }
        }
    }
}
