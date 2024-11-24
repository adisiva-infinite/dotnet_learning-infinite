
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_example
{
    class Program
    {
        // defining delegate without return type
        public delegate void AddDelegate(int a, int b);

        // delegate with return type 
        public delegate string StrDelegate(string str);

        void AddNum(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public static string Say(string str1)
        {
            return "Hi" + str1;
        }
        static void Main(string[] args)
        {
            // Creating class object
            Program p1 = new Program();
           // p1.AddNum(100, 39); passing value thro class - method
            // for delegate we create an object
            AddDelegate ad1 = new AddDelegate(p1.AddNum); // here non-static method do we call by using class obj with method
            ad1(100, 37);
            ad1.Invoke(123, 78);
            // here we calling by using class name with method here static method
            StrDelegate str2 = new StrDelegate(Program.Say);
            string s1 = Say(" Siva");
            string s2 = str2(" Teja");
            string s4 = str2(" Arthi");
            string s3 = str2.Invoke(" Tarun");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s4);
            Console.WriteLine(s3);
            Console.Read();

        }
    }
}
