using Microsoft.AspNetCore.Mvc;
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
            var movieList = new List<Movie>()
            {
                new Movie(){Title = "Movie 1", Description = "Description 1", Director = "Director 1", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "inceptionposter.jpg"},
                new Movie(){Title = "Movie 2", Description = "Description 2", Director = "Director 2", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "interstellarposter.jpg"},
                new Movie(){Title = "Movie 3", Description = "Description 3", Director = "Director 3", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "johnwick4poster.jpg"}
            };
            return View("Movies",movieList);
        }

        //localhost:7033/movies/details
        public string Details()
        {
            return "Movie Detail";
        }
    }
}
