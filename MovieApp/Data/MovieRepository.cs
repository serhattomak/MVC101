﻿using MovieApp.Models;

namespace MovieApp.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie(){MovieId = 1, Title = "Movie 1", Description = "Description 1", Director = "Director 1", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "1.jpg"},
                new Movie(){MovieId = 2, Title = "Movie 2", Description = "Description 2", Director = "Director 2", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "2.jpg"},
                new Movie(){MovieId = 3, Title = "Movie 3", Description = "Description 3", Director = "Director 3", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "3.jpg"},
                new Movie(){MovieId = 4, Title = "Movie 4", Description = "Description 4", Director = "Director 4", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "1.jpg"},
                new Movie(){MovieId = 5, Title = "Movie 5", Description = "Description 5", Director = "Director 5", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "2.jpg"},
                new Movie(){MovieId = 6, Title = "Movie 6", Description = "Description 6", Director = "Director 6", Actors = new string[]{"actor 1", "actor 2"}, ImageUrl = "3.jpg"}
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
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }
    }
}