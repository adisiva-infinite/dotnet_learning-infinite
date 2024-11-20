using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractfactoryMethod
{
    class LandAnimalFactory : AnimalFactory
    {
        public override IAnimal GetAnimal(string animal_type)
        {
            if (animal_type.Equals("Dog"))
            {
                return new Dog();
            }
            else if (animal_type.Equals("Cat"))
            {
                return new Cat();
            }
            else
                return null;
        }
    }
}
