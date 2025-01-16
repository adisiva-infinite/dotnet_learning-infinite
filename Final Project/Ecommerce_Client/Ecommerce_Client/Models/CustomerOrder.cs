using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Client.Models
{
    public class CustomerOrder
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime? ShipDate { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }
}