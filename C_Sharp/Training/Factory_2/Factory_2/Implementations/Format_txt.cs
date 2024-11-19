using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDocumentConverter.Factories;

namespace IDocumentConverter.Implementations
{
    class Format_txt:Text_gateway
    {
        public void Textformat(string name)
        {
            Console.WriteLine($"Given {name} will changed to txt format");
        }
    }
}
