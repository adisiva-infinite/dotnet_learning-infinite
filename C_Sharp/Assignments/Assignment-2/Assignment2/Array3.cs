using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Array3
    {
        // Write a C# Sharp program to copy the elements of one array
        // into another array.
         void Array()
        {
            Console.WriteLine("one array into another array");
            int[] arr = new int[] { 20, 12, 65, 98, 54, 34 };
            int[] ar1 = arr;
            Console.WriteLine("*** first array ***");
            for(int i=0;i<arr.Length;i++)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("*** second array ***");
            for (int i = 0; i < ar1.Length; i++)
            {
                Console.Write(ar1[i] + " ");
            }

        }
        public static void Main()
        {
            Array3 array = new Array3();
            array.Array();
            Console.Read();
        }
    }
}
