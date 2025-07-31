using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class MovieController : Controller
    {

        private readonly MovieApi _movieApi;

        public MovieController(MovieApi movieApi)
        {
            _movieApi = movieApi;
        }


        public async Task<IActionResult> Index()
        {
            var movies = await _movieApi.GetMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieApi.GetMovieAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var createdMovie = await _movieApi.AddMovieAsync(movie);
                if (createdMovie != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieApi.GetMovieAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var success = await _movieApi.UpdateMovieAsync(movie);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieApi.GetMovieAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _movieApi.DeleteMovieAsync(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
