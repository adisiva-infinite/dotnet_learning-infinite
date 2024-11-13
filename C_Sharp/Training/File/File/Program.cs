using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathName = @"C:\Infinite_Training\C_Sharp\Training\myFile.txt";
            FileStream fs = File.Create(pathName);

            // check if myFile.txt file is created at the specified path 
            if (File.Exists(pathName))
            {
                Console.WriteLine("File is created.");
            }
            else
            {
                Console.WriteLine("File is not created.");
            }
        }
    }
}
