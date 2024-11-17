using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6_ClassLibrary_
{
    public class Class1
    {
        private const int totalfare = 500;
        public void CalculateConcession(int age)
        {
            if (age <= 5) Console.WriteLine("Little Champs - Free Ticket");
            else if (age > 60)
            {
                float concession = totalfare * 0.30f;
                float finalfare = totalfare - concession;
                Console.WriteLine("Senior citizen" + finalfare);
            }
            else Console.WriteLine("Ticket Booked" + totalfare);
        }
    }
}
