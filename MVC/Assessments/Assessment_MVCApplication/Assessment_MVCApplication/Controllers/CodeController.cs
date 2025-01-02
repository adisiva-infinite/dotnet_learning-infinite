using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment_MVCApplication.Models;

namespace Assessment_MVCApplication.Controllers
{
    public class CodeController : Controller
    {
        private northwindEntities db = new northwindEntities();
        // GET: Code
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // Action 1: Return all customers residing in Germany
        public ActionResult CustomersInGermany()
        {
            var Customers = db.Customers.Where(customers => customers.Country == "Germany").ToList();
            return View(Customers); 
        }

        // Action 2: Return customer details with orderId == 10248
        public ActionResult CustomerOrder()
        {
            var customerDetails = db.Orders
                                     .Where(order => order.OrderID == 10248)
                                     .Select(order => order.Customer)
                                     .FirstOrDefault();
            return View(customerDetails);
        }
    }
}