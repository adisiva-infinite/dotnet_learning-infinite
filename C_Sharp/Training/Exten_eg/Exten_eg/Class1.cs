using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exten_eg
{
    public static class Class1
    {     
        public static void Show_data(this Class2 c)
        {
            Console.WriteLine("show data");
            string x = Console.ReadLine();
            Console.WriteLine(x);
        }
    }
}
