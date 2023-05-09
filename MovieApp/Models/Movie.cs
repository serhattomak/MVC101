using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [DisplayName("Movie Name")]
        [Required(ErrorMessage = "Movie title is required")]
        [StringLength(50,ErrorMessage = "Title can not be longer than 50 characters")]
        public string Title { get; set; } // null
        [Required(ErrorMessage = "Movie description is required")]
        public string Description { get; set; }
        public string Director { get; set; }

        public string[] Actors { get; set; }
        [Required]
        public string ImageUrl { get; set; } // null
        [Required]
        public int? GenreId { get; set; } // null
    }
}
