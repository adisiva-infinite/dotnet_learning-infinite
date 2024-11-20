using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class Extensions
    {
        public void input()
        {
            Console.WriteLine("input method:");
        }
        public void display()
        {
            Console.WriteLine("display method:");
        
        }
        public static void Main(String[] args)
        {
            Extensions e1 = new Extensions();
            e1.input();
            e1.display();
        }
    }
}
