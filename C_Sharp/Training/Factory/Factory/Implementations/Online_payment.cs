using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory_2.Factories;

namespace Factory.Implementations
{
    class Online_payment : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Payment processing thru Netbanking for an amount of {amount}");
        }
    }
}
