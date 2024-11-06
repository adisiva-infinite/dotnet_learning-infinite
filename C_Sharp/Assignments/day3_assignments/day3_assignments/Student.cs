using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day3_assignments
{
    // Create a class called student which has data members like
    // rollno, name, class, Semester, branch, int [] marks=new int marks [5](marks of 5 subjects )
    class Student
    {
        public string Rollno;
        public string Name;
        public string Class;
        public string Semester;
        public string Branch;

        // -Pass the details of student like rollno, name, class, SEM, branch in constructor
        public Student(string roll_no, string name, string Std_class, string sem, string branch)
        {
            Rollno = roll_no;
            Name = name;
            Class = Std_class;
            Semester = sem;
            Branch = branch;
        }
        public void Studentdetails()
        {
            Console.WriteLine("Roll no : {0}",Rollno);
            Console.WriteLine("Name : {0}",Name);
            Console.WriteLine("Class : {0}",Class);
            Console.WriteLine("Semester : {0}",Semester);
            Console.WriteLine("Branch : {0}",Branch);
        }
    }

    class Marks : Student
    {
        // -For marks write a method called GetMarks() and give marks for all 5 subjects

        public int[] marks = new int[5];
        public void Getmarks()
        {
            float f = marks.Length;
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write("Enter Subject {0} marks : ", i);
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
    class Result : Marks
    {
        // Write a method called displayresult, which should calculate the average marks
        public void DisplayResult()
        {
        int Total_marks = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                Total_marks += marks[i];
            }
            Console.WriteLine("*** Total marks ***");
            Console.WriteLine("Total marks : {0} ", Total_marks);
            Console.WriteLine(" ");
            Console.WriteLine("*** Average percentage ***");
            float average = (Total_marks / marks.Length);
            Console.WriteLine("Average of all marks : {0}",average);

            // -If marks of any one subject is less than 35 print result as failed

            // -If marks of all subject is >35,but average is < 50 then also print result as failed

            foreach(int i in marks)
            {
                if (marks[i] > 35) if (average > 50) Console.WriteLine("Pass");
                    else Console.WriteLine("Fail");

            }
        }

        public void DisplayData()
        {
            Studentdetails();
            DisplayResult();
        }
    }
    class Inheritance
    {
        public static void Main()
        {
            Console.Write("Enter Student name : ");
            string Name = Console.ReadLine();
            Console.Write("Enter Student Roll No : ");
            string Rollno = Console.ReadLine();
            Console.Write("Enter Student Class : ");
            string Class = Console.ReadLine();
            Console.Write("Enter Which Semester : ");
            string sem = Console.ReadLine();
            Console.Write("Enter Branch : ");
            string branch = Console.ReadLine();
            Student std = new Student(Name, Rollno,Class,sem,branch);
            Result result = new Result();
            result.Getmarks();
            result.DisplayData();
            Console.ReadKey();
        }
    }

}
