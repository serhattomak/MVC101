using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieApp.Entity
{ 
    public class Movie
    {
        // Primary Key => Id, <TypeName>Id
        
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
