using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Client.Models
{
    public class CartViewModel
    {
        public int CustomerId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public class CartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public float Price { get; set; }
        }
    }
}