using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        //localhost:7033
        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                PopularMovies = MovieRepository.Movies
            };

            return View(model);
        }
        //localhost:7033/about
        public IActionResult About()
        {
            return View();
        }
    }
}
