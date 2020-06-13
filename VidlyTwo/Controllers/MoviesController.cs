using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Models;
using VidlyTwo.Services;
using VidlyTwo.ViewModels;

namespace VidlyTwo.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private readonly IMovieRepository _context;

        public MoviesController()
        {
            _context = new MovieRepository();
        }

        public ActionResult Index()
        {
            return View(_context.Movies());
        }

        public ActionResult Details(int id)
        {
            var movie = _context.MovieById(id);
            if (movie == null) return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel
            {
                Genres = _context.Genres()
            };

            return View("MovieForm", movieFormViewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Add(movie);
            }
            else
            {
                _context.Save(movie);
            }


            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.MovieById(id);

            var movieFormViewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres()
            };

            return View("MovieForm", movieFormViewModel);
        }
    }
}