﻿using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source = movies.db");
        //}
    }
}
