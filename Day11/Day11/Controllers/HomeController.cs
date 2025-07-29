using Day11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day11.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepo<Movie> _repo;

        public HomeController(IRepo<Movie> repo)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
