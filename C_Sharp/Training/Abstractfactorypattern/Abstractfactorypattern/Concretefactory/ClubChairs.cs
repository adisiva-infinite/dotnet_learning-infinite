using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractfactorypattern.Abstractfactory;

namespace Abstractfactorypattern.Concretefactory
{
    class ClubChairs : IChair
    {
        public void Sit()
        {
            Console.WriteLine("Details of Club Chairs...");
        }
    }
}
