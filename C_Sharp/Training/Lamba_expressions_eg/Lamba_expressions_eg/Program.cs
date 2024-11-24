

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamba_expressions_eg
{ 
    class Program
    {
        public delegate string CardDelegate(string name);
        static void Main(string[] args)
        {
            CardDelegate cd1 = delegate (string C_name)
            {
                return $"Hello {C_name}";
            };
            string s1 = cd1.Invoke("Adi Siva Naidu");
            Console.WriteLine(s1);
            Console.ReadKey();
        }
    }
}
