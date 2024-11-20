using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "siva.txt";
            Console.Write("Enter a Text to Append to the existing file : ");
            string text = Console.ReadLine();
            if (File.Exists(file)) File.AppendAllText(file, text + "\n");
            else File.WriteAllText(file, text + "\n");

            Console.WriteLine();
            Console.WriteLine("---------- solution using StreamWriter---------------");
            using (StreamWriter str = new StreamWriter(file, append: true))
            {
                str.Write(text + "\n");
            }
            Console.WriteLine("Text appended Succesfully");
            Console.ReadLine();
        }
    }
}