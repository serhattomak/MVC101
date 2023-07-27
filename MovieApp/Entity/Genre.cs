using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
