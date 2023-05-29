using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(new List<Movie>()
                        {
                            new Movie(){MovieId = 1,
                                Title = "Inception",
                                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                                ImageUrl = "1.jpg",
                                GenreId = 4},
                            new Movie(){MovieId = 2,
                                Title = "Interstellar",
                                Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                                ImageUrl = "2.jpg",
                                GenreId = 4},
                            new Movie(){MovieId = 3,
                                Title = "John Wick 4",
                                Description = "John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.",
                                ImageUrl = "3.jpg",
                                GenreId = 3},
                            new Movie(){MovieId = 4,
                                Title = "Knives Out",
                                Description = "A detective investigates the death of the patriarch of an eccentric, combative family.",
                                ImageUrl = "4.jpg",
                                GenreId = 2},
                            new Movie(){MovieId = 5,
                                Title = "Eternal Sunshine of the Spotless Mind",
                                Description = "When their relationship turns sour, a couple undergoes a medical procedure to have each other erased from their memories for ever.",
                                ImageUrl = "5.jpg",
                                GenreId = 4},
                            new Movie(){MovieId = 6,
                                Title = "The Dictator",
                                Description = "The heroic story of a dictator who risked his life to ensure that democracy would never come to the country he so lovingly oppressed.",
                                ImageUrl = "6.jpg",
                                GenreId = 2}

                        }
                        );
                }

                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange( new List<Genre>()
                        {
                            new Genre { GenreId = 1, Name = "Adventure" },
                            new Genre { GenreId = 2, Name = "Comedy" },
                            new Genre { GenreId = 3, Name = "Action" },
                            new Genre { GenreId = 4, Name = "Sci-Fi" },
                            new Genre { GenreId = 5, Name = "Drama" }
                        }
                        );
                }

                context.SaveChanges();
            }
        }
    }
}
