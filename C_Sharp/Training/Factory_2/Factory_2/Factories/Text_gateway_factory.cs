using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDocumentConverter.Factories;
using IDocumentConverter.Implementations;

namespace IDocumentConverter.Factories
{
    public static class Text_gateway_factory
    {
        public static IText_gateway CreateText_gateway(string name)
        {
            switch (name.ToLower())
            {
                case "doc":
                    return new Format_Doc();
                case "pdf":
                    return new Format_pdf();
                case "txt":
                    return new Format_txt();
                default: throw new ArgumentException("Invalid Gateway Choosen..");
            }
        }
    }
}
