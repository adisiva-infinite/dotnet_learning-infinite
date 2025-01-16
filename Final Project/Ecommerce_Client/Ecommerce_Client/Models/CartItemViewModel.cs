using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Client.Models
{
    public class CartItemViewModel
    {
        public string ProductName { get; set; }
        public string ModelNumber { get; set; }
        public int Quantity { get; set; }
        public float UnitCost { get; set; }
        public float SubTotal { get; set; }
    }
}