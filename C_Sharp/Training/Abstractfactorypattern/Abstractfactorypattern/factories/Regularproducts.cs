using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractfactorypattern.Abstractfactory;
using Abstractfactorypattern.Concretefactory;

namespace Abstractfactorypattern.factories
{
    public class RegularProducts : FurnitureFactory
    {
        public IChair CreateChair()
        {
            return new RegularChairs();
        }

        public ISofa CreateSofa()
        {
            return new RegularSofa();
        }
    }
}
