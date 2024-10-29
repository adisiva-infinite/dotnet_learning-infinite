using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_parameters
{
    class Program
    {
      
        public static int Calculator(int a, int b, out int sum, out int product, out int division)

        {
            sum = a + b;  //addition

            product = a * b;  //multiplication

            division = a / b; // division

            return a - b; // difference
        }
 
    }
 
    class Driver
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Output Parameters--------");

            int Total, Prod, Div, Difference;

            Difference = Program.Calculator(12, 6, out Total, out Prod , out Div);
            Console.WriteLine($" Sum = {Total} Prod = {Prod} Div ={Div}, and Difference ={Difference}");
            Console.Read();
        }
    }

}
