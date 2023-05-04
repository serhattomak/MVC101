using MovieApp.Models;
namespace MovieApp.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            new Genre { GenreId = 1, Name = "adventure" },
            new Genre { GenreId = 2, Name = "Comedy" },
            new Genre { GenreId = 3, Name = "Action" },
            new Genre { GenreId = 4, Name = "Sci-Fi" }
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
