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
            //Console.WriteLine("----------Regular Products--------");

            //Console.WriteLine("Enter Product type (Regular / Recliner) : ");
            //string a = Console.ReadLine();

            //Console.WriteLine("Enter Product type (Chair / Sofa) : ");
            //string b = Console.ReadLine();


            FurnitureFactory Ffactory = new RegularProducts();

            IChair chair = Ffactory.CreateChair();
            chair.Sit();

            ISofa sofa = Ffactory.CreateSofa();
            sofa.LayOn();

            Console.WriteLine("------Rec Products-------");

            FurnitureFactory recfactory = new ReclinerProducts();

            ISofa sofa1 = recfactory.CreateSofa();
            sofa1.LayOn();

            IChair c1 = recfactory.CreateChair();
            c1.Sit();

            Console.ReadLine();



        }
    }
}
