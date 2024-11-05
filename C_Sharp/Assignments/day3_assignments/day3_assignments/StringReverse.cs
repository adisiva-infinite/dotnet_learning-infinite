using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day3_assignments
{
    class StringReverse
    {
        // Write a program in C# to accept a word from the user and display the reverse of it. 
          static void ReverseStr()
        {
            Console.Write("Enter a word of a : ");
            string a = Console.ReadLine();
            string reverse = " ";

            for (int i = a.Length - 1; i >= 0; i--)
            {
                reverse = reverse + a[i];
                //  Console.WriteLine(a[i]);
            }
            Console.WriteLine("Reverse word is : {0}", reverse);
        }
           static void Main()
        {
            ReverseStr();
            Console.Read();
        }
    }
}
