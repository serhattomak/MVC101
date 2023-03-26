using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        //localhost:7033
        public IActionResult Index()
        {
            return View();
        }
        //localhost:7033/about
        public IActionResult About()
        {
            return View();
        }
    }
}
