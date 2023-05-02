using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var genreList = new List<Genre>()
            {
                new Genre {Name = "Adventure"},
                new Genre {Name = "Comedy"},
                new Genre {Name = "Action"},
                new Genre {Name = "Sci-Fi"}
            };

            return View(genreList);
        }
    }
}
