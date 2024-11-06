using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{

    // Write a C# Sharp program to exchange
    // the first and last characters in a given string and return the new string.
    class String_Newstring
    {
        void Exchange()
        {
            string New_str = "";
            Console.Write("enter a sting : ");
            string str = Console.ReadLine();

            if(1 <= str.Length)
            {
                New_str = str[str.Length - 1] + str.Substring(1, str.Length - 2) + str[0]; 
                Console.WriteLine(New_str);
            }
          
        }
        static void Main()
        {
            String_Newstring str1 = new String_Newstring();
            str1.Exchange();
            Console.Read();
        }
    }
}
