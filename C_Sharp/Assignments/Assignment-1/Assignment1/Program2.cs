using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program2
    {
        // Write a C# Sharp program to check whether a given number is positive or negative. 
        static void Main(string[] args)
        {
            int value; // variable declaration
            Console.Write("Enter input number :");
            value = Convert.ToInt32(Console.ReadLine()); // given input is assigned to value variable


            if (value >= 0) Console.WriteLine($"Given {value} is Positive number");
            else Console.WriteLine($"Given {value} is Negitive number");
            Console.Read();
        }
    }

}
