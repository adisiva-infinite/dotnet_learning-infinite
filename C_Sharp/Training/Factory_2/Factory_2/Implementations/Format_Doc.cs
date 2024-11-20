using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDocumentConverter.Factories;

namespace IDocumentConverter.Implementations
{
    public class Format_Doc : IText_gateway
    {
        public void Textformat(string name)
        {
            Console.WriteLine($"Given {name} will changed to doc format");
        }
    }
}
