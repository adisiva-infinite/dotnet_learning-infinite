using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Comparable
{
    class Program
    {
        public static int counter = 0;
        public static object l = new object();
        public static void Increment()
        {
            for (int i = 0; i < 5000; i++)
            {
                lock (l)
                {
                    //Console.WriteLine(l);
                    //Console.WriteLine($"counter = {counter}");
                    counter++;
                    //Console.WriteLine($"counter = {counter}");
                }
            }
        }
        static void Main()
        {
            Thread t1 = new Thread(Increment);
            Thread t2 = new Thread(Increment);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.WriteLine($"counter = {counter}");
            Console.ReadLine();
        }
    }
}
