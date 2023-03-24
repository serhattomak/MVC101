using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        //localhost:7033
        public string Index()
        {
            return "Homepage";
        }
        //localhost:7033/about
        public string About()
        {
            return "About us";
        }
    }
}
