using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day3_assignments
{
    class Strings
    {
        // Write a program in C# to accept a word from the user and display the length of it.
        void Wordlength()
        {
            Console.Write("Enter a word of a : ");
            string a = Console.ReadLine();
            Console.WriteLine(a.Length);
        }

        static void Main(string[] args)
        {
            Strings str = new Strings();
            str.Wordlength();
            Console.Read();
        }
    }
}
