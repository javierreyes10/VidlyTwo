using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTwo.Services;

namespace VidlyTwo.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movieViewService = new MovieService();
            var movies = movieViewService.Movies();

            return View(movies);
        }
    }
}