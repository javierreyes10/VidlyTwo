using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Models;
using VidlyTwo.Services;

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

    }
}