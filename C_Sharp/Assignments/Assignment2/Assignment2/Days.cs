using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    //Write a C# Sharp program to read any day number
    //as an integer and display the name of the day as a word.
    class Days
    {
        public static void day(int x)
        {
            if (x == 1) Console.WriteLine("Monday");
            else if (x == 2) Console.WriteLine("Tuesday");
            else if (x == 3) Console.WriteLine("Wednesday");
            else if (x == 4) Console.WriteLine("Thursday");
            else if (x == 5) Console.WriteLine("Friday");
            else if (x == 6) Console.WriteLine("Saturday");
            else if (x == 7) Console.WriteLine("Sunday");
            else Console.WriteLine("Invalid day");
        }
        public static void Main()
        {
            Console.Write("Enter a number between 1-7 :");
            int i = Convert.ToInt32(Console.ReadLine());
            day(i);
            Console.Read();
        }
    }
}
