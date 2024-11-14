using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program3
    {
        // Write a C# Sharp program that takes two numbers as input and performs
        // all operations (+,-,*,/) on them and displays the result of that operation. 
        static void Main(string[] args)
        {
            Console.Write("Enter first value :");
            int value1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Operation :");
            char oper = Convert.ToChar(Console.ReadLine());
            Console.Write("Enter second value :");
            int value2 = Convert.ToInt32(Console.ReadLine());

              switch(oper)
               {
                   case '+':
                       Console.WriteLine("add =" +(value1 + value2));
                       Console.Read();
                           break;
                   case '-':
                       Console.WriteLine("substraction ="+ (value1 - value2));
                       Console.Read();
                       break;
                   case '*':
                       Console.WriteLine("multiplication =" +(value1 * value2));
                       Console.Read();
                       break;
                   case '/':
                       Console.WriteLine("division =" +(value1 / value2));
                       Console.Read();
                       break;
                   default:
                       Console.WriteLine("Invalid statement");
                       break;  
                       Console.Read();


               }
        }
    }

}
