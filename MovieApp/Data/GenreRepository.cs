using MovieApp.Entity;
using MovieApp.Models;
namespace MovieApp.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre { GenreId = 1, Name = "Adventure" },
                new Genre { GenreId = 2, Name = "Comedy" },
                new Genre { GenreId = 3, Name = "Action" },
                new Genre { GenreId = 4, Name = "Sci-Fi" },
                new Genre { GenreId = 5, Name = "Drama" }
            };
        }

        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(g => g.GenreId == id);
        }
    }
}
