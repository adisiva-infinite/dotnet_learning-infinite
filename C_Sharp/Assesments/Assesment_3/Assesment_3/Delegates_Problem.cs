using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_3
{
    class Delegates_Problem
    {
        public delegate int Calculate(int a, int b);
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a , int b)
        {
            return a * b;
        }
        public static void Perform(Calculate cl, int a, int b)
        {
            int Result = cl(a, b);
            Console.WriteLine(Result);
        }

        public static void Main()
        {
            Console.Write("Enter value of A : ");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter value of B : ");
            int B = Convert.ToInt32(Console.ReadLine());

            Delegates_Problem.Calculate Add = new Delegates_Problem.Calculate(Delegates_Problem.Sum);
            Delegates_Problem.Calculate Sub = new Delegates_Problem.Calculate(Delegates_Problem.Subtract);
            Delegates_Problem.Calculate Multiplication = new Delegates_Problem.Calculate(Delegates_Problem.Multiply);

            Console.WriteLine();
            Console.WriteLine("*** Result of Two Values ***");
            Console.Write("Sum of two values : ");
            Delegates_Problem.Perform(Add, A, B);
            Console.Write("Sub of two values : ");
            Delegates_Problem.Perform(Sub, A, B);
            Console.Write("Multiplication of two value is : ");
            Delegates_Problem.Perform(Multiplication, A, B);

            Console.ReadKey();



        }
    }
}
