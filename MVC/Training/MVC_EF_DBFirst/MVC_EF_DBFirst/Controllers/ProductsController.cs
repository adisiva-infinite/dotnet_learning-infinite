using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF_DBFirst.Models;
using System.Data;
using System.Data.Entity;

namespace MVC_EF_DBFirst.Controllers
{
    public class ProductsController : Controller
    {
        northwindEntities db = new northwindEntities();
        // GET: Products
        public ActionResult Index()
        {
            //we will use a concept of eager loading of the category model along with the supplier model

            var product = db.Products.Include(p1 => p1.Category).Include(p1 => p1.Supplier);
            return View(product.ToList());
        }

        //insertion of products

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //for the category and supplier dropdown

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName",p.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", p.SupplierID);
            return View(p);
        }
    }
}