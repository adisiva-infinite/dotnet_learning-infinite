using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractfactorypattern.Abstractfactory;

namespace Abstractfactorypattern.Concretefactory
{
    class RegularSofa : ISofa
    {
        public void LayOn()
        {
            Console.WriteLine("Details of Regular Sofa...");
        }
    }
}
