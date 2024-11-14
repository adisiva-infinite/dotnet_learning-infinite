using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    class strings
    {
        // Write a program in C# Sharp to create a file and write an array of strings to the file.
        static void Main()
        {
            string[] str = new string[3];
            for(int i=0;i<str.Length;i++)
            {
                Console.Write($"Enter string {i+1} : ");
                str[i] = Console.ReadLine();
            }
            string path = "file.txt";
            FileStream filestrem = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter streamwriter = new StreamWriter(filestrem);
            foreach (string s in str)
            {
                streamwriter.WriteLine(s);
            }
            Console.WriteLine("Written to the file Successfully");
            streamwriter.Flush();
            streamwriter.Close();
            filestrem.Close();
            Console.ReadLine();
        }
    }
}
