using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(GenreRepository.Genres);
        }
    }
}
