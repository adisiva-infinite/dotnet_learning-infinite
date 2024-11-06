using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    // Create a program to count the no. of occurrences of a letter
    // in a given string (eg: "OOPs Programming", o appears 3 times)
    class Count
    {
        static void CoUnt()
        {
            int count = 0;
            Console.WriteLine("Enter a string : ");
            string str = Console.ReadLine();
            Console.WriteLine("Enter a string : ");
            char str1 = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == str1)
                {
                    count++;
                }
            }

            Console.WriteLine("Count of {0} is {1}",str1,count);

        }

        static void Main()
        {
            CoUnt();
            Console.Read();
        }
    }
}
