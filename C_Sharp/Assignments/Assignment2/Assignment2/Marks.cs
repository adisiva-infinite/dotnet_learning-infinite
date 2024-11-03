using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Marks
    {
         void Array()
        {
            int[] marks = new int[10];
            Console.Write("Enter Ten marks :");
            for(int i=0;i<marks.Length;i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(int i = 0; i < marks.Length; i++) { 
            Console.WriteLine("The marks array is:" + marks[i]);
            }

            // Total marks
            Console.WriteLine(" ");
            Console.WriteLine("*** Total marks ***");
            int Total = 0;
            for(int j=0;j<marks.Length;j++)
            {
                Total += marks[j];
            }
            Console.WriteLine("Total marks in array is :"+Total);
            float f = marks.Length;

            // Average
            float Average = (Total / f);
            Console.WriteLine("Average of all marks is :" + Average);


        // Minimum marks & maximum marks of list

            Console.WriteLine(" ");
            Console.WriteLine("*** Minimum and Maximum ***");
            //Console.WriteLine("Minimum marks is :"+marks.Min()); minimum value
            //Console.WriteLine("Maximum marks is :"+marks.Max()); maximum value

            int min = marks[0]; // it store 0 index of marks array 
            int max = marks[0];

            foreach(int i in marks)
            {
                if (i < min) min = i; // it checks every element of array if i is < min v then
                if (i > max) max = i; // min store i value similarly max will store i value
            }
            Console.WriteLine();
            Console.WriteLine("Minimum marks is :"+min);
            Console.WriteLine("Maximum marks is :" + max);

            //Display marks in ascending order

            Console.WriteLine(" ");
            Console.WriteLine("*** Ascending Order ***");

            for(int i=0;i<marks.Length;i++)
            {
                for(int j=i+1;j<marks.Length;j++)
                {

                    if(marks[i]>marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }
                }
            }
            for(int i=0;i<marks.Length;i++)
            {
                Console.WriteLine(marks[i]);
            }

            //Display marks in descending order

            Console.WriteLine(" ");
            Console.WriteLine("*** Descending Order ***");

            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = i + 1; j < marks.Length; j++)
                {

                    if (marks[i] < marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }
                }
            }
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine(marks[i]);
            }

        }

        public static void Main()
        {
            Marks array = new Marks();
            array.Array();
            Console.Read();
        }
    }
}
