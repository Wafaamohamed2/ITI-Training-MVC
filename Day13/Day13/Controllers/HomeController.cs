
using Day13.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day13.Controllers
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
            
            return View();
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
