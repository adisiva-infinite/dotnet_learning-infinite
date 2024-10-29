using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CSharp Programming");
            Console.Write("Enter your name :");
            string uname = Console.ReadLine();
            Console.Write("Enter your age :");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Welcome " + uname + " aged "+ age ); // Concatenation 
            Console.WriteLine("Welcome {0} to CSharp Programming", uname); // Place holder
            Console.WriteLine($"Welcome {uname} aged {age} to CSharp programming"); // String interpolation



            // Terinery Operator
            Console.WriteLine("Terinary Operator");

            int a = 10;
            int b = 2;
            int x = a < b ? a : b;
            Console.WriteLine(x);


            //  Type conversions
            Console.WriteLine("Implicit type conversion");

            int i = 10;
            float f = i;  //  implicit typecasting
            Console.WriteLine(f);

            f = 32345.76f;
            i = (int)f;  //  type casting
            i = Convert.ToInt32(f); //  conversion
            Console.WriteLine(i);
            i = Convert.ToInt32('j'); // It returns ascii value 
            Console.WriteLine(i);

            Console.WriteLine("Minimum int value = {0}",float.MinValue); // float min value
            Console.WriteLine("Maximum int value = {0}", float.MaxValue); // float max value

            // Parse and  Try parse 

            string str = "594";
            int res = int.Parse(str); // converting string data type to int data type
            Console.WriteLine("String value converted into a num {0}",res);

            string stri = "298abc";
            int result = 0;


            Console.Read();
        }
    }
}
