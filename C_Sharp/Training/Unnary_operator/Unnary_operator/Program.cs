using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unnary_operator
{
    class Program
    {
        class Distance
        {
            public int dist;
            public string distinkm;

            //operator '+' is overloaded
            public static Distance operator +(Distance d1, Distance d2)
            {
                Distance temp = new Distance();
                temp.dist = d1.dist + d2.dist;
                return temp;
            }
        }
        class Operator_Overloading
        {
            static void Main()
            {
                int a = 5, b = 10, c = 0;
                c = a + b;
                c++;
                Console.WriteLine(c);

                Console.WriteLine("---------------");
                Distance d1, d2, d3;
                d1 = new Distance();
                d1.dist = 10;
                d2 = new Distance();
                d2.dist = 20;
                d3 = new Distance();
                d3 = d1 + d2;
                d3.dist++;
                Console.WriteLine("The Total Distance is {0}", d3.dist);
                Console.Read();
            }
        }
    }
}
