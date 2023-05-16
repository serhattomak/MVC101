﻿using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent: ViewComponent
    {
        private readonly MovieContext _context;

        public GenresViewComponent(MovieContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];

            return View(_context.Genres.ToList());
        }
    }
}
