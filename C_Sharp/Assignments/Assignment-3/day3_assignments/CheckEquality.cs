using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day3_assignments
{
    class CheckEquality
    {
        // Write a program in C# to accept two words from user and find out if they are same. 

        static void Equality()
        {
            Console.Write("Enter first word : ");
            string a = Console.ReadLine();
            Console.Write("Enter seconnd word : ");
            string b = Console.ReadLine();

            if (a == b) Console.WriteLine("{0} and {1} both words are Equal:", a, b);
            else Console.WriteLine("{0} and {1} both words are Not Equal", a, b);
        }
       static void Main()
        {
            Equality();
            Console.Read();
        }

    }
}
