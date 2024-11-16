using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Square
    {
        // Write a query that returns list of numbers and their squares only if square is greater than 20
        static void Main(string[] args)
        {
            Console.Write("Enter array length : ");
            int x = Convert.ToInt32(Console.ReadLine());

            List<int> num = new List<int>() ;
            for(int i=0;i<x;i++)
            {
                Console.Write($"Enter value of {i + 1} : ");
                int a = Convert.ToInt32(Console.ReadLine());
                num.Add(a);
            }
            var sqr = num.Where(n => n * n > 20).Select(n => new { Number = n, square = n * n });
            foreach(var k in sqr)
            {
                Console.WriteLine($"{k.Number} - {k.square}");
            }
           
            Console.ReadKey();
        }
    }
}
