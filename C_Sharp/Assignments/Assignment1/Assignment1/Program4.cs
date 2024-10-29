using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program4
    {
        //Write a C# Sharp program that prints the multiplication table of a number as input.
        static void Main(string[] args)
        {
            Console.WriteLine("**** Multiplication table ****");
            Console.Write("Enter value :");
            int v = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++) // Here you can see value initialization and condition and updation
            {
                Console.WriteLine($"{v} * {i} = {v * i}");
            }
            Console.Read();
        }
    }

}
