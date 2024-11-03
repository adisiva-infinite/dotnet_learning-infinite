using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    // Write a  Program to assign integer values to an array  and then print the following
    class Array1
    {
         int[] arr = { 21,10,30,45,56,69,62 };
        //Average value of Array elements
         void AvgvalueofArray()
        {
            int sum = 0;
            float f = arr.Length;
            foreach (int i in arr)
            {
                sum += i;
               // Console.WriteLine(sum);
            }
            //for(int i=0;i<arr.Length;i++)  we can iterate using forloop also
            //{
            //    sum += arr[i];
            //}
            Console.WriteLine("Sum of the Array Elements :"+ sum);
            Console.WriteLine("Average value of array is :"+ (sum/f));

            // else we can use inbuilt function arr.Average();
        }

        //Minimum and Maximum value in an array 
         void Minimum_and_Maximum()
        {
            //Console.WriteLine(arr.Min());
            //Console.WriteLine(arr.Max());
            int min = arr[0]; // initially max and min =10
            int max = arr[0]; 
            foreach (int i in arr)
            {
                if (i < min) min = i; // checking if i is lessthan min value then min will store i value
                if (i > max) max = i; // same as min but here it store max value 
            }
                Console.WriteLine("minimum value of array is " + min);
                Console.WriteLine("maximum value of array is " + max);
        }
        public static void Main()
        {
            Console.WriteLine("Average value of Array elements");
            Array1 Avg1 = new Array1();
            Avg1.AvgvalueofArray();
            Console.WriteLine(" ");
            Console.WriteLine("Minimum and Maximum values of an arrray");
            Avg1.Minimum_and_Maximum();
            Console.Read();
        }
    }
}
