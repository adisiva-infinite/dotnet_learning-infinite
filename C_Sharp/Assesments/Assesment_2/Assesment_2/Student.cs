using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    // Create an Abstract class Student with  Name, StudentId, Grade as
    // members and also an abstract method Boolean Ispassed(grade)
    // which takes grade as an input and checks whether student passed the course or not
    abstract class Student
    {
        public string Name;
        public int StudentId;
        public double Grade;
        public abstract bool IsPassed(double Grade);
    }

    // Create 2 Sub classes Undergraduate and Graduate
    // that inherits all members of the student and overrides Ispassed(grade) method

    class Undergraduate : Student
    {
        public override bool IsPassed(double Grade)
        {
            if (Grade >= 70.0) return true;
            else return false;
        }
    }
    class Graduate : Student
    {
        public override bool IsPassed(double Grade)
        {
            if (Grade >= 80.0) return true;
            else return false;
        }


            
        static void Main()
        {
            Console.Write("Enter type of student(Undergraduate or graduate) : ");
            string type = Console.ReadLine();
            Console.Write("Enter student name : ");
            string Student_name = Console.ReadLine();
            Console.Write("Enter student id : ");
            int Student_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student grade : ");
            double grade = Convert.ToDouble(Console.ReadLine());

            Student s1;
            if (type == "undergraduate") s1 = new Undergraduate();
            else s1 = new Graduate();

            s1.Name = Student_name;
            s1.StudentId = Student_id;
            s1.Grade = grade;
            Console.WriteLine(" ");
            Console.WriteLine("*** Student Details ***");
            Console.WriteLine($"Name       : {Student_name}");
            Console.WriteLine($"student id : {Student_id}");
            Console.WriteLine($"Grade      : {grade}");
            var x = (s1.IsPassed(grade) == true) ? "Pass" : "Fail";
            Console.WriteLine($"Student is : {x}");

            Console.ReadKey();
        }
    }
}

