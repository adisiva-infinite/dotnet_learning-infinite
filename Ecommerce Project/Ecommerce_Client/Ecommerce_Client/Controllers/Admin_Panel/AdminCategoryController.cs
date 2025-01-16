using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Ecommerce_Client.Models;

namespace Ecommerce_Client.Controllers.Admin_Panel
{
    public class AdminCategoryController : Controller
    {
        private readonly EcommerceEntities db = new EcommerceEntities();

        // GET: Categories
        public ActionResult Index()
        {
            try
            {
                return View(db.Categories.ToList());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while retrieving the categories.");
            }
        }

        public ActionResult ShowProducts(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                // Fetch the category and its related products
                var category = db.Categories.Include("Products").FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return HttpNotFound();
                }

                return View(category);
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while retrieving the category details.");
            }
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while preparing the create category page.");
            }
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,Description,ProductImage")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Add the category to the database
                    db.Categories.Add(category);
                    // Save changes to the database
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");

                ModelState.AddModelError("", "An error occurred while saving the category. Please try again later.");
            }
            return View(category);
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                throw; 
            }
        }
    }
}