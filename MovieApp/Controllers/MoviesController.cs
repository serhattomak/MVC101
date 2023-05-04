using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    //controller
    public class MoviesController : Controller
    {
        //action
        //localhost:7033/movies/list
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var model = new MoviesViewModel()
            {
                Movies = MovieRepository.Movies
            };

            return View("Movies", model);
        }

        //localhost:7033/movies/details/
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }
    }
}
