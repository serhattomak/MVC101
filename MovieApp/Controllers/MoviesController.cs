using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    //controller
    public class MoviesController : Controller
    {
        //action

        public IActionResult Index()
        {
            return View();
        }
        //localhost:7033/movies/list
        public IActionResult List()
        {
            return View("Movies");
        }

        //localhost:7033/movies/details
        public string Details()
        {
            return "Movie Detail";
        }
    }
}
