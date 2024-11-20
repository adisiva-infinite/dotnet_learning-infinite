using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractfactoryMethod
{
    class SeaAnimalFactory : AnimalFactory
    {
        public override IAnimal GetAnimal(string animal_type)
        {
            if (animal_type.Equals("Shark"))
            {
                return new Shark();
            }
            else if (animal_type.Equals("Octopus"))
            {
                return new Octopus();
            }
            else
                return null;
        }
    }
}
