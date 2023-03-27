using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        //localhost:7033
        public IActionResult Index()
        {
            string movieTitle = "Movie Title";
            string movieDescription = "Movie Description";
            string movieDirector = "Director";
            string[] actors = { "actor 1", "actor 2", "actor 3", "actor 4" };

            var m = new Movie();

            m.Title=movieTitle;
            m.Description=movieDescription;
            m.Director=movieDirector;
            m.Actors = actors;

            return View(m);
        }
        //localhost:7033/about
        public IActionResult About()
        {
            return View();
        }
    }
}
