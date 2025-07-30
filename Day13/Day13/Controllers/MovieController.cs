using Day13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day13.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepo<Movie> _repo;

        public MovieController(IRepo<Movie> repo)
        {
            _repo = repo;
        }



        public IActionResult Index()
        {
            var movies = _repo.GetAll();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _repo.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        public IActionResult TestJson()
        {
            var movies = _repo.GetAll();
            return Json(movies);
        }
       

        [HttpGet]
        public IActionResult GetAllAsJson()
        {
            var movies = _repo.GetAll();
            return Json(movies);
        }







    }
}
