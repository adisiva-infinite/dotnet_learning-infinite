using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_project.Abstract_factory;

namespace Mini_project.GatewaytoUser_Admin
{
    public interface ITrainFactory
    {
        IUser CreateUser(); 
        IAdmin CreateAdmin();
    }
}
