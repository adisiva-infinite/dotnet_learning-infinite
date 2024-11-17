using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6_ClassLibrary_
{
    public class Program
    {
        public const int totalfare = 500;
        public static void Main(String[] args)
        {
            Console.Write("Enter the name : ");
            String name = Console.ReadLine();
            Console.Write("Enter the age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Class1 c1 = new Class1();
            c1.CalculateConcession(age);
            Console.Read();
        }
    }
}
