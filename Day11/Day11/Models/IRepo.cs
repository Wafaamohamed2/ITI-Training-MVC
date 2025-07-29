namespace Day11.Models
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
            new Movie(3, "The Dark Knight", "Christopher Nolan", 2008, "Action")
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

