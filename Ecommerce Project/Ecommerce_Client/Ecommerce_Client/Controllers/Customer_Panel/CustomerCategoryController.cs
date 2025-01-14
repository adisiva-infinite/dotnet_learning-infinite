using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce_Client.Models;

namespace Ecommerce_Client.Controllers.Customer_Panel
{
    public class CustomerCategoryController : Controller
    {
        private readonly EcommerceEntities db = new EcommerceEntities();

        // GET: CustomerCategory
        public ActionResult SelectCategory()
        {
            try
            {
                // Check if the customer is logged in (i.e., CustomerId is in session)
                if (Session["CustomerId"] == null)
                {
                    // If not logged in, redirect to login page
                    return RedirectToAction("Login", "CustomerLogin");
                }

                // If logged in, display the categories
                var categories = db.Categories.ToList();
                return View(categories);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while retrieving the categories.");
            }
        }

        // Action to get products by category
        public ActionResult ProductsByCategory(int categoryId)
        {
            try
            {
                // Check if the customer is logged in (i.e., CustomerId is in session)
                if (Session["CustomerId"] == null)
                {
                    // If not logged in, redirect to login page
                    return RedirectToAction("Login", "CustomerLogin");
                }

                // Retrieve the category by its ID
                var category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                if (category == null)
                {
                    return HttpNotFound("Category not found.");
                }

                // Retrieve the products of that category
                var products = db.Products.Where(p => p.CategoryId == categoryId).ToList();

                // Pass the category name and the list of products to the view
                ViewBag.CategoryName = category.CategoryName;
                return View(products);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while retrieving the products.");
            }
        }
    }
}
