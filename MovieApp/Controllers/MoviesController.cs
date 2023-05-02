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
                new Movie(){Title = "Movie 1", Description = "Description 1", Director = "Director 1", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "1.jpg"},
                new Movie(){Title = "Movie 2", Description = "Description 2", Director = "Director 2", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "2.jpg"},
                new Movie(){Title = "Movie 3", Description = "Description 3", Director = "Director 3", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "3.jpg"}
            };

            var genreList = new List<Genre>()
            {
                new Genre {Name = "Adventure"},
                new Genre {Name = "Comedy"},
                new Genre {Name = "Action"},
                new Genre {Name = "Sci-Fi"}
            };

            var model = new MovieGenreViewModel()
            {
                Movies = movieList, Genres = genreList
            };

            return View("Movies", model);
        }

        //localhost:7033/movies/details
        public string Details()
        {
            return "Movie Detail";
        }
    }
}
