using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class str_start_with
    {
        // Write a query that returns words starting with letter 'a' and ending with letter 'm'.
        static void Main()
        {
            Console.WriteLine("Enter a sentence to find the words starts with A and ends with m");
            string str = Console.ReadLine();
            string[] str1 = str.Split(' ');

            var filterwords = from str2 in str1
                              where str2.StartsWith("A", StringComparison.OrdinalIgnoreCase) && str2.EndsWith("M", StringComparison.OrdinalIgnoreCase)
                              select str2;
            foreach (var word in filterwords)
            {
                Console.WriteLine(word);
            }

            Console.Read();
        }
    }
}
