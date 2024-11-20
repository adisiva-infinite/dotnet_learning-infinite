using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractfactorypattern.Abstractfactory;
using Abstractfactorypattern.Concretefactory;

namespace Abstractfactorypattern.factories
{
    public class ReclinerProducts : FurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ClubChairs();
        }

        public ISofa CreateSofa()
        {
            return new ReclinerSofa();
        }
    }
}
