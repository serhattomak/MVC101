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

            context.Database.Migrate(); // dotnet ef database update

            var genres = new List<Genre>()
            {
                new Genre {Name = "Adventure", Movies =
                    new List<Movie>()
                {
                    new Movie()
                    {
                        Title = "new adventure movie 1",
                        Description =
                            "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                        ImageUrl = "1.jpg",
                    },
                    new Movie()
                    {
                        Title = "new adventure movie 2",
                        Description =
                            "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                        ImageUrl = "2.jpg",
                    },
                }},
                new Genre {Name = "Comedy"},
                new Genre {Name = "Action"},
                new Genre {Name = "Sci-Fi"},
                new Genre {Name = "Drama"}
            };
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Inception",
                    Description =
                        "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                    ImageUrl = "1.jpg",
                    Genre= genres[0]
                },
                new Movie()
                {
                    Title = "Interstellar",
                    Description =
                        "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    ImageUrl = "2.jpg",
                    Genre=genres[1]
                },
                new Movie()
                {
                    Title = "John Wick 4",
                    Description =
                        "John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.",
                    ImageUrl = "3.jpg",
                    Genre=genres[1]
                },
                new Movie()
                {
                    Title = "Knives Out",
                    Description =
                        "A detective investigates the death of the patriarch of an eccentric, combative family.",
                    ImageUrl = "4.jpg",
                    Genre=genres[2]
                },
                new Movie()
                {
                    Title = "Eternal Sunshine of the Spotless Mind",
                    Description =
                        "When their relationship turns sour, a couple undergoes a medical procedure to have each other erased from their memories for ever.",
                    ImageUrl = "5.jpg",
                    Genre=genres[2]
                },
                new Movie()
                {
                    Title = "The Dictator",
                    Description =
                        "The heroic story of a dictator who risked his life to ensure that democracy would never come to the country he so lovingly oppressed.",
                    ImageUrl = "6.jpg",
                    Genre=genres[3]
                }

            };
            var users = new List<User>()
            {
                new User(){UserName = "usera", Email = "usera@gmail.com", Password = "1234", ImageUrl = "person1.jpg"},
                new User(){UserName = "userb", Email = "userb@gmail.com", Password = "1234", ImageUrl = "person2.jpg"},
                new User()
                {UserName = "userc", Email = "userc@gmail.com", Password = "1234", ImageUrl = "person3.jpg"},
                new User()
                {UserName = "userd", Email = "userd@gmail.com", Password = "1234", ImageUrl = "person4.jpg"}
            };
            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Person 1",
                    Biography = "bio 1",
                    User = users[0]
                },
                new Person()
                {
                    Name = "Person 2", 
                    Biography = "bio 2",
                    User = users[1]
                }
            };
            var crews = new List<Crew>()
            {
                new Crew(){Movie = movies[0], Person = people[0],Job = "Director"},
                new Crew(){Movie = movies[0], Person = people[1],Job = "Co-Director"}
            };
            var casts = new List<Cast>()
            {
                new Cast(){Movie = movies[0], Person = people[0], Name = "Actor Name 1", Character = "Character 1"},
                new Cast(){Movie = movies[0], Person = people[1], Name = "Actor Name 2", Character = "Character 2"}
            };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }

                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }

                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }

                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }

                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }

                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }


                context.SaveChanges();
            }
        }
    }
}
