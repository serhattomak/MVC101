﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieApp.Entity
{ 
    public class Movie
    {
        // Primary Key => Id, <TypeName>Id
        

        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Actors { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}