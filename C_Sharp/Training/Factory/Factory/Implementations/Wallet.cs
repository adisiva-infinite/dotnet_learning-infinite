using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory_2.Factories;

namespace Factory.Implementations
{
    class Wallet
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Payment processing thru wallet for an amount of {amount}");
        }
    }
}
