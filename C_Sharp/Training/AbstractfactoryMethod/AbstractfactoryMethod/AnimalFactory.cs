using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractfactoryMethod
{
    public abstract class AnimalFactory
    {
        public abstract IAnimal GetAnimal(string animal_type);

        public static AnimalFactory CreateAnimalFactory(string factory_type)
        {
            if (factory_type.Equals("Land")) return new LandAnimalFactory();
            else if (factory_type.Equals("Sea")) return new SeaAnimalFactory();
            else return null;
        }
    }
}
