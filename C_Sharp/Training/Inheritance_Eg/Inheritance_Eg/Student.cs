using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Eg
{
    class Student
    {
        string Rollno;
        string Name;
        string Class;
       public void Studentdetails()
        {
            Console.Write("Enter Student name : ");
            Name = Console.ReadLine();
            Console.Write("Enter Student Roll No : ");
            Rollno = Console.ReadLine();
            Console.Write("Enter Student Class : ");
            Class = Console.ReadLine();
        }
    }

    class Marks : Student
    {
        protected int[] marks = new int[5];
        public void Getmarks()
        {

            for(int i=0;i<marks.Length;i++)
            {
                Console.Write("Enter Subject {0} marks : ",i);
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
    class Result : Marks
    {
        int Total_marks = 0;
        public void GetResult()
        {
            for(int i=0;i<marks.Length;i++)
            {
                Total_marks += marks[i];
            }
            Console.WriteLine("Total marks : {0} ",Total_marks);
        }
    }
    class Inheritance
    {
        public static void Main()
        {
            Result result = new Result();
            result.Studentdetails();
            result.Getmarks();
            result.GetResult();
            Console.ReadKey();
        }
    }
}
