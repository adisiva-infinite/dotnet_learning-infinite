using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    // Write a C# program to implement a method that takes an integer as input and
    // throws an exception if the number is negative. Handle the exception in the calling code
    class NegitiveException : ApplicationException
    {
        public NegitiveException(string msg) { }
    }
    class Handle_Exception
    {
        public int Val(int num) 
        {
            if (num < 0) throw new NegitiveException("Value must be greater than or equal to zero");
            else return num;

        }
        static void Main()
        {
            Handle_Exception He = new Handle_Exception();
            try
            {
                Console.Write("Enter the value  : ");
                int M = Convert.ToInt32(Console.ReadLine());
                He.Val(M);
                 Console.WriteLine($"Given num is Positive : {M} ");
                 Console.WriteLine(" ");
            }
            catch(NegitiveException Ne)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Enter a number greater than  or equal to zero", Ne.Message);
            }
            Console.ReadKey();
        }
    }
}
