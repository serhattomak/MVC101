﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Entity;
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
                ImageUrl = m.ImageUrl,
                SelectedGenres = m.Genres
            }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel model, int[] genreIds)
        {
            var entity = _context.Movies.Include("Genres").FirstOrDefault(m => m.MovieId == model.MovieId);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList();

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

        public IActionResult GenreList()
        {
            return View(new AdminGenresViewModel()
            {
                Genres = _context.Genres.Select(g => new AdminGenreViewModel()
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count
                }).ToList()
            });
        }

        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context.Genres
                .Select(g => new AdminGenreEditViewModel()
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Movies = g.Movies.Select(i => new AdminMovieViewModel()
                    {
                        MovieId = i.MovieId,
                        Title = i.Title,
                        ImageUrl = i.ImageUrl
                    }).ToList()
                })
                .FirstOrDefault(g => g.GenreId == id);

            if (entity==null)
            {
                return NotFound();
            }

            return View(entity);
        }
    }
}
