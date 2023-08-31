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
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context.Movies.Select(m => new AdminEditMovieViewModel()
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl
            }).FirstOrDefault(m => m.MovieId == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel model)
        {
            var entity = _context.Movies.Find(model.MovieId);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Title=model.Title;
            entity.Description = model.Description;
            entity.ImageUrl=model.ImageUrl;

            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel()
            {
                Movies = _context.Movies.Include(m => m.Genres).Select(m => new AdminMovieViewModel()
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
