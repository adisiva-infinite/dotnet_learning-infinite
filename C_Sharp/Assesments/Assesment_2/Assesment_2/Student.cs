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
        public abstract void Ispassed(char grade);
        public void fail()
        {
            Console.WriteLine("Student was failed");
        }
    }
    class Details : Student
    {

        public char Grade = 'f';

        void Student_details(string name, int id)
        {
            Console.WriteLine("");
            Console.WriteLine("*** Result of the student ***");
            Console.WriteLine($"student name : {name}");
            Console.WriteLine($"student id : {id}");

        }

        public override void Ispassed(char grade)
        {
       
            switch(grade)
            {
                case 'o':
                    Console.WriteLine("Student is Pass");
                    break;
                case 'a':
                    Console.WriteLine("Student is Pass");
                    break;
                case 'b':
                    Console.WriteLine("Student is Pass");
                    break;
                case 'c':
                    Console.WriteLine("Student is Pass");
                    break;
                case 'd':
                    Console.WriteLine("Student is Pass");
                    break;
                case 'f':
                    fail();
                    break;
                default:
                    Console.WriteLine("ENter valid input");
                    break;


            }
        }
        static void Main()
        {
            Console.Write("Enter student name : ");
            string Student_name = Console.ReadLine();
            Console.Write("Enter student id : ");
            int Student_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student grade : ");
            char grade = Convert.ToChar(Console.ReadLine());
            Details d1 = new Details();
            d1.Student_details(Student_name, Student_id);
            d1.Ispassed(grade);
            Console.ReadKey();
        }
    }
}
