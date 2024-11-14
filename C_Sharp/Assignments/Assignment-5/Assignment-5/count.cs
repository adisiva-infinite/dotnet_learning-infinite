using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    // Write a program in C# Sharp to count the number of lines in a file.
    class Count
    {
        static void Main()
        {
            string path = "C:\\Infinite_Training\\C_Sharp\\C#.txt"; // original path

            Console.WriteLine("*** Original Path ***");
            if (File.Exists(path))
            {
                int count = File.ReadAllLines(path).Length;
                Console.WriteLine($"Given path have {count} lines");
            }
            else Console.WriteLine("Given path doesn't exists");
            Console.WriteLine();

            // Duplicate path 
            string path1 = "@C:\\Infinite_Training\\C_Sharp\\C#.txt";

            Console.WriteLine("*** Duplicate Path ***");
            if (File.Exists(path1))
            {
                int count = File.ReadAllLines(path1).Length;
                Console.WriteLine($"Given path have {count} lines");
            }
            else Console.WriteLine("Given path doesn't exists");

            Console.ReadLine();
        }
    }
}
