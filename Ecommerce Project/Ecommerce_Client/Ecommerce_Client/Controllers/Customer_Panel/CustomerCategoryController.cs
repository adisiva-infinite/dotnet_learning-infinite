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
                if (Session["CustomerId"] == null)
                {
                    return RedirectToAction("Login", "CustomerLogin");
                }

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
                if (Session["CustomerId"] == null)
                {
                    return RedirectToAction("Login", "CustomerLogin");
                }

                // Retrieve the category by its ID
                var category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                if (category == null)
                {
                    return HttpNotFound("Category not found.");
                }

                var products = db.Products.Where(p => p.CategoryId == categoryId).ToList();

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
