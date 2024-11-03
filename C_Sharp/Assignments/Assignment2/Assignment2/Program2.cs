using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    // Write a C# program that takes a number as input and displays
    // it four times in a row (separated by blank spaces),
    // and then four times in the next row, with no separation.
    // You should do it twice: Use the console. Write and use {0}.
    class Program2
    {
        static void Main()
        {
            Console.Write("enter value of a :");
            int a = Convert.ToInt32(Console.ReadLine());

            for(int i=1; i <= 1; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}",a);
                Console.WriteLine("{0}{0}{0}{0}",a);
                for(int j=1; j <= i; j++)
                {
                    Console.WriteLine("{0} {0} {0} {0}", a);
                    Console.WriteLine("{0}{0}{0}{0}", a);
                }
            Console.Read();
            }
        }
    }
}
