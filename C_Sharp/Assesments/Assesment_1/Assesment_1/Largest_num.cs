using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    // Write a C# Sharp program to check the largest number among three given integers.
    class Largest_num
    {
        static void Number()
        {
            Console.Write("Enter first number : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number : ");
             int  b = Convert.ToInt32(Console.ReadLine()); 
            Console.Write("Enter third number : ");
             int c = Convert.ToInt32(Console.ReadLine());

            int new_number;

            // Uisng terinary operator

            new_number = (a < b) && (b < c) ? (a < c) ? a : b : c;

            Console.WriteLine("Least number is : {0} ", new_number);
        }

        static void Main()
        {
            Number();
            Console.Read();
        }
    }
}
