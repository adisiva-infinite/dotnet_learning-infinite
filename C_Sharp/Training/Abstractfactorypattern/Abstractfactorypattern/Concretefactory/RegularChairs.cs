using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractfactorypattern.Abstractfactory;

namespace Abstractfactorypattern.Concretefactory
{
    public class RegularChairs : IChair
    {
        public void Sit()
        {
            Console.WriteLine("Details of Regular Chairs...");
        }
    }
}
