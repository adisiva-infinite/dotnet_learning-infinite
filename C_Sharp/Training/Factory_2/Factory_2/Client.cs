using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDocumentConverter.Factories;

namespace IDocumentConverter
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your method (Doc / Pdf / Txt ) : ");
            string format_name = Console.ReadLine();
            string x = Console.ReadLine();
            try
            {
                IText_gateway pg = Text_gateway_factory.CreateText_gateway(format_name);
                pg.Textformat(x);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            Console.Read();
        }
    }
}
