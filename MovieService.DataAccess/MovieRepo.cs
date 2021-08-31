using MovieService.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieService.DataAccess
{
    public static class MovieRepo
    {
        private static List<Movie> _movies { get; set; }
        private static List<Movie> Movies
        {
            get
            {
                if (_movies == null)
                {
                    _movies = new List<Movie>();
                    for (int i = 1; i <= 100; i++)
                    {
                        _movies.Add(new Movie
                        {
                            Id = i,
                            Name = $"Film {i}",
                            Detail = $"Detail {i}",
                            Imdb = $"{i}",
                            Year = 2000 + i,
                            CategoryId = i,
                            Medias = new List<string> { $"/Files/{i}.mgep" },
                            Picture = $"/Images/{i}.png",
                            Types = new List<string> { $"Type {i}" },
                        });
                    }
                    return _movies;
                }
                return _movies;
            }
            set { Movies = value; }
        }

        public static void Insert(Movie entity)
        {
            Movies.Add(entity);
        }
        public static void Update(Movie entity)
        {
            Delete(entity);
            Insert(entity);
        }
        public static void Delete(Movie entity)
        {
            Movies.RemoveAll(x => x.Id == entity.Id);
        }
        public static List<Movie> List()
        {
            return Movies;
        }
        public static Movie GetById(int Id)
        {
            return Movies.Find(x => x.Id == Id);
        }
        public static List<Movie> GetByCategoryId(int CategoryId)
        {
            return Movies.Where(x => x.Id == CategoryId).ToList();
        }
    }
}
