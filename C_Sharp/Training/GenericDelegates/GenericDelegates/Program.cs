
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegates
{
    class Program
    {
        //public delegate double NumDelegate(int a, float b, double c);
        //public delegate void NumDelegate2(int a, float b, double c);
        //public delegate bool StrDelegate(string str);

        public static double AddNumber(int a, float b, double c)
        {
            return a + b + c;
        }
        public static void AddNumber2(int a, float b, double c)
        {
            Console.WriteLine(a + b + c); 
        }
        public static bool CheckL(string str)
        {
            if (str.Length > 5) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Func<int,float,double,double> nd1 = AddNumber; // generic func delegate
            // here int, float, double are parameters and last double is return type...
            // in func delegate we have return type like parameters along with output parameters

            double result = nd1.Invoke(24, 35.7f, 293.765);
            Console.WriteLine(result);

            Console.WriteLine();

            Action<int,float,double> n2 = AddNumber2;
            // Action delegate having parameters and it don't having return values 

            n2.Invoke(24, 35.7f, 293.765);

            Console.WriteLine();

            Predicate<string> s1 = CheckL;
            // Predicate delegate having parameters
            // but its having only one return type is called boolean..

            Console.Write("Enter a text : ");
            string x = Console.ReadLine();
            bool b1 = s1.Invoke(x);
            Console.WriteLine(b1);

            Console.ReadKey();
            
        }
    }
}
