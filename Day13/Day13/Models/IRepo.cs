using System.Collections.Generic;
using System.Linq;


namespace Day13.Models
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
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

        public IEnumerable<Movie> GetAll()
        {
            return movies;
        }

        public Movie GetById(int id)
        {
            return movies.FirstOrDefault(item => item.Id == id);
        }
    }
}

