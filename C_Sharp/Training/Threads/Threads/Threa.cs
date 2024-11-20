using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    class Threads
    {
        void run()
        {
            for(int i = 0; i < 5; i++)
            {
                lock (this) { 
                Console.WriteLine("Child Thread:");
                }
            }
        }
        public static void Main(string[] args)
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main Thread:");
                Thread.Sleep(5000);
            }
            Threads t = new Threads();
            Thread t1 = new Thread(t.run);  // creation of a thread
            Thread t2 = new Thread(t.run);
            // t1.Start(); // new thread will be created.
            //Task t2 = Task.Run(() => t.run());  
            // start , join , lock, sleep
            t1.Start();
            t2.Start();   
            Console.Read();
        }
    }
}
