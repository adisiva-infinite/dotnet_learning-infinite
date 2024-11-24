using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_example
{
    class Anonymous_Methods
    {
        public delegate string CardsDelegate(string name);
        //public static string Card(string C_name)
        //{
        //    return $"Hi {C_name} Good Morning...";
        //}
        static void Main(string[] args)
        {
            //CardsDelegate c1 = Card;
            //string str = c1.Invoke("Adi Siva Naidu");
            //Console.WriteLine(str);
            //Console.WriteLine();
            //string user1 = Console.ReadLine();
            //string str1 = c1.Invoke(user1);
            //Console.WriteLine(str1);

            CardsDelegate c1 = delegate (string C_name) // Anonymous method using delegate keyword
            {
                return $"Hi {C_name} Good Morning...";
            };
            string str = c1.Invoke("Adi Siva Naidu");
            Console.WriteLine(str);
            Console.WriteLine();
            string user1 = Console.ReadLine();
            string str1 = c1.Invoke(user1);
            Console.WriteLine(str1);

            Console.Read();
        }
    }
}
