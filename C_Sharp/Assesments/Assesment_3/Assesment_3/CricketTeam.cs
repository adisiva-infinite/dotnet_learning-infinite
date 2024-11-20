using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_3
{
    // Create a Class called CricketTeam
    public class CricketTeam
    {
        public string Team_name { get; set; }
        public int Matches { get; set; }
        public int Sum { get; set; }
        public double Average { get; set; }
        public (int, int, double) PointsCalculation(int no_of_matches)
        {
            Sum = 0;
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter score of match {i + 1}: ");
                Sum += Convert.ToInt32(Console.ReadLine());
            }
            Matches = no_of_matches;
            Average = (double)Sum / no_of_matches;
            return (Matches, Sum, Average);
        }
    }
    class Program
    {
        static void Main()
        {
            CricketTeam t1 = new CricketTeam();
            Console.Write("Enter any Team Name : ");
            string T_name = Console.ReadLine();
            t1.Team_name = T_name;
            Console.Write("Enter number of matches: ");
            int noOfMatches = Convert.ToInt32(Console.ReadLine());
            var (matches, sum, average) = t1.PointsCalculation(noOfMatches);
            Console.WriteLine($"Team: {t1.Team_name}");
            Console.WriteLine($"Matches : {matches}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {average}");
            Console.ReadKey();
        }
    }
}
