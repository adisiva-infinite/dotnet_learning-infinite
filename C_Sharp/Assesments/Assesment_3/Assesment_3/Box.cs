using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace program1
{
    // Write a class Box 
    class Box
    {
        // that has Length and breadth as its members
        public int length { get; set; }
        public int breadth { get; set; }

        // function that adds 2 box objects and stores in the 3rd.
        public void Addboxes(Box box1, Box box2)
        {
            this.length = box1.length + box2.length;
            this.breadth = box1.breadth + box2.breadth;

        }
        // Display the 3rd object details
        public void Display()
        {
            Console.WriteLine($"Length {length} and Breadth is {breadth}");
        }
    }
    class Test
    {
        public static void Main(string[] args)
        {
            // Creating object for class
            Box box1 = new Box();
            Box box2 = new Box();
            Box box3 = new Box();

            // Entering Box1 details 
            Console.WriteLine("Enter Length & Breadth of Box-1 : ");
            Console.WriteLine();
            Console.Write("Length of Box1 : ");
            box1.length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Breadth of Box1 : ");
            box1.breadth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            // Entering box 2 details
            Console.WriteLine("Enter Length & Breadth of Box-2 : ");
            Console.WriteLine();
            Console.Write("Length of Box2 : ");
            box2.length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Breadth of Box2 : ");
            box2.breadth = Convert.ToInt32(Console.ReadLine());

            box3.Addboxes(box1, box2);

            Console.WriteLine();
            Console.WriteLine("*** Result of Third Box ***");
            box3.Display();
            Console.ReadLine();


        }
    }
}