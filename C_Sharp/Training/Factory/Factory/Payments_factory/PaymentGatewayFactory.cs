﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Implementations;

namespace Factory_2.Factories
{
    public static class PaymentGatewayFactory
    {
        public static IPaymentGateway CreatePaymentGateway(string gatewayName)
        {
            switch (gatewayName.ToLower())
            {
                case "wallet":
                    return new Wallet();
                case "netbanking":
                    return new Online_payment();
                case "cod":
                    return new COD();
                default: throw new ArgumentException("Invalid Gateway Choosen..");
            }
        }

    }
}