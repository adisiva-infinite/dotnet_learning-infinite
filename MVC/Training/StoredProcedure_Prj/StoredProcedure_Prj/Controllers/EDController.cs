using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoredProcedure_Prj.Models;
using System.Data.Entity;

namespace StoredProcedure_Prj.Controllers
{
    public class EDController : Controller
    {
        EDContext db = new EDContext();
        // GET: ED
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Employee e = db.Employees.Find(Id);
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if(ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }

        public ActionResult Delete(int Id)
        {
            var emp = db.Employees.Find(Id);
            if (emp != null)
            {
                return View(emp);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Employee e)
        {
            var emp = db.Employees.Find(e.Id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }

            return RedirectToAction("Index"); ;
        }

        public ActionResult Details(int Id)
        {
            Employee e = db.Employees.Find(Id);
            return View(e);
        }

        [HttpGet]
        public ActionResult Details(Employee e)
        {
            var emp = db.Employees.Find(e.Id);
            if (emp != null)
            {
                return View(emp);
            }
            return RedirectToAction("Index");
        }

    }
}