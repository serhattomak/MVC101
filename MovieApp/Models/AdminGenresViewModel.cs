using Microsoft.AspNetCore.Mvc;
using MovieApp.Entity;

namespace MovieApp.Models
{
    public class AdminGenresViewModel : Controller
    {
        public List<AdminGenreViewModel> Genres { get; set; }
    }

    public class AdminGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
