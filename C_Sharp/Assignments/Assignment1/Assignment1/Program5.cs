using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program5
    {
        // Write a C# program to compute the sum of two given integers.
        // If two values are the same, return the triple of their sum.
        static void Main(string[] args)
        {
            Console.Write("Enter first value :");
            int value1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second value :");
            int value2 = Convert.ToInt32(Console.ReadLine());
            int sum = value1 + value2; // initially adding 2 values 
            if (value1 != value2)   // checking if 2 values not equal then return 1st statement
                Console.WriteLine(sum);
            else
            {
                int triple = sum * 3;
                Console.WriteLine(triple);
            }
            Console.Read();

        }
    }

}
