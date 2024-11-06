using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    class String_position
    {
        // Write a C# Sharp program to remove the character at a given position in the string.
        // The given position will be in the range 0..(string length -1) inclusive.

        static void String()
        {
            Console.Write("Enter a string : ");
            string name = Console.ReadLine(); // user input

            Console.Write("Enter a position : ");
            int position = Convert.ToInt32(Console.ReadLine());

            string new_string = name.Substring(0, position) + name.Substring(position + 1);
            Console.WriteLine(new_string);
            
        }
        static void Main(string[] args)
        {
            String();
            Console.ReadKey();
        }
    }
}
