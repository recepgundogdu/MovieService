using System.Collections.Generic;

namespace MovieService.DataAccess.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Detail { get; set; }
        public string Imdb { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public List<string> Types { get; set; }
        public List<string> Medias { get; set; }
    }
}
