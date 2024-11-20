using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Class1
    {
        public string ename;
        public int age;
        public string Course;
        public void input()
        {
            Console.Write("Enter a name : ");
             ename = Console.ReadLine();
            Console.Write("Enter a age : ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a course : ");
            Course = Console.ReadLine();

        }
        public void output()
        {
            Console.WriteLine();
            Console.WriteLine("*** Output data ***");
            Console.WriteLine(ename);
            Console.WriteLine(age);
            Console.WriteLine(Course);
        }
        //public static void Main()
        //{
        //    Class1 c1 = new Class1();
        //    c1.input();
        //}
    }
}
