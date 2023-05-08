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

        //localhost:7033/movies/list
        //localhost:7033/movies/list/1
        public IActionResult List(int? id, string q)
        {
            // {controller}/{action}/{id?}
            // movies/list/2

            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];
            //var word = HttpContext.Request.Query["q"].ToString();

            var movies = MovieRepository.Movies;

            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i => i.Title.ToLower().Contains(q.ToLower()) || i.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MoviesViewModel()
            {
                Movies = movies
            };

            return View("Movies", model);
        }

        //localhost:7033/movies/details/1
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
