using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Client.Models
{
    public class CategoryProductsViewModel
    {
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}