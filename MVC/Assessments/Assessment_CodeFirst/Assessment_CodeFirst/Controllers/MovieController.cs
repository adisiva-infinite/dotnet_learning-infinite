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
        IMovieRepository _mv = null;

        public MovieController()
        {
            _mv = new MovieRepository();
        }
        public ActionResult Index()
        {
            var mvd = _mv.GetAll();
            return View(mvd);
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
                _mv.Create(m);
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            var movie = _mv.GetById(id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                _mv.Edit(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }

        public ActionResult Details(int id)
        {
            var moviedetails = _mv.GetById(id);
            return View(moviedetails);
        }

        // Display movies by year
        public ActionResult MoviesByYear(int year)
        {
            var movies = _mv.GetAllMoviesByYear(year);
            return View(movies);
        }
    }
}