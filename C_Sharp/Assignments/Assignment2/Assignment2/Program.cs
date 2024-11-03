using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        // Write a C# Sharp program to swap two numbers.
        static void Main(string[] args)
        {
            Console.Write("Enter value of a :");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter value of b :");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("*** Before swapping ****");
            Console.WriteLine("value of a is :" + a);
            Console.WriteLine("value of b is :" + b);

            a = a + b; 
            b = a - b;
            a = a - b;

            Console.WriteLine("*** After swapping ****");
            Console.WriteLine("value of a is :"+a);
            Console.WriteLine("value of b is :" + b);
            
            Console.Read();

        }
    }
}
