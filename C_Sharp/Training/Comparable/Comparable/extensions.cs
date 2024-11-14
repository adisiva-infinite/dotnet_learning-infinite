using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable
{
    class extensions
    {
        static void Main(string[] args)
        {                                    //List initilaization
            List<int> numbers = new List<int>() { 36, 71, 12, 15, 29, 18, 27, 17, 9, 34 };

            foreach (var value in numbers)
            {
                Console.Write("{0} ", value);
            }

            //using lambda expressions to find the square of all numbers in the List
            var square = numbers.Select(x => x * x);

            Console.WriteLine("-----Squares of Numbers------");
            foreach (int v in square)
            {
                Console.Write("{0} ", v);
            }

            //find all the numbers divisible by 3 in the list

            Console.WriteLine("-----divisible by 3 of Numbers------");
            Console.WriteLine(" ");
            
            // here we have to every element is divisible by 3 or not

            var divide = numbers.Where(x => x % 3 == 0);
            foreach(int x in divide)
            {
                Console.Write("{0} ", x);
            }

            Console.Read();
        }

    }
}
