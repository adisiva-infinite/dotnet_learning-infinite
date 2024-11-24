using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_example
{
    class Rectangle
    {
        public delegate void RectDelegate(double W, double H);
        public void GetArea(double W, double H)
        {
            Console.WriteLine($"Area of the rectangle : {W * H}");
        }
        public void GetPerimeter(double W,double H)
        {
            Console.WriteLine($"Perimeter of the rectangle : {2 * (W + H)}");
        }
        static void Main()
        {
            Rectangle r1 = new Rectangle();
            //r1.GetArea(7.8, 21.7);
            //r1.GetPerimeter(7.8, 21.7);
            RectDelegate rect1 = new RectDelegate(r1.GetArea);
            //rect1.Invoke(7.8, 21.7);

            RectDelegate rect2 = r1.GetArea; 
            //rect1.Invoke(8.8, 29.7);

            rect1 += r1.GetPerimeter;
            rect1.Invoke(8.8, 29.7);
            Console.WriteLine();

            rect1.Invoke(9.4, 39.5);
            Console.Read();
        }
    }
}
