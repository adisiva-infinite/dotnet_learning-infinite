using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exten_eg
{
    class Threading
    {
        void show()
        {
            for(int i=0;i<5;i++)
            {
                lock(this)
                {
                    Console.WriteLine("*** Child Thread ***");
                    Thread.Sleep(2000);
                }
            }
        }
        public static void Main()
        {
           for(int i=0;i<5;i++)
            {
                Console.WriteLine("*** Main thread ***");
            }
            // creating thread
            Threading t = new Threading();
            Thread t1 = new Thread(t.show);
            Thread t2 = new Thread(t.show);

            // another way to create thread
            // Task t2 = Task.Run(() => t.show());
            t1.Start();
            t2.Start();
            t1.Join();
            Console.ReadKey();
        }
    }
}
