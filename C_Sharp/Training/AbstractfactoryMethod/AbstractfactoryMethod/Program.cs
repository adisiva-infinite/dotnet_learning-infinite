using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractfactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = null;
            AnimalFactory animal_factory = null;
            string sound = null;

            Console.Write("Enter type of the animal (Land / Sea ) : ");
            string animal_type = Console.ReadLine();

            // creating factory obj
            animal_factory = AnimalFactory.CreateAnimalFactory(animal_type);
            Console.WriteLine($"Animal type choosen is {animal_factory.GetType().Name}");

            //  creating animal obj
            Console.Write("Enter the animal : ");
            string animal_name = Console.ReadLine();

            animal = animal_factory.GetAnimal(animal_name);
            Console.WriteLine($"User choosen animal is {animal_name}");

            sound = animal.Speak();
            Console.WriteLine($"The Sound of the {animal} comming from the Factory {animal_factory} is {sound}");
            Console.Read();
        }
    }
}
