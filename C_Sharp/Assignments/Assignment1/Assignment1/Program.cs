using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a C# Sharp program to accept two integers and check whether they are equal or not.

            Console.Write("Enter first number :");
            int Value1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Second number :");
            int Value2 = Convert.ToInt32(Console.ReadLine());

            if (Value1 == Value2) Console.WriteLine($"{Value1} and {Value2} are equal"); // String interpolation
            else Console.WriteLine($"{Value1} and {Value2} are not equal");
            Console.Read();

        }
    }
}
