using Day14__WebAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace Day14__WebAPI.Models
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        // Additional methods can be added as needed, e.g., Create, Update, Delete
      
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);


    }

    public class Repo : IRepo<Movie>
    {
        public static List<Movie> movies = new List<Movie>
        {
            new Movie(1, "Inception", "Christopher Nolan", 2010, "Sci-Fi"),
            new Movie(2, "The Godfather", "Francis Ford Coppola", 1972, "Crime"),
            new Movie(3, "The Dark Knight", "Christopher Nolan", 2008, "Action"),
            new Movie(4, "Pulp Fiction", "Quentin Tarantino", 1994, "Drama"),
            new Movie(5, "The Shawshank Redemption", "Frank Darabont", 1994, "Drama"),
            new Movie(6, "Schindler's List", "Steven Spielberg", 1993, "History")
        };

        public void Create(Movie entity)
        {
            
            movies.Add(entity);
        }

        public void Delete(int id)
        {
            
            var movie = GetById(id);
            if (movie != null)
            {
                movies.Remove(movie);
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            
            return movies;
        }

        public Movie GetById(int id)
        {
            
            return movies.FirstOrDefault(m => m.Id == id)!;
        }

        public void Update(Movie entity)
        {
            
            var existingMovie = GetById(entity.Id);
            if (existingMovie != null) {
                existingMovie.Title = entity.Title;
                existingMovie.Director = entity.Director;
                existingMovie.Year = entity.Year;
                existingMovie.Genre = entity.Genre;
            }
            else
            {
                throw new KeyNotFoundException($"Movie with ID {entity.Id} not found.");
            }

           
        }
    }
}

