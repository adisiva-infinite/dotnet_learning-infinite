using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Client.Models
{
    public class CheckoutViewModel
    {
        public int CustomerId { get; set; }
        public List<CartViewModel.CartItem> CartItems { get; set; }
        public float TotalAmount { get; set; }
    }
}