using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractfactorypattern.Abstractfactory;

namespace Abstractfactorypattern.factories
{
    public interface FurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }
}
