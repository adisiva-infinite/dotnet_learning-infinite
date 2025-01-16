using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce_Client.Models;

namespace Ecommerce_Client.Controllers.Customer_Panel
{
    public class OrderController : Controller
    {
        private EcommerceEntities db = new EcommerceEntities();

        public ActionResult CustomerOrders()
        {
            if (Session["CustomerId"] == null || Session["Role"]?.ToString() == "Admin")
            {
                ViewBag.Message = "You do not have access to the Order history until you login as Customer...!";
                return View("AcceSSdenied");
            }

            if (Session["CustomerId"] == null)
            {
                return RedirectToAction("Login", "CustomerLogin");
            }

            int customerId = (int)Session["CustomerId"];

            // Fetch all orders for the logged-in customer along with their details
            var customerOrders = db.Orders
                .Where(o => o.CustomerId == customerId)
                .Select(o => new CustomerOrderViewModel
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    ShipDate = o.ShipDate,
                    OrderDetails = db.OrderDetails
                        .Where(od => od.OrderId == o.OrderId)
                        .Select(od => new OrderDetailViewModel
                        {
                            ProductImage = db.Products.FirstOrDefault(p=>p.ProductId == od.ProductId).ProductImage,
                            ProductName = db.Products.FirstOrDefault(p => p.ProductId == od.ProductId).ProductName,
                            Quantity = od.Quantity,
                            UnitCost = od.UnitCost,
                            TotalCost = od.Quantity * od.UnitCost
                        }).ToList()
                }).ToList();

            return View(customerOrders);
        }
    }

    // ViewModel for Customer Orders
    public class CustomerOrderViewModel
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime? ShipDate { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }

    // ViewModel for Order Details
    public class OrderDetailViewModel
    {
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost { get; set; }
    }
}