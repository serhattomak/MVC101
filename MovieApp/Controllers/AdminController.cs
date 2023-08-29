using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class AdminController : Controller
    {
        public readonly MovieContext _context;

        public AdminController(MovieContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel()
            {
                Movies = _context.Movies.Include(m=>m.Genres).Select(m=> new AdminMovieViewModel()
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    Genres = m.Genres.ToList()
                }).ToList()
            });
        }
    }
}
