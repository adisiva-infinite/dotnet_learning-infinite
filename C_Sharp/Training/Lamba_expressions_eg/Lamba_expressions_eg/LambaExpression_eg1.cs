using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lamba_expressions_eg.Program;

namespace Lamba_expressions_eg
{
    class LambaExpression_eg1
    {
        // In lamba expression no need to use delegate keyword and data type we can use lamba op =>
         static void Main()
        {
            //CardDelegate cd1 = delegate (string C_name)
            //{
            //    return $"Hello {C_name}";
            //}; returns Hello Adi Siva Naidu

            CardDelegate c1 =  (C_name) =>
            {
                return $"Hello {C_name}";
            };

            CardDelegate c2 = (C_name) => $"Hello {C_name}"; // Hello Adi Siva Naidu

            string s1 = c1.Invoke("Adi Siva Naidu");
            Console.WriteLine(s1);

            Console.WriteLine();
            string s2 = c2.Invoke("Adi Siva Naidu");
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }
}
