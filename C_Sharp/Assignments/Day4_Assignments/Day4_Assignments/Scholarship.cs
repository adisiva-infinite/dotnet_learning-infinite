using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Assignments
{
    class MarksException : ApplicationException
    {
        public MarksException(string msg) { }
    }
    class Scholarship
    {
        int amount;
        public int Merit(int M, int F)
        {
            if (M > 100) throw new MarksException("marks show be in below or equal to 100");
            else
            {
               return amount = (M >= 70 && M <= 80) ? (F * 20 / 100) : (M > 80 && M <= 90) ? (F * 30 / 100) : (M > 90) ? (F * 50 / 100) : 0;
            }
        }
        static void Main()
        {
            Scholarship s1 = new Scholarship();
            try
            {
            Console.Write("Enter the marks of the student : ");
            int M = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the College Fee : ");
            int F = Convert.ToInt32(Console.ReadLine());
            s1.Merit(M,F);
            }
            catch(MarksException e)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Enter a marks between 0 to 100 ",e.Message);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Scholarship amount for student is : {0}", s1.amount);
            Console.ReadKey();

        }
    }
}
