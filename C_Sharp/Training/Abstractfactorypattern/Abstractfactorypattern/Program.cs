using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractfactorypattern.factories;
using Abstractfactorypattern.Abstractfactory;

namespace Abstractfactorypattern
{
    class Program
    {
        static void Main(string[] args)
        {
            FurnitureFactory Ffactory = new RegularProducts();
            Console.WriteLine("Enter Product type (Regular / Recliner) : ");
            string a = Console.ReadLine();

            if (a.Equals("Regular")) Ffactory = new RegularProducts();
            else if (a.Equals("Recliner")) Ffactory = new ReclinerProducts();

            Console.WriteLine("Enter Product type (Chair / Sofa) : ");
            string b = Console.ReadLine();

            if(b.Equals("Chair"))
            {
                IChair chair = Ffactory.CreateChair();
                chair.Sit();
            }
            else if(b.Equals("Sofa"))
            {
                ISofa sofa = Ffactory.CreateSofa();
                sofa.LayOn();
            }
            Console.ReadLine();
        }
    }
}
