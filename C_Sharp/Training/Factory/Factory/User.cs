using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory_2.Factories;

namespace Factory
{
    class User
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your payment method (netbanking / wallet / cod ) : ");
            string payment_name = Console.ReadLine();

            try
            {
                IPaymentGateway pg = PaymentGatewayFactory.CreatePaymentGateway(payment_name);
                pg.ProcessPayment(2500.50m);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            Console.Read();
        }
    }
}
