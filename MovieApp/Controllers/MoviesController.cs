using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    //controller
    public class MoviesController : Controller
    {
        //action
        //localhost:7033/movies/list
        public string List()
        {
            return "Movie List";
        }

        //localhost:7033/movies/details
        public string Details()
        {
            return "Movie Detail";
        }
    }
}
