using MovieApp.Models;

namespace MovieApp.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie(){MovieId = 1, Title = "Inception", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", Director = "Christopher Nolan", Actors = new string[]{"Leonardo DiCaprio", "Joseph Gordon-Levitt"}, ImageUrl = "1.jpg", GenreId = 4},
                new Movie(){MovieId = 2, Title = "Interstellar", Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", Director = "Christopher Nolan", Actors = new string[]{"Matthew McConaughey", "Anne Hathaway"}, ImageUrl = "2.jpg", GenreId = 4},
                new Movie(){MovieId = 3, Title = "John Wick 4", Description = "John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.", Director = "Chad Stahelski", Actors = new string[]{"Keanu Reeves", "Laurence Fishburne"}, ImageUrl = "3.jpg", GenreId = 3},
                new Movie(){MovieId = 4, Title = "Knives Out", Description = "A detective investigates the death of the patriarch of an eccentric, combative family.", Director = "Rian Johnson", Actors = new string[]{"Daniel Craig", "Ana de Armas"}, ImageUrl = "4.jpg", GenreId = 2},
                new Movie(){MovieId = 5, Title = "Eternal Sunshine of the Spotless Mind", Description = "When their relationship turns sour, a couple undergoes a medical procedure to have each other erased from their memories for ever.", Director = "Michel Gondry", Actors = new string[]{"Jm Carrey", "Kate Winslet"}, ImageUrl = "5.jpg", GenreId = 4},
                new Movie(){MovieId = 6, Title = "The Dictator", Description = "The heroic story of a dictator who risked his life to ensure that democracy would never come to the country he so lovingly oppressed.", Director = "Larry Charles", Actors = new string[]{"Sacha Baron Cohen", "Anna Faris"}, ImageUrl = "6.jpg", GenreId = 2}
            };
        }

        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }
    }
}
