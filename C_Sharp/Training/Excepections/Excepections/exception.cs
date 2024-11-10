using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepections
{
    class NamingException : ApplicationException
    {
        public NamingException(string msg) : base(msg) { }
    }

    class exception
    {
        String Name;

        public void getName()
        {
            Console.WriteLine("Enter your Name :");
            Name = Console.ReadLine();

            // if(Name <=0)
            if (Name.Trim().Equals(string.Empty))
            {
                throw new NamingException("name should have atleast one character");
            }
            else
                Name = Name.ToUpper();
            Console.WriteLine(Name);
        }
    }

    class UserDefinedException
    {
        static void Main()
        {
            exception un = new exception();
            try
            {
                un.getName();
            }

            catch (NamingException n)
            {
                Console.WriteLine(n.Message);


            }
            Console.Read();

        }
    }
}
