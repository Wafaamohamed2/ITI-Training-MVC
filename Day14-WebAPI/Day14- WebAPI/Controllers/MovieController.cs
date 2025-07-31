
using Day14__WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day14__WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepo<Movie> _repo;
        public MovieController(IRepo<Movie> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _repo.GetAll();
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found.");
            }
            return Ok(movies);
        }


        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _repo.GetById(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found.");
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Create(Movie movie) { 
        
            
            if (movie == null)
            {
                return BadRequest("Movie cannot be null.");
            }
              _repo.Create(movie);

            return Ok(movie);

        }


        [HttpPut("{id}")]
        public IActionResult Update(Movie movie, int id) {

            if (movie.Id != id)
            {
                return BadRequest("Invalid movie ID.");
            }

            var existingMovie = _repo.GetById(id);
            if (existingMovie == null)
            {
                return NotFound($"Movie with ID {id} not found.");
            }

            _repo.Update(movie);
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            var movie = _repo.GetById(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found.");
            }
    
            _repo.Delete(id);
            return NoContent(); 
           
        }

    }
}
