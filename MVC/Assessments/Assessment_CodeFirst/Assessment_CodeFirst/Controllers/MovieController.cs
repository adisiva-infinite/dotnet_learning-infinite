using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment_CodeFirst.Models;
using Assessment_CodeFirst.Repository;

namespace Assessment_CodeFirst.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        IMovieRepository<Movie> mv = null;

        public MovieController()
        {
            mv = new MovieRepository<Movie>();
        }
        public ActionResult Index()
        {
            var mvd = mv.GetAll();
            return View(mv);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                mv.Create(m);
                mv.Save();
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Edit(int Id)
        {
            var movie = mv.GetById(Id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                mv.Update(m);
                mv.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }

        public ActionResult Details(int id)
        {
            var moviedetails = mv.GetById(id);
            return View(moviedetails);
        }
    }
}