using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Client.Models
{
    public class OrderDetailViewModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost { get; set; }
    }
}