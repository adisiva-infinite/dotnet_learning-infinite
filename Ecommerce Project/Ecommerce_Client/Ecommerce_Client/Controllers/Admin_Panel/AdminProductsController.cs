using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Ecommerce_Client.Models;
 
namespace Ecommerce_Client.Controllers.Admin_Panel
{
    public class AdminProductsController : Controller
    {
        private readonly EcommerceEntities db = new EcommerceEntities();
 
        // GET: Product (List all products)
        public ActionResult Index()
        {
            try
            {
                var products = db.Products.Include("Category").ToList(); // Including Category details
                return View(products);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while retrieving the product list.");
            }
        }
 
        // GET: Product/Details/5 (View product details)
        public ActionResult Details(int id)
        {
            try
            {
                var product = db.Products.Include("Category").FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while retrieving the product details.");
            }
        }
 
        // GET: Product/Create (Create new product)
        public ActionResult Create()
        {
            try
            {
                ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
                return View();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while preparing the create product page.");
            }
        }
 
        // POST: Product/Create (Save new product)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
 
                // Repopulate dropdown on error
                ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
                return View(product);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                // Handle validation errors from Entity Framework
                foreach (var validationError in dbEx.EntityValidationErrors.SelectMany(e => e.ValidationErrors))
                {
                    ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                    System.Diagnostics.Debug.WriteLine($"Validation Error: {validationError.PropertyName} - {validationError.ErrorMessage}");
                }
 
                ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
                return View(product);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while creating the product.");
            }
        }
 
        // GET: Product/Edit/5 (Edit existing product)
        public ActionResult Edit(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
 
                ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
                return View(product);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while preparing the edit product page.");
            }
        }
 
        // POST: Product/Edit/5 (Update product)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
 
                ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
                return View(product);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new HttpStatusCodeResult(500, "An error occurred while updating the product.");
            }
        }  

        //// GET: Product/Delete/5 (Delete product)
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var product = db.Products.Find(id);
        //        if (product == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
        //        return new HttpStatusCodeResult(500, "An error occurred while preparing the delete product page.");
        //    }
        //}

        //// POST: Product/Delete/5 (Confirm delete product)
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        var product = db.Products.Find(id);
        //        if (product == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        db.Products.Remove(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
        //        return new HttpStatusCodeResult(500, "An error occurred while deleting the product.");
        //    }
        //}

         // GET: Product/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
 
        Product product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return HttpNotFound();
        }
 
        return View(product);
    }
 
    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Product product = db.Products.Find(id);
 
        if (product == null)
        {
            return HttpNotFound();
        }
 
        db.Products.Remove(product);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}