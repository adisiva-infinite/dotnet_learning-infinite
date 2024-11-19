using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    class Max_min_avg
    {
        static void Main()
        {
            Console.Write("Enter value 1 : ");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter value 2 : ");
            double n2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter value 3 : ");
            double n3 = Convert.ToDouble(Console.ReadLine());
            (double max, double min, double avg) = calculate(n1, n2, n3);
            Console.WriteLine();
            Console.WriteLine($"Maximum value is : {max}");
            Console.WriteLine($"Minumum value is : {min}");
            Console.WriteLine($"Average : {avg}");
            Console.ReadLine();
        }
        static (double, double, double) calculate(double a, double b, double c)
        {
            double max = Math.Max(a, Math.Max(b, c));
            double min = Math.Min(a, Math.Min(b, c));
            double avg = (a + b + c) / 3;
            return (max, min, avg);
        }
    }
  }
